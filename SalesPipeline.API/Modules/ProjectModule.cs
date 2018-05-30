using SalesPipeline.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Nancy;

    public class ProjectModule : BaseModule
    {

        public ProjectModule(IProjectService projectService) : base("/projects")
        {
            this._projectService = projectService;
            this.Get(
                "/",
                parameters =>
                {
                    try
                    {
                        //var salesExecId = parameters.salesExecId;
                        var projects = this._projectService.GetProjectsWithProductsForOneExec(2);
                        return this.GetJsonResponse(projects);
                    }
                    catch (System.Exception e)
                    {
                        return this.Negotiate.WithStatusCode(Nancy.HttpStatusCode.InternalServerError);
                    }
                });
        }


        private IProjectService _projectService { get; }
    }
}

