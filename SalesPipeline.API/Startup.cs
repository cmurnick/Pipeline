using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SalesPipeline.API
{
    using Microsoft.Extensions.Logging;
    using Nancy.Owin;

    public class Startup
    {
        //    /// <summary>
        //    /// Configures services for API
        //    /// </summary>
        //    /// <param name="services">An implementation of <see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /// <summary>
        /// Configures the web application
        /// </summary>
        /// <param name="app">An implementation of <see cref="IApplicationBuilder"/></param>
        /// <param name="env">An implementation of <see cref="IHostingEnvironment"/></param>
        /// <param name="loggerFactory">An implementation of <see cref="ILoggerFactory"/></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOwin(x => x.UseNancy());
        }
    }

    //public class Startup
    //{
    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }

    //        app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });

    //        app.UseOwin(x => x.UseNancy());
    //    }
    //}
}
