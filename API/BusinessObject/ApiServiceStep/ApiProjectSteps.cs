using API.BadVersion.Models;
using API.BusinessObject.Model;
using API.Core;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace API.BusinessObject.ApiServiceStep
{
    internal class ApiProjectSteps : ProjectService
    {
        public ApiProjectSteps() : base()
        {
        }

        public new Project GetProjectByCode(string code)
        {
            var response = base.GetProjectByCode(code);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<Project>>(response.Content).Result;
        }

        public new CommonResultResponse<Project> DeleteProjectByCode(string code)
        {
            logger.Info("Delete project by Id: " + code);
            var response = base.DeleteProjectByCode(code);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<Project>>(response.Content);
        }
    }
}
