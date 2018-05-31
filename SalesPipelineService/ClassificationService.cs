using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Models;

    public class ClassificationService
    {
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
