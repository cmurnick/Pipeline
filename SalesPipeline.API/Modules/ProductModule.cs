using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using System.Net;
    using Common.Interfaces.Services;
    using Common.Models;
    using Nancy;
    using Nancy.ModelBinding;
    using HttpStatusCode = Nancy.HttpStatusCode;

    public class ProductModule : BaseModule
    {
        public ProductModule(IProductService productService, IProductProjectService productProjectService) : base("lookup")
        {
            this._productService = productService;
            this._productProjectService = productProjectService;

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

            this.Post(
                "/project/{projectid}/products",
                parameters =>
                {
                    try
                    {
                        var projectId = parameters.projectid;

                        var products = this.Bind<List<Product>>();
                        var serviceReturn = new ServiceReturn<List<ProductProject>>();

                        serviceReturn.Data = this._productProjectService.Save(products, projectId);

                        serviceReturn.Success = true;

                        return this.GetJsonResponse(serviceReturn);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                });
        }



        #region PrivateProperties

        private IProductService _productService { get; }
        
        private IProductProjectService _productProjectService { get; }
        #endregion
    }
}
