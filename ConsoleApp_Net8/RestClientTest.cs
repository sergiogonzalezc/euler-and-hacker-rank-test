using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ConsoleApp_Net8;

public class RestAPI
{
    public async Task<string> GetRestData()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {

                //Write code here to query the REST endpoint "https://jsonplaceholder.typicode.com/todos/1" and print the result to the console
                //Please wrap your code in a try .. catch and if any errors occur print the error stack to the console
                client.Timeout = TimeSpan.FromMinutes(1);

                string shortUrl = "/todos/1";
                string baseUrl = @"https://jsonplaceholder.typicode.com";
                string url = string.Format("{0}{1}", baseUrl, shortUrl);

                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                HttpResponseMessage response = null;

                bool isPost = false;
                if (isPost)
                {
                    object? bodyExample = "demo de body";
                    string jsonObject = string.Empty;
                    jsonObject = JsonConvert.SerializeObject(bodyExample);
                    request.Content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    response = await client.PostAsync(url, request.Content);
                }
                else
                    response = await client.GetAsync(url);

                string content = await response.Content.ReadAsStringAsync();

                return content;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
