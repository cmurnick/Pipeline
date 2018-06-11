using SalesPipeline.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SalesPipeline.Common.Interfaces;

namespace SalesPipeline.Service
{
    
    using SalesPipeline.Common.Interfaces;
    using SalesPipeline.Common.Models;
  


    public class ProjectService : IProjectService
    {
        #region Constructors

        public ProjectService(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }
        #endregion

        #region PrivateProperties

        private IProjectRepository _projectRepository { get; }

        #endregion

        #region Public  Methods

        public IList<Common.Models.Project> GetProjectsWithProductsForOneExec(int salesExecId)
        {
            return this._projectRepository.GetProjectsWithProductsForOneExec(salesExecId);
        }

        public IList<Common.Models.Project> GetAllExecProjectsWithProducts()
        {
            return this._projectRepository.GetAllExecProjectsWithProducts();
        }

        public Project Save(Project project)
        {
            if (project.ProjectId == 0)
            {
                return this._projectRepository.Insert(project);
            }
            else
            {
                return this._projectRepository.Update(project);
            }
        }
        #endregion

    }
}

