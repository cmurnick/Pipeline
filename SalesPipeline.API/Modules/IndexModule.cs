using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    public class IndexModule : BaseModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModule"/> class
        /// </summary>
        public IndexModule() : base(string.Empty)
        {
            // Default end point for service
            this.Get(
                "/",
                args =>
                {
                    
                    return "Sales Pipeline API is running";
                });
        }
    }
}
