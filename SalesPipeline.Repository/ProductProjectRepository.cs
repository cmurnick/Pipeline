using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Common.Interfaces.Repositories;
    using Common.Models;

    public class ProductProjectRepository : IProductProjectRepository
    {
        public ProductProject Insert(ProductProject productProject)
        {
            var sql = @"INSERT INTO ProductProject (ProjectId, ProductId)
                        SELECT @ProjectId FROM Project 
                        SELECT @ProductId From Product";

            using (var connection =
                new SqlConnection(
                    "Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77")
            )
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                   
                    this.GetParameters(command, productProject);
                    command.Parameters["@ProjectId"].Direction = ParameterDirection.InputOutput;
                    command.Parameters["@ProductId"].Direction = ParameterDirection.InputOutput;

                    connection.Open();

                    command.ExecuteNonQuery();

                    productProject.ProjectId = (int) command.Parameters["@ProjectId"].Value;
                    productProject.ProductId = (int) command.Parameters["@ProductId"].Value;
                }
            }

                return productProject;
        }

        public bool Delete(int projectId)
        {

            var sql = "DELETE FROM ProductProject " +
                      "WHERE ProjectId = @ProjectId";



            using (var connection =
                new SqlConnection(
                    "Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77")
            )
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@ProjectId", projectId);

                    connection.Open();

                    command.ExecuteNonQuery();

                    return true;
                }
            }
        }

        #region Private

        private ProductProject GetProductProject(SqlDataReader dataReader)
        {

            return new ProductProject()
            {
                ProjectId = (int) dataReader["ProjectId"],
                ProductId = (int) dataReader["ProductId"],
                ProductProjectId = (int) dataReader["ProductProjectId"]
            };
        }

        private SqlCommand GetParameters(SqlCommand command, ProductProject productProject)
            {
                command.Parameters.AddWithValue("@ProjectId", productProject.ProjectId);
                command.Parameters.AddWithValue("@ProductId", productProject.ProductId);

            return command;
            }
        }

        #endregion
    }


