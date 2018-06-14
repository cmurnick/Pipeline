using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using System.Net;
    using Common.Interfaces.Services;
    using Nancy;
    using HttpStatusCode = Nancy.HttpStatusCode;

    public class ProductModule : BaseModule
    {
        public ProductModule(IProductService productService) : base("lookup")
        {
            this._productService = productService;

            this.Get(
                "/products",
                parameters =>
                {
                    try
                    {
                        var products = this._productService.Get().ToList();

                        return this.GetJsonResponse(products);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });

            this.Get(
                "/products/{projectid}",
                parameters =>
                {
                    try
                    {
                        var projectId = parameters.projectid;

                        var products = this._productService.GetAllForProject(projectId);
                        return this.GetJsonResponse(products);
                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });
        }



        #region PrivateProperties

        private IProductService _productService { get; }

        #endregion
    }
}
