using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SalesPipeline.API.Modules
{
    using Nancy;
    using Newtonsoft.Json;

    public abstract class BaseModule : NancyModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModule"/> class
        /// </summary>
        protected BaseModule() : base(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModule"/> class
        /// </summary>
        /// <param name="modulePath">The base path for this module</param>
        protected BaseModule(string modulePath) : base(modulePath)
        {
        }

        /// <summary>
        /// Builds a JSON response with an HTTP status code of OK
        /// </summary>
        /// <param name="payload">The payload for the response body</param>
        /// <returns>An instance of <see cref="Response"/></returns>
        protected Response GetJsonResponse(object payload)
        {
            var response = (Response)JsonConvert.SerializeObject(payload);
            response.ContentType = "application/json";
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
