using Core.Configuration;
using NLog;

namespace API.Core
{
    internal class BaseService
    {
        protected BaseApiClient apiClient;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        public BaseService(string url)
        {
            this.apiClient = new BaseApiClient(url);
            apiClient.AddToken(Configuration.Api.Token);
        }
    }
}
