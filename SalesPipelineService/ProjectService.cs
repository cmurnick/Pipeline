using SalesPipeline.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SalesPipeline.Common.Interfaces;

namespace SalesPipeline.Service
{
    using System.Linq;
    using SalesPipeline.Common.Interfaces;
    using SalesPipeline.Common.Models;
  


    public class ProjectService : IProjectService
    {
        #region Constructors

        public ProjectService(IProjectRepository projectRepository, IProductService productService)
        {
            this._projectRepository = projectRepository;
            this._productService = productService;
        }
        #endregion

        #region PrivateProperties

        private IProjectRepository _projectRepository { get; }

        private IProductService _productService { get; }

        #endregion

        #region Public  Methods

        public IList<Project> GetProjectsWithProductsForOneExec(int salesExecId)
        {
            
            var projects = this._projectRepository.GetProjectsWithProductsForOneExec(salesExecId);

            foreach (var project in projects)
            {
                project.Products = this._productService.GetForProject(project.ProjectId).ToList();
            }
            return projects;
        }

        public IList<Project> GetAllExecProjectsWithProducts()
        {
            var projects = this._projectRepository.GetAllExecProjectsWithProducts();

            foreach(var project in projects)
            {
                project.Products = this._productService.GetForProject(project.ProjectId).ToList();
            }
            return projects;
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

