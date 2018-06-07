using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Services
{
    using Models;

    public interface IProjectService
    {
        IList<Project> GetProjectsWithProductsForOneExec(int salesExecId);

        IList<Project> GetAllExecProjectsWithProducts();

        Project Save(Project project);

      }
}
