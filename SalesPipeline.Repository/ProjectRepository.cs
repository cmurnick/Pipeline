﻿using System;
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

        public IList<Project> GetProjectsWithProductsForOneExec(int salesExecId)
        {
            var sql = @"Select  
                            p.ProjectId, 
                            p.CompanyName,
                            p.NumberEligible,
                            p.NumberInterview,
                            p.ClassificationId,
                            p.SalesExecId,
                            p.New,
                            p.EnrollmentSystemId,
                            p.VbCarrierId,
                            p.StartDate,
                            p.EndDate,
                            p.EnrollmentMethodId,
                            n.*
                                
                            FROM Project p
                                join ProductProject j on j.ProjectId = p.ProjectId
                                join Product n on n.ProductId = j.ProductId
                            WHERE p.SalesExecId = @SalesExecId 
                            ORDER By p.ClassificationId";

            var projects = new List<Project>();

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
                                var project = GetProjects(dataReader);
                                var existingProject = projects.FirstOrDefault(x => x.ProjectId == project.ProjectId);
                                if (existingProject == null)
                                {
                                    projects.Add(project);
                                    existingProject = project;
                                }

                                existingProject.Product.Add(new Product
                                {
                                    ProductId = (int) dataReader["productId"],
                                    ProductName = (string) dataReader["ProductName"]
                                });

                            }
                        }
                    }
                }
            return projects;
        }

        //public IList<Project> GetAllExecProjectsWithProducts()
        //{ }

        #endregion

        #region Private Methods

        private Project GetProjects(SqlDataReader dataReader)
        {
            return new Project()
            {

                ProjectId = (int)dataReader["ProjectId"],
                CompanyName = (string)dataReader["CompanyName"],
                NumberEligible = (int)dataReader["NumberEligible"],
                NumberInterview = (int)dataReader["NumberInterview"],
                ClassificationId = (int)dataReader["ClassificationId"],
                SalesExecId = (int)dataReader["SalesExecId"],
                New = (bool)dataReader["New"],
                EnrollmentSystemId = (int)dataReader["EnrollmentSystemId"],
                VBCarrierId = (int)dataReader["VbCarrierId"],
                StartDate = (DateTime)dataReader["StartDate"],
                EndDate = (DateTime)dataReader["EndDate"],
                EnrollmentMethodId = (int)dataReader["EnrollmentMethodId"],


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
            command.Parameters.AddWithValue("@SalesExecId", project.SalesExecId);
            
            return command;
        }


        #endregion
    }
}

