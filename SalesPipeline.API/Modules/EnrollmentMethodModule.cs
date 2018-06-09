using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Nancy;

    public class EnrollmentMethodModule : BaseModule
    {
        public EnrollmentMethodModule(IEnrollmentMethodService enrollmentMethodService) : base("lookup")
        {
            this._enrollmentMethodService = enrollmentMethodService;

            this.Get(
                "/enrollmentmethods",
                parameters =>
                {
                    try
                    {
                        var enrollmentMethods = this._enrollmentMethodService.Get().ToList();

                        return this.GetJsonResponse(enrollmentMethods);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });
        }

        #region PrivateProperties

        private IEnrollmentMethodService _enrollmentMethodService { get; }

        #endregion
    }
}

