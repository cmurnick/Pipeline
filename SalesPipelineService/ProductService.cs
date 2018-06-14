using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Common.Models;

    public class ProductService : IProductService
    {
        #region Constructors

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        #endregion

        #region PrivateProperties

        private IProductRepository _productRepository { get; }

        #endregion

        #region Public Methods
        public IList<Product> Get()
        {
            return this._productRepository.Get();
        }

        public IList<Product> GetForProject(int projectId)
        {
            return this._productRepository.GetForProject(projectId);
        }

        #endregion
    }
}
