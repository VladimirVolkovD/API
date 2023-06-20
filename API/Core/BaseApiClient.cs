using NLog;
using RestSharp;

namespace API.Core
{
    internal class BaseApiClient
    {
        private RestClient restClient;

        protected Logger logger = LogManager.GetCurrentClassLogger();

        public BaseApiClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = false
            };

            restClient = new RestClient(option);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public void AddToken(string token)
        {
            restClient.AddDefaultHeader("Token", token);
        }

        public RestResponse Execute(RestRequest request)
        {
            logger.Info(request);
            var response = restClient.Execute(request);
            logger.Info(response.Content.Normalize());
            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            logger.Info(request.Resource);
            var response = restClient.Execute<T>(request);
            logger.Info(response.Content.Normalize());
            return response.Data;
        }
    }
}
