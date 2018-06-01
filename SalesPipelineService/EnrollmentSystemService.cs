using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;

    public class EnrollmentSystemService : IEnrollmentSystemService
    {
        #region Constructors

        public EnrollmentSystemService(IEnrollmentSystemRepository enrollmentSystemRepository)
        {
            this._enrollmentSystemRepository = enrollmentSystemRepository;
        }

        #endregion
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
