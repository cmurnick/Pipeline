using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces
{
    
    using Models;
    


    public interface IProjectRepository
    {
        IList<Models.Project> GetAllExecProjectsWithProducts();

        Project Insert(Project project);

        Project Update(Project project);

        IList<Models.Project> GetProjectsWithProductsForOneExec(int salesExecId);
    }
    
}
