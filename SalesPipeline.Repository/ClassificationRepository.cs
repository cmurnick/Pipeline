using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using SalesPipeline.Common.Models;
    using System.Data;
    using System.Data.SqlClient;

    public class ClassificationRepository
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
                            classifications.Add(this.GetClassifications(dataReader));
                        }
                    }
                }
            }

            ;
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
