using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces
{
    using Models;

    public interface IVbCarrierRepository
    {
        IList<VbCarrier> Get();
    }
}
