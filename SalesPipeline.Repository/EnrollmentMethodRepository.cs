using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Interfaces.Repositories;
    using Common.Models;

    public class EnrollmentMethodRepository : IEnrollmentMethodRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnrollmentMethodRepository"/> class
        /// </summary>
        public EnrollmentMethodRepository()
        {
        }

        #endregion

        #region Public Methods  


        public IList<EnrollmentMethod> Get()
        {
            var sql = @"SELECT EnrollmentMethodId, EnrollmentMethodType 
                        FROM EnrollmentMethod";

            var enrollmentMethods = new List<EnrollmentMethod>();

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
                            enrollmentMethods.Add(this.GetEnrollmentMethods(dataReader));
                        }
                    }
                }
            }
            
            return enrollmentMethods;
        }

        #endregion

        #region Private Methods

        private EnrollmentMethod GetEnrollmentMethods(SqlDataReader dataReader)
        {
            return new EnrollmentMethod()
            {
                EnrollmentMethodId = (int)dataReader["EnrollmentMethodId"],
                EnrollmentMethodType = (string)dataReader["EnrollmentMethodType"]
            };
        }

        #endregion
    }
}

