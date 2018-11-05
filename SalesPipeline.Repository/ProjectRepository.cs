using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Common.Interfaces;
    using Common.Models;
  


    public class ProjectRepository : IProjectRepository
    {
        #region Public Methods  

      

        public IList<Common.Models.Project> GetProjectsWithProductsForOneExec(int salesExecId)
        {
            var sql = @"Select  
                            p.ProjectId, 
                            p.CompanyName,
                            p.NumberEligible,
                            p.NumberInterview,
                            p.ClassificationId,
                            p.SalesExecId,
                            p.EnrollmentSystemId,
                            p.VbCarrierId,
                            p.EnrollmentMethodId,                       
                            p.New,
                            p.StartDate,
                            p.EndDate,
                            s.FirstName,
                            c.ClassificationName,
                            es.SystemName,
                            v.VbCarrierName,
                            em.EnrollmentMethodType
                           
                                
                            FROM Project p
								join Classification c on c.ClassificationId = p. ClassificationId
								join SalesExec s on s.SalesExecId = p.SalesExecId
								join EnrollmentSystem es on es.EnrollmentSystemId = p.EnrollmentSystemId
								join EnrollmentMethod em on em.EnrollmentMethodId = p.EnrollmentMethodId
								join VbCarrier v on v.VbCarrierId = p.VbCarrierId

                            WHERE p.SalesExecId = @SalesExecId

                            ORDER By p.ClassificationId";

            var projects = new List<Common.Models.Project>();

            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77"))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@SalesExecId", salesExecId);

                    connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                            while (dataReader.Read())
                            {
                                var project = GetProject(dataReader);
                                projects.Add(project);
                        }
                        }
                    }
                }
            return projects;
        }

        public IList<Common.Models.Project> GetAllExecProjectsWithProducts()
        {
            var sql = @"Select  
                            p.ProjectId, 
                            p.CompanyName,
                            p.NumberEligible,
                            p.NumberInterview,
                            p.ClassificationId,
                            p.SalesExecId,
                            p.EnrollmentSystemId,
                            p.VbCarrierId,
                            p.EnrollmentMethodId,                       
                            p.New,
                            p.StartDate,
                            p.EndDate,
                            s.FirstName,
                            c.ClassificationName,
                            es.SystemName,
                            v.VbCarrierName,
                            em.EnrollmentMethodType
                           
                                
                            FROM Project p
								join Classification c on c.ClassificationId = p. ClassificationId
								join SalesExec s on s.SalesExecId = p.SalesExecId
								join EnrollmentSystem es on es.EnrollmentSystemId = p.EnrollmentSystemId
								join EnrollmentMethod em on em.EnrollmentMethodId = p.EnrollmentMethodId
								join VbCarrier v on v.VbCarrierId = p.VbCarrierId
                                
                            WHERE p.ClassificationId = 1 or p.ClassificationId = 2 or p.ClassificationId = 3
                            ORDER By p.New, p.ClassificationId";

            var projects = new List<Project>();
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
                            var project = GetProject(dataReader);
                            projects.Add(project);
                        }

                    }
                }
            }
            return projects;
        }

        public Project Insert(Project project)
        {
            var sql = "INSERT INTO Project (CompanyName, NumberEligible, " +
                      "NumberInterview, ClassificationId, SalesExecId, " +
                      "New, EnrollmentSystemId, VbCarrierId, StartDate, EndDate, EnrollmentMethodId)" +
                      "VALUES (@CompanyName, @NumberEligible, " +
                      "@NumberInterview, @ClassificationId, @SalesExecId, " +
                      "@New, @EnrollmentSystemId, @VbCarrierId, @StartDate, @EndDate, @EnrollmentMethodId)" +
                      "SET @ProjectId = SCOPE_IDENTITY()";
                    

            using (var connection =
                new SqlConnection(
                    "Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77")
            )
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    this.GetParameters(command, project);
                    command.Parameters["@ProjectId"].Direction = ParameterDirection.InputOutput;

                    connection.Open();

                    command.ExecuteNonQuery();

                    project.ProjectId = (int)command.Parameters["@ProjectId"].Value;
                }
            }

            return project;
        }

        public Project Update(Project project)
        {
            var sql = @"UPDATE Project SET
                      CompanyName = @CompanyName,
                      NumberEligible = @NumberEligible,
                      NumberInterview = @NumberInterview,
                      ClassificationId = @ClassificationId,
                      SalesExecId = @SalesExecId,
                      New = @New,
                      EnrollmentSystemId = @EnrollmentSystemId,
                      VbCarrierId = @VbCarrierId,
                      StartDate = @StartDate,
                     EndDate = @EndDate,
                     EnrollmentMethodId = @EnrollmentMethodId
                     WHERE ProjectId = @ProjectId";

            using (var connection =
                new SqlConnection(
                    "Data Source=.;Initial Catalog=Capstone;Integrated Security=False;MultipleActiveResultSets=True;User Id=capstoneUser;Password=hadleigh77")
            )
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;


                    this.GetParameters(command, project);

                    connection.Open();

                    command.ExecuteNonQuery();

                }
            }

            return project;
        }

        #endregion

        #region Private Methods

        private Common.Models.Project GetProject(SqlDataReader dataReader)
        {
            return new Common.Models.Project()
            {

                ProjectId = (int)dataReader["ProjectId"],
                CompanyName = (string)dataReader["CompanyName"],
                NumberEligible = (int)dataReader["NumberEligible"],
                NumberInterview = (int)dataReader["NumberInterview"],
                ClassificationId = (int)dataReader["ClassificationId"],
                ClassificationName = (string)dataReader["ClassificationName"],
                SalesExecId = (int)dataReader["SalesExecId"],
                FirstName = (string)dataReader["FirstName"],
                New = (bool)dataReader["New"],
                SystemName = (string)dataReader["SystemName"],
                EnrollmentSystemId = (int)dataReader["EnrollmentSystemId"],
                VbCarrierName = (string)dataReader["VbCarrierName"],
                VbCarrierId = (int)dataReader["VbCarrierId"],
                StartDate = (DateTime)dataReader["StartDate"],
                EndDate = (DateTime)dataReader["EndDate"],
                EnrollmentMethodType = (string)dataReader["EnrollmentMethodType"],
                EnrollmentMethodId = (int)dataReader["EnrollmentMethodId"]
              


            };
        }

        /// <summary>
        /// Converts a Customer into SQL Parameters 
        /// </summary>
        /// <param name="command">An instance of <see cref="SqlCommand"/></param>
        /// <param name="customer">An instance of <see cref="Customer"/></param>
        /// <returns>An instance of <see cref="SqlCommand"/> with parameters added</returns>
        private SqlCommand GetParameters(SqlCommand command, Project project)
        {
            command.Parameters.AddWithValue("@ProjectId", project.ProjectId);
            command.Parameters.AddWithValue("@CompanyName", project.CompanyName);
            command.Parameters.AddWithValue("@NumberEligible", project.NumberEligible);
            command.Parameters.AddWithValue("@NumberInterview", project.NumberInterview);
            command.Parameters.AddWithValue("@ClassificationName", project.ClassificationName);
            command.Parameters.AddWithValue("@ClassificationId", project.ClassificationId);
            command.Parameters.AddWithValue("@New", project.New);
            command.Parameters.AddWithValue("@SystemName", project.SystemName);
            command.Parameters.AddWithValue("@EnrollmentSystemId", project.EnrollmentSystemId);
            command.Parameters.AddWithValue("@VbCarrierName", project.VbCarrierName);
            command.Parameters.AddWithValue("@VbCarrierId", project.VbCarrierId);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", project.EndDate);
            command.Parameters.AddWithValue("@EnrollmentMethodType", project.EnrollmentMethodType);
            command.Parameters.AddWithValue("@EnrollmentMethodId", project.EnrollmentMethodId);
            command.Parameters.AddWithValue("@FirstName", project.FirstName);
            command.Parameters.AddWithValue("@SalesExecId", project.SalesExecId);

            return command;
        }

        ///// <summary>
        ///// Converts a Customer into SQL Parameters 
        ///// </summary>
        ///// <param name="command">An instance of <see cref="SqlCommand"/></param>
        ///// <param name="customer">An instance of <see cref="Customer"/></param>
        ///// <returns>An instance of <see cref="SqlCommand"/> with parameters added</returns>
        //private SqlCommand GetDTOParameters(SqlCommand command, Project project)
        //{
        //    command.Parameters.AddWithValue("@ProjectId", project.ProjectId);
        //    command.Parameters.AddWithValue("@CompanyName", project.CompanyName);
        //    command.Parameters.AddWithValue("@NumberEligible", project.NumberEligible);
        //    command.Parameters.AddWithValue("@NumberInterview", project.NumberInterview);
        //    command.Parameters.AddWithValue("@ClassificationId", project.ClassificationId);
        //    command.Parameters.AddWithValue("@New", project.New);
        //    command.Parameters.AddWithValue("@EnrollmentSystemId", project.EnrollmentSystemId);
        //    command.Parameters.AddWithValue("@VbCarrierId", project.VbCarrierId);
        //    command.Parameters.AddWithValue("@StartDate", project.StartDate);
        //    command.Parameters.AddWithValue("@EndDate", project.EndDate);
        //    command.Parameters.AddWithValue("@EnrollmentMethodId", project.EnrollmentMethodId);
        //    command.Parameters.AddWithValue("@SalesExecId", project.SalesExecId);

        //    return command;
        //}
        #endregion
    }
}

