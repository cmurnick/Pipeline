using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Interfaces.Services;
    using Nancy;

    public class ClassificationModule : BaseModule
    {
        public ClassificationModule(IClassificationService classificationService) : base("lookup")
        {
            this._classificationService = classificationService;

            this.Get(
                "/classifications",
                parameters =>
                {
                    try
                    {
                        var classifications = this._classificationService.Get().ToList();

                        return this.GetJsonResponse(classifications);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });
        }



        #region PrivateProperties

        private IClassificationService _classificationService { get; }

        #endregion
    }
}
