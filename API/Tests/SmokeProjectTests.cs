using API.BusinessObject;
using API.BusinessObject.ApiServiceStep;
using API.BusinessObject.Model;
using API.Tests;
using Bogus;
using NUnit.Framework;
using System.Net;

namespace API
{
    internal class SmokeProjectTests : ApiAuthTests
    {      
        [Test]
        public void GetProjectById()
        {
            var projectCode = "359704112";
            var response = projectService.GetProjectByCode(projectCode);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void GetProjectById_RespenseModel()
        {
            var projectCode = "359704112";

            var project = apiProjectSteps.GetProjectByCode(projectCode);

            Console.WriteLine(project.Title);
        }

      
        
    }
}
