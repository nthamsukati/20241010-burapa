using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace IbarnAPI.Common
{
    public class CommonService : ICommonService
    {
        public CommonService() { 
        }

        public async Task<string> GetIBan(string countryCode)
        {
            string url = "https://randommer.io/api/Finance/Iban/" + countryCode;

            using (HttpClient client = new HttpClient())
            {
                // Set the correct header for the API key
                client.DefaultRequestHeaders.Add("x-Api-Key", "85325fb1558c4bd0abf2ad74d0beca37");
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Read the content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // responseBody = getHashSha256(responseBody);
                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    return $"Request error: {e.Message}";
                }
            }
        }

        public async Task<decimal> FeeCalculator(decimal depositMoney)
        {
            return depositMoney = depositMoney * 0.001m;

        }

        public async Task<string> ValidateIBan(string IBanCode)
        {
            // assume it's have endpoint
            string url = "https://api.ibanapi.com/v1/validate/" + IBanCode + "?api_key=591b7015a954e0d18e61ebc062bc338127e33322\r\n";

            using (HttpClient client = new HttpClient())
            {
                // Set the correct header for the API key
                client.DefaultRequestHeaders.Add("x-Api-Key", "85325fb1558c4bd0abf2ad74d0beca37");

                var requestBody = new
                {
                    IBanCode = IBanCode,
                };

                try
                {
                    string json = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    // Read the content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // responseBody = getHashSha256(responseBody);
                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    return $"Request error: {e.Message}";
                }
            }
        }
    }

}
