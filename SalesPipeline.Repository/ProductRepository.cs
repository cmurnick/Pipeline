using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Models;

    public class ProductRepository
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

            using (var connection = new SqlConnection("Server=(local);Database=Capstone;Trusted_Connection=True;"))
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
            };
            return products;
        }

        #endregion

        #region Private Methods

        private Product GetProducts(SqlDataReader dataReader)
        {
            return new Product()
            {
                ProductId = (int)dataReader["ProductId"],
                ProductName = (string)dataReader["ProductName"]
            };
        }

        #endregion
    }
}

