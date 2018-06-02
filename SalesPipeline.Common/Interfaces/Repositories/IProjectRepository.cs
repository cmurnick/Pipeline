using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Interfaces
{
    using Models;

 
    public interface IProjectRepository
    {
        IList<Project> GetAllExecProjectsWithProducts();

        //Project Insert(Project project);

        //Project Update(Project project);

        IList<Project> GetProjectsWithProductsForOneExec(int SalesExecId);
    }
    
}
