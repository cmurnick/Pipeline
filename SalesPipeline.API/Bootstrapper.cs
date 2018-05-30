using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Bootstrappers.StructureMap;
    using StructureMap;

    public class Bootstrapper : StructureMapNancyBootstrapper
    {
        ///// <summary>
        ///// Configure application container method
        ///// </summary>
        ///// <param name="existingContainer">An implementation of <see cref="IContainer"/></param>
        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            // Set up IOC containter
            StructureMapContainer.Configure(existingContainer);
        }

        /// <summary>
        /// The request startup method
        /// </summary>
        /// <param name="container">An implementation of <see cref="IContainer"/></param>
        /// <param name="pipelines">An implementation of <see cref="IPipelines"/></param>
        /// <param name="context">An instance of <see cref="NancyContext"/></param>
        protected override void RequestStartup(IContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Credentials", "true")
                    .WithHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT,DELETE")
                    .WithHeader("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin, Accept, X-Requested-With, private_key, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers");
            });
        }
    }
}
