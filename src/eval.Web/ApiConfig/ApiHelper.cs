﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eval.Web.ApiConfig
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://evalwebmvc.azurewebsites.net/matchindex/api/Match"); //https://localhost:44393/api/Match/ //https://evalwebmvc.azurewebsites.net/matchindex
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
