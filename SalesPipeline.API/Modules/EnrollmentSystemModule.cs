using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Nancy;

    public class EnrollmentSystemModule : BaseModule
    {
        public EnrollmentSystemModule(IEnrollmentSystemService enrollmentSystemService) : base("lookup")
        {
            this._enrollmentSystemService = enrollmentSystemService;

            this.Get(
                "/enrollmentsystems",
                parameters =>
                {
                    try
                    {
                        var enrollmentSystems = this._enrollmentSystemService.Get().ToList();

                        return this.GetJsonResponse(enrollmentSystems);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });
        }

        #region PrivateProperties

        private IEnrollmentSystemService _enrollmentSystemService { get; }

        #endregion
    }
}

