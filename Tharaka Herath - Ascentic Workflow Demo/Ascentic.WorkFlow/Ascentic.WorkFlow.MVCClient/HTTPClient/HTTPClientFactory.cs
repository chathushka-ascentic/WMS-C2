using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Ascentic.WorkFlow.MVCClient.HTTPClient
{
    public class HTTPClientFactory
    {
        /// <summary>
        /// Create a HttpClient on demand.
        /// </summary>
        /// <returns></returns>
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WorkFlowAPIBaseURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}