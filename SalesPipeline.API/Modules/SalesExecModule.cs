using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Nancy;

    public class SalesExecModule : BaseModule
    {
        public SalesExecModule(ISalesExecService salesExecService) : base("lookup")
        {
            this._salesExecService = salesExecService;

            this.Get(
                "/salesexec",
                parameters =>
                {
                    try
                    {
                        var salesExecs = this._salesExecService.Get().ToList();

                        return this.GetJsonResponse(salesExecs);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });
        }



        #region PrivateProperties

        private ISalesExecService _salesExecService { get; }

        #endregion
    }
}
