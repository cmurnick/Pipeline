﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Repositories
{
    using Models;

    public interface IEnrollmentSystemRepository
    {
        IList<EnrollmentSystem> Get();
    }
}
