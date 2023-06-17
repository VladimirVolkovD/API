using API.BadVersion.Models;
using API.BusinessObject.Model;
using Newtonsoft.Json;
using System.Net;

namespace API.BusinessObject.ApiServiceStep
{
    internal class ApiProjectSteps : ProjectService
    {
        public new Project GetProjectByCode(string code)
        {
            var response = base.GetProjectByCode(code);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<Project>>(response.Content).Result;
        }
    }
}
