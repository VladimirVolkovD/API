using API.BusinessObject;
using API.BusinessObject.ApiServiceStep;
using API.BusinessObject.Model;
using API.Tests;
using Bogus;
using NUnit.Framework;
using System.Net;

namespace API
{
    internal class CreateProjectTests : ApiAuthTests
    {      

        [Test]
        public void CreateProject()
        {
            var projectModel = new CreateProjectModel()
            {
                Title = "Test",
                Code = $"{new Faker().Finance.RoutingNumber()}",
                Access = "none"
            };
             
            var projectResponse = projectService.CreateProject(projectModel);
            ProjectHandler.AddProjectCodeForDelete(projectModel.Code);

            Console.WriteLine(projectResponse.Content);
            Assert.IsTrue(projectResponse.StatusCode.Equals(HttpStatusCode.OK));
          
        }

        [TearDown]
        public void TearDown()
        {
            ProjectHandler.DeleteProjects();
        }
    }
}
