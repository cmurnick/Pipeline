using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;

    public class VbCarrierService : IVbCarrierService
    {
        #region Constructors

        public VbCarrierService(IVbCarrierRepository vbCarrierRepository)
        {
            this._vbCarrierRepository = vbCarrierRepository;
        }

        #endregion

        #region PrivateProperties

        private IVbCarrierRepository _vbCarrierRepository { get; }

        #endregion

        #region Public Methods
        public IList<VbCarrier> Get()
        {
            return this._vbCarrierRepository.Get();
        }

        #endregion
    }
}
