using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;

    public class SalesExecService : ISalesExecService
    {
        #region Constructors

        public SalesExecService(ISalesExecRepository salesExecRepository)
        {
            this._salesExecRepository = salesExecRepository;
        }

        #endregion
        #region PrivateProperties

        private ISalesExecRepository _salesExecRepository { get; }

        #endregion

        #region Public Methods
        public IList<SalesExec> Get()
        {
            return this._salesExecRepository.Get();
        }

        #endregion
    }
}
