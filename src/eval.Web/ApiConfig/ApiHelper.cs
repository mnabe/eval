using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eval.Web.ApiConfig
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static IConfiguration Config { get; set; }
        public static void InitializeClient()
        {
            Config = ConfigurationManager();
            string ApiURL = Config.GetValue<string>("ApiURL");
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(ApiURL); //https://localhost:44393/api/Match/
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        static IConfiguration ConfigurationManager()
        {
            Config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSecrets.json")
                    .Build();
            return Config;
        }
    }
}
