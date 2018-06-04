using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Common.Models;
    using Nancy;
    using Nancy.ModelBinding;

    public class ProductProjectModule : BaseModule
    {
        public ProductProjectModule(IProductProjectService productProjectService) : base("/productproject")
        {
            this._productProjectService = productProjectService;

            this.Post(
                "/",
                parameters =>
                {
                    try
                    {
                        var productProject = this.Bind<ProductProject>();

                        var serviceReturn = new ServiceReturn<ProductProject>();

                        serviceReturn.Success = true;

                        return this.GetJsonResponse(serviceReturn);
                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });

            this.Delete(
                "/{projectid}",
                parameters =>
                {
                    try
                    {
                        int projectId = parameters.projectId;
                        var serviceReturn = new ServiceReturn<ProductProject>();
                        serviceReturn.Success = this._productProjectService.Delete(projectId);
                        serviceReturn.ItemId = projectId;

                        return this.GetJsonResponse(serviceReturn);

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