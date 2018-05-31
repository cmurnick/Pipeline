using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Models;

    public class EnrollmentMethodService
    {
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
