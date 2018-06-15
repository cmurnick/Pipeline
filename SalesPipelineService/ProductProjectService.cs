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


        public List<ProductProject> Save(List<Product> products, int projectId)
        {
           
            this.Delete(projectId);
            var productProjects = new List<ProductProject>();
            foreach (var product in products)
            {
                if (product.Selected)
                {
                  
                    var productProject = new ProductProject()
                    {
                        ProjectId = projectId,
                        ProductId = product.ProductId
                    };

                    this._productProjectRepository.Insert(productProject);
                  
                    productProjects.Add(productProject);
                }
            }


            return productProjects;

        }

        public bool Delete(int projectId)
        {
            return this._productProjectRepository.Delete(projectId);
        }
    }
}
