using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Models;

    public class SalesExecRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesExecRepository"/> class
        /// </summary>
        public SalesExecRepository()
        {
        }

        #endregion

        #region Public Methods  


        public IList<SalesExec> Get()
        {
            var sql = @"SELECT SalesExecId, FirstName 
                        FROM SalesExec";

            var salesExecs = new List<SalesExec>();

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
                            salesExecs.Add(this.GetSalesExecs(dataReader));
                        }
                    }
                }
            }

            return salesExecs;
        }

        #endregion

        #region Private Methods

        private SalesExec GetSalesExecs(SqlDataReader dataReader)
        {
            return new SalesExec()
            {
                SalesExecId = (int)dataReader["SalesExecId"],
                FirstName = (string)dataReader["FirstName"]
            };
        }

        #endregion
    }
}

