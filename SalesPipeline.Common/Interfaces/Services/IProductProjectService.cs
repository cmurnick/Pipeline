using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Services
{
    using Models;

    public interface IProductProjectService
    {
        ProductProject Save(ProductProject ProductProject);

        bool Delete(int projectId);
    }
}
