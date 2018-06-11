using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces.Services
{

    using Models;
  


    public interface IProjectService
    {
        IList<Models.Project> GetProjectsWithProductsForOneExec(int salesExecId);

        IList<Models.Project> GetAllExecProjectsWithProducts();

        Project Save(Project project);

      }
}
