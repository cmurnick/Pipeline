using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;

    public class ClassificationService : IClassificationService
    {
        #region Constructors

        public ClassificationService(IClassificationRepository classificationRepository)
        {
            this._classificationRepository = classificationRepository;
        }

        #endregion

        #region PrivateProperties

        private IClassificationRepository _classificationRepository { get; }

        #endregion

        #region Public Methods
        public IList<Classification> Get()
        {
            return this._classificationRepository.Get();
        }

        #endregion

    }
}
