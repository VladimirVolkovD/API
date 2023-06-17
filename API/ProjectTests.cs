using API.BusinessObject;
using API.BusinessObject.ApiServiceStep;
using API.BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class ProjectTests : BaseApiTest
    {
        protected ProjectService projectService;
        protected ApiProjectSteps apiProjectSteps;

        [OneTimeSetUp]
        public void InitialService()
        {
            projectService = new ProjectService();
            apiProjectSteps = new ApiProjectSteps();
        }

        [Test]
        public void GetProjectById()
        {
            var projectCode = "AQA1";

            var response = projectService.GetProjectByCode(projectCode);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void GetProjectById_RespenseModel()
        {
            var projectCode = "AQA1";

            var project = apiProjectSteps.GetProjectByCode(projectCode);

            Console.WriteLine(project.Title);
        }


        [Test]
        public void CreateProject()
        {
            var projectModel = new CreateProjectModel()
            {
                Title = "Test",
                Code = "ghjfлоghj",
                Access = "none"
            };

            var projectResponse = projectService.CreateProject(projectModel);
            Assert.IsTrue(projectResponse.StatusCode.Equals(HttpStatusCode.OK));
            Console.WriteLine(projectResponse.Content);
        }
    }
}
