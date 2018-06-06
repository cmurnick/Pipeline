using SalesPipeline.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPipeline.API.Modules
{
    using Common.Models;
    using Nancy;
    using Nancy.ModelBinding;
    using System.Linq;
    using System;
    using Newtonsoft.Json.Serialization;

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
                        
                        var projects = this._projectService.GetProjectsWithProductsForOneExec();
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

            this.Post(
                "/",
                parameters =>
                {
                    try
                    {
                        var project = this.Bind<Project>();

                        var serviceReturn = new ServiceReturn<Project>();

                        serviceReturn.Data = this._projectService.Save(project);

                        serviceReturn.Success = true;

                        return this.GetJsonResponse(serviceReturn);
                    }
                    catch (Exception e)
                    {
                        return this.Negotiate.WithStatusCode(HttpStatusCode.InternalServerError);
                    }
                });


        }


        private IProjectService _projectService { get; }
    }
}

