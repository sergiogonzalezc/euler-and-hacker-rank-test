using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Net8;

public class RestAPI
{
    public async Task GetRestData()
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

                HttpResponseMessage output = await client.GetAsync(url);
            }
        }
        catch (Exception ex)
        {
            var message = ex.Message;
        }
    }
}
