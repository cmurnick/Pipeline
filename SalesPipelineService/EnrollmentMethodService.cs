using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;

    public class EnrollmentMethodService : IEnrollmentMethodService
    {
        #region Constructors

        public EnrollmentMethodService(IEnrollmentMethodRepository enrollmentMethodRepository)
        {
            this._enrollmentMethodRepository = enrollmentMethodRepository;
        }

        #endregion
        #region PrivateProperties

        private IEnrollmentMethodRepository _enrollmentMethodRepository { get; }

        #endregion

        #region Public Methods
        public IList<EnrollmentMethod> Get()
        {
            return this._enrollmentMethodRepository.Get();
        }

        #endregion
    }
}
