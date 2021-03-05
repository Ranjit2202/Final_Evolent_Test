using CRUDUsingMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Repository
{
    public class ContactClient
    {
        private readonly HttpClient _client;
        public ContactClient(HttpClient client)
        {
            var URL = "test";
            _client = client;
            _client.BaseAddress = new Uri(URL);
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public async Task<List<Tbl_Contact>> checkAppraisalReOpenEmployee()
        {
            try
            {
                // Set the request message
                var request = new HttpRequestMessage(HttpMethod.Get, "api/ContactAPI/getContactList");
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Call API and get the response
                using (var response = await _client.SendAsync(request))
                {
                    // Ensure we have a Success Status Code
                    response.EnsureSuccessStatusCode();

                    // Read Response Content (this will usually be JSON content)
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON into the C# List<Movie> object and return
                    return JsonConvert.DeserializeObject<List<Tbl_Contact>>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


