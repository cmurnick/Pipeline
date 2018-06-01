using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Interfaces;
    using Common.Models;

    public class VbCarrierRepository : IVbCarrierRepository
    {
        #region Public Methods  


        public IList<VbCarrier> Get()
        {
            var sql = @"SELECT VbCarrierId, VbCarrierName 
                        FROM VbCarrier";

            var vbCarriers = new List<VbCarrier>();

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
                            vbCarriers.Add(this.GetVbCarriers(dataReader));
                        }
                    }
                }
            }


            return vbCarriers;
        }

        #endregion

        #region Private Methods

        private VbCarrier GetVbCarriers(SqlDataReader dataReader)
        {
            return new VbCarrier()
            {
                VbCarrierId = (int)dataReader["ClassificationId"],
                VbCarrierName = (string)dataReader["ClassificationName"]
            };
        }

        #endregion
    }

}
}
