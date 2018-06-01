using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Services
{
    using Models;

    public interface ISalesExecService
    {
        IList<SalesExec> Get();
    }
}
