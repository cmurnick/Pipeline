using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Models;

    public class EnrollmentSystemRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnrollmentSystemRepository"/> class
        /// </summary>
        public EnrollmentSystemRepository()
        {
        }

        #endregion

        #region Public Methods  


        public IList<EnrollmentSystem> Get()
        {
            var sql = @"SELECT EnrollmentSystemId, SystemName 
                        FROM EnrollmentSystem";

            var enrollmentSystems = new List<EnrollmentSystem>();

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
                            enrollmentSystems.Add(this.GetEnrollmentSystems(dataReader));
                        }
                    }
                }
            }

            ;
            return enrollmentSystems;
        }

        #endregion

        #region Private Methods

        private EnrollmentSystem GetEnrollmentSystems(SqlDataReader dataReader)
        {
            return new EnrollmentSystem()
            {
                EnrollmentSystemId = (int)dataReader["EnrollmentSystemId"],
                SystemName = (string)dataReader["SystemName"]
            };
        }

        #endregion
    }
}

