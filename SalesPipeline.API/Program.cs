﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SalesPipeline.API
{
    /// <summary>
    /// The Program Class
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
        /// <summary>
        /// The Main Method
        /// </summary>
        /// <param name="args">Arguments passed to the Main method</param>
        //    public static void Main(string[] args)
        //    {
        //        BuildWebHost(args).Run();
        //    }

        //    public static IWebHost BuildWebHost(string[] args) =>
        //        WebHost.CreateDefaultBuilder(args)
        //            .UseStartup<Startup>()
        //            .Build();
    }
}
