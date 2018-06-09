using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Nancy;

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
        }



        #region PrivateProperties

        private IProductService _productService { get; }

        #endregion
    }
}
