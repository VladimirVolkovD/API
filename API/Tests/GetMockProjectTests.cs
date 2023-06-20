using NUnit.Framework;
using RestSharp;
using RichardSzalay.MockHttp;

namespace API.Tests
{
    internal class GetMockProjectTests
    {
        [Test]
        public void GetMockProject()
        {
            var mock = new MockHttpMessageHandler();

            mock.When("http://qaseio/api/v8/project/*")
                .Respond("application/json", "{'Title': 'JOHSDF'}");

            var client = new RestClient(new RestClientOptions { ConfigureMessageHandler = _ => mock });

            var request = new RestRequest("http://qaseio/api/v8/project/2");
            var response = client.Get(request);

            Console.WriteLine(response.Content);

        }
    }
}
