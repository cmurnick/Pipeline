using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Interfaces.Repositories;
    using Common.Models;

    public class ProductRepository : IProductRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class
        /// </summary>
        public ProductRepository()
        {
        }

        #endregion

        #region Public Methods  


        public IList<Product> Get()
        {
            var sql = @"Select ProductId, ProductName
                        From Product";

            var products = new List<Product>();

            using (var connection =
                new SqlConnection(
                    "Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77")
            )
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            products.Add(this.GetProducts(dataReader));
                        }
                    }
                }
            }

            return products;
        }

        public IList<Product> GetForProject(int projectId)
        {
            var sql = @"Select * from Product p
                        Join ProductProject pp on p.ProductId = pp.ProductId

                        Where pp.ProjectId = @ProjectId";

            var products = new List<Product>();
            using (var connection =
                new SqlConnection(
                    "Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77")
            )
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@projectId", projectId);
                    connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var product = GetProducts(dataReader);
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        #endregion

        #region Private Methods

        private Product GetProducts(SqlDataReader dataReader)
        {
            return new Product()
            {
                ProductId = (int) dataReader["ProductId"],
                ProductName = (string) dataReader["ProductName"]
            };
        }

        //private SqlCommand GetParameters(SqlCommand command, Product product)
        //{
        //    command.Parameters.AddWithValue("@ProjectId", product.ProjectId);

        //    return command;
          
        //}
        #endregion
    }
}

