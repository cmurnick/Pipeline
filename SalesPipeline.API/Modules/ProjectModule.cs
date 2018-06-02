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
                "/{salesexecid}",
                parameters =>
                {
                    try
                    {
                        var salesExecId = parameters.salesexecid;
                        var projects = this._projectService.GetProjectsWithProductsForOneExec(salesExecId);
                        return this.GetJsonResponse(projects);
                    }
                    catch (System.Exception e)
                    {
                        return this.Negotiate.WithStatusCode(Nancy.HttpStatusCode.InternalServerError);
                    }
                });

            this.Get(
                "/leadershipreport",
                parameters =>
                {
                    try
                    {
                        var projects = this._projectService.GetAllExecProjectsWithProducts();
                        return this.GetJsonResponse(projects);

                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(Nancy.HttpStatusCode.InternalServerError);
                    }
                });
        }


        private IProjectService _projectService { get; }
    }
}

