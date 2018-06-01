using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using SalesPipeline.Common.Models;
    using System.Data;
    using System.Data.SqlClient;
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;

    public class ClassificationRepository : IClassificationRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationRepository"/> class
        /// </summary>
        public ClassificationRepository()
        {
        }

        #endregion

        #region Public Methods  


        public IList<Classification> Get()
        {
            var sql = @"SELECT ClassificationId, ClassificationName 
                        FROM Classification";

            var classifications = new List<Classification>();

            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77"))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            classifications.Add(this.GetClassifications(dataReader));
                        }
                    }
                }
            }

            
            return classifications;
        }

        #endregion

        #region Private Methods

        private Classification GetClassifications(SqlDataReader dataReader)
        {
            return new Classification()
            {
                ClassificationId = (int)dataReader["ClassificationId"],
                ClassificationName = (string)dataReader["ClassificationName"]
            };
        }

        #endregion
    }
}
