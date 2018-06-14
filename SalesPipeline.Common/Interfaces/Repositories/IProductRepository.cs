using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Repositories
{
    using Models;

    public interface IProductRepository
    {
        IList<Product> Get();

        IList<Product> GetForProject(int projectId);
    }
}
