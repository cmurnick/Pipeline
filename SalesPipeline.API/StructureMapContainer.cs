using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API
{
    using StructureMap;

    public class StructureMapContainer
    {
        /// <summary>
        /// Registers assemblies to be scanned for the IOC container
        /// </summary>
        /// <param name="container">An instance of the <see cref="IContainer"/> interface</param>
        public static void Configure(IContainer container)
        {
            container.Configure(config => config.Scan(c =>
            {
                c.Assembly("SalesPipeline.API");
                c.Assembly("SalesPipeline.Common");
                c.Assembly("SalesPipeline.Repository");
                c.Assembly("SalesPipeline.Service");
                c.WithDefaultConventions();
                c.LookForRegistries();
            }));
        }
    }
}
