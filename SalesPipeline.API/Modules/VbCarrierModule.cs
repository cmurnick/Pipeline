using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Nancy;

    public class VbCarrierModule : BaseModule
    {
        public VbCarrierModule(IVbCarrierService vbCarrierService) : base("lookup")
        {
            this._vbCarrierService = vbCarrierService;

            this.Get(
                "/vbcarriers",
                parameters =>
                {
                    try
                    {
                        var vbCarriers = this._vbCarrierService.Get().ToList();

                        return this.GetJsonResponse(vbCarriers);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });
        }



        #region PrivateProperties

        private IVbCarrierService _vbCarrierService { get; }

        #endregion
    }
}
