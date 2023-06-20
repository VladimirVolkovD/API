using API.BadVersion.Models;
using API.BusinessObject.Model;
using API.Core;
using Core.Configuration;
using RestSharp;

namespace API.BusinessObject
{
    internal class ProjectService : BaseService
    {
        public string ProjectEndpoint = "/project";
        public string ProjectByCodeEndpoint = "/project/{code}";

        public ProjectService() : base(Configuration.Api.BaseUrl) { }

        public RestResponse GetProjectByCode(string code)
        {
            var request = new RestRequest(ProjectByCodeEndpoint).AddUrlSegment("code", code);

            var response =  apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateProject(CreateProjectModel project)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Post);
            request.AddBody(project);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteProjectByCode(string code)
        {
            var request = new RestRequest(ProjectByCodeEndpoint, Method.Delete).AddUrlSegment("code", code);
            return apiClient.Execute(request);
        }

        public Project GetProjectByCode<ProjectType>(string code) where ProjectType : Project
        {
            var request = new RestRequest(ProjectByCodeEndpoint).AddUrlSegment("code", code);
            return apiClient.Execute<CommonResultResponse<Project>>(request).Result;
        }
    }
}
