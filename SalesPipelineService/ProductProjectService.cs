using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;

    public class ProductProjectService : IProductProjectService
    {
        #region Constructors

        public ProductProjectService(IProductProjectRepository productProjectRepository)
        {
            this._productProjectRepository = productProjectRepository;
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets an implementation of the <see cref="ICustomerRepository"/> interface
        /// </summary>
        private IProductProjectRepository _productProjectRepository { get; }

        #endregion


        public ProductProject Save(ProductProject productProject)
        {
            return this._productProjectRepository.Insert(productProject);

        }

        public bool Delete(int projectId)
        {
            return this._productProjectRepository.Delete(projectId);
        }
    }
}
