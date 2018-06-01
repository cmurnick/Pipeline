using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;
    using Repository;

    public class AllSeedDataService : IAllSeedDataService
    {
        #region Constructors

        public AllSeedDataService(
            IClassificationRepository classificationRepository,
            IEnrollmentMethodRepository enrollmentMethodRepository,
            IEnrollmentSystemRepository enrollmentSystemRepository,
            ISalesExecRepository salesExecRepository,
            IVBCarrierRepository vBCarrierRepository)
        {
            this._classificationRepository = classificationRepository;
            this._enrollmentMethodRepository = enrollmentMethodRepository;
            this._enrollmentSystemRepository = enrollmentSystemRepository;
            this._salesExecRepository = salesExecRepository;
            this._vBCarrierRepository = vBCarrierRepository;

        }

        #endregion

        #region Private Properties

        private IClassificationRepository _classificationRepository { get; set; }
        private IEnrollmentMethodRepository _enrollmentMethodRepository { get; set; }
        private IEnrollmentSystemRepository _enrollmentSystemRepository { get; set; }
        private ISalesExecRepository _salesExecRepository { get; set; }
        private IVBCarrierRepository _vBCarrierRepository { get; set; }

        #endregion

        public void ExportSeedData(List<Classification> classifications, List<EnrollmentMethod> enrollmentMethods,
            List<EnrollmentSystem> enrollmentSystems, List<SalesExec> salesExecs, List<VBCarrier> vBCarriers)
        {

            this._classificationRepository.Get();
            this._enrollmentMethodRepository.Get();
            this._enrollmentSystemRepository.Get();
            this._salesExecRepository.Get();
            this._vBCarrierRepository.Get();

        }
    }
}
