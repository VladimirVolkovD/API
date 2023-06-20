using API.BusinessObject;
using API.BusinessObject.ApiServiceStep;
using API.BusinessObject.Model;
using API.Tests;
using Bogus;
using NUnit.Framework;
using System.Net;

namespace API
{
    internal class DeleteProjectTests : ApiAuthTests
    {      
        string code;

        [SetUp]
        public void SetUpProject()
        {
            var projectModel = new CreateProjectModel()
            {
                Title = "Test",
                Code = $"{new Faker().Finance.RoutingNumber()}",
                Access = "none"
            };

         
            apiProjectSteps.CreateProject(projectModel);

            code = projectModel.Code;
        }

        [Test]
        [Category("Smoke")]
        public void DeleteProjectById_RespenseModel()
        {
            var projectCode = code;

            var project = apiProjectSteps.DeleteProjectByCode(projectCode);


            Console.WriteLine(project.Status);
        }
               
    }
}
