using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Models;

    public class VBCarrierRespository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VBCarrierRepository"/> class
        /// </summary>
        public VBCarrierRespository()
        {
        }

        #endregion

        #region Public Methods  


        public IList<VBCarrier> Get()
        {
            var sql = @"Select VBCarrierId, VBCarrierName
                        From VBCarrier";

            var vbCarrier = new List<VBCarrier>();

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
                            vbCarrier.Add(this.GetVBCarrier(dataReader));
                        }
                    }
                }
            };
            return vbCarrier;
        }

        #endregion

        #region Private Methods

        private VBCarrier GetVBCarrier(SqlDataReader dataReader)
        {
            return new VBCarrier()
            {
                VBCarrierId = (int)dataReader["VBCarrierId"],
                VBCarrierName = (string)dataReader["VBCarrierName"]
            };
        }

        #endregion
    }
}

