using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Services
{
    using Models;

    public interface IProductProjectService
    {
        List<ProductProject> Save(List<Product> products, int projectId);

        bool Delete(int projectId);
    }
}
