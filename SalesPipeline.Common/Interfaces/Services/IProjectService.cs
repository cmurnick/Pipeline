using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Services
{
    using Models;

    public interface IProjectService
    {
        IList<Project> GetProjectsWithProductsForOneExec();

        IList<Project> GetAllExecProjectsWithProducts();

        Project Save(Project project);

      }
}
