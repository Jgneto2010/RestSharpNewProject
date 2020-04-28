using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExportSupraCore.Services
{
    public static class ConfigurationService
    {
        public static IRestResponse Configuration(string url)
        {
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("CGPLAN@dnit.gov.br", "123456");

            var request = new RestRequest(Method.GET)
                .AddHeader("content-type", "application/json")
                .AddHeader("token",
                           "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyIjoiY2dwbGFuQGRuaXQuZ292LmJyIiwicGFzcyI6IjEyMzQ1NiJ9.hB8Vp11SLar3n4pCsczdZ4FSsF11LHoarJxgEt5Kl-A");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            return client.Execute(request);
        }
    }
}
