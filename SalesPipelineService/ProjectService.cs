using SalesPipeline.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IList<Project> GetProjectsWithProductsForOneExec(int salesExecId)
        {
            return this._projectRepository.GetProjectsWithProductsForOneExec(salesExecId);
        }

        #endregion

    }
}

