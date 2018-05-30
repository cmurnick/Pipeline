using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Repositories
{
    using Models;

    interface IEnrollmentSystemRepository
    {
        IList<EnrollmentSystem> Get();
    }
}
