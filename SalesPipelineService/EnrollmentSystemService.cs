using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Models;

    public class EnrollmentSystemService
    {
        #region PrivateProperties

        private IEnrollmentSystemRepository _enrollmentSystemRepository { get; }

        #endregion

        #region Public Methods
        public IList<EnrollmentSystem> Get()
        {
            return this._enrollmentSystemRepository.Get();
        }

        #endregion
    }
}
