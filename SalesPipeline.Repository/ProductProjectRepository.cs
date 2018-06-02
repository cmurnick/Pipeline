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
        public IList<ProductProject> GetProductProject(int projectId)
        {
            var sql = @"Select pp.ProductId, pp.ProjectId, pp.ProductProjectId FROM ProductProject pp
                        JOIN Project p on p.ProjectId = pp.ProjectId
                        WHERE pp.ProjectId = @ProjectId";

            var productProjects = new List<ProductProject>();

            using (var connection =
                new SqlConnection(
                    "Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77")
            )
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            productProjects.Add(this.GetProductProject(dataReader));
                        }
                    }
                }
            }

            return productProjects;
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

        private SqlCommand GetParameters(SqlCommand command, Project project)
            {
                command.Parameters.AddWithValue("@ProjectId", project.ProjectId);
               
                return command;
            }
        }

        #endregion
    }


