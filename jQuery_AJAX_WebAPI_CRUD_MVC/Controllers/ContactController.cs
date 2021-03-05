using CRUDUsingMVC.Models;
using CRUDUsingMVC.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace jQuery_AJAX_WebAPI_CRUD_MVC.Controllers
{
    public class ContactController : Controller
    {
        EmpRepository EmpRepo = new EmpRepository();
        HttpClient _client = new HttpClient();
        public ContactController()
        {
            var API_URL = ConfigurationManager.AppSettings["APIURL"].ToString();
            _client.BaseAddress = new Uri(API_URL);
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }
        public async Task<ActionResult> GetContactList()
        {
            // API CALL TO GET CONTACT LIST
            List<Tbl_Contact> lst = new List<Tbl_Contact>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "api/AjaxAPI/getContactList");
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Call API and get the response
                using (var response = await _client.SendAsync(request))
                {
                    // Ensure we have a Success Status Code
                    response.EnsureSuccessStatusCode();
                    // Read Response Content (this will usually be JSON content)
                    var content = await response.Content.ReadAsStringAsync();
                    // Deserialize the JSON into the C# List<Movie> object and return
                    lst = JsonConvert.DeserializeObject<List<Tbl_Contact>>(content);
                }
            }
            catch (Exception ae)
            {
                ae.ToString();
            }
            return View(lst);
        }
        // CREATE CONTACT
        public ActionResult AddContact()
        {
            try
            {
                return View();
            }
            catch (Exception ae) { ae.ToString(); }
            return View();
        }
        // EDIT CONTACT
        public ActionResult Edit(int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    return View(EmpRepo.GetAllEmployees().Find(a => a.Id == id));
                }

            }
            catch (Exception ae) { ae.ToString(); }
            return View();
        }
        // GET CONTACT LIST
        
    }
}