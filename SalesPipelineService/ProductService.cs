using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Service
{
    using Common.Interfaces.Repositories;
    using Common.Models;

    public class ProductService
    {
        #region PrivateProperties

        private IProductRepository _productRepository { get; }

        #endregion

        #region Public Methods
        public IList<Product> Get()
        {
            return this._productRepository.Get();
        }

        #endregion
    }
}
