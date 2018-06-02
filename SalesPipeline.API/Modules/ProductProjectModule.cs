using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Nancy;

    public class ProductProjectModule : BaseModule
    {
        public ProductProjectModule(IProductProjectService productProjectService) : base("/productproject")
        {
            this._productProjectService = productProjectService;

            this.Get(
                "/{projectid}",
                parameters =>
                {
                    try
                    {
                        var projectId = parameters.projectid;
                        var products = this._productProjectService.GetProductProject(projectId).ToList();

                        return this.GetJsonResponse(products);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });
        }

        #region PrivateProperties

        private IProductProjectService _productProjectService { get; }

        #endregion
    }
}