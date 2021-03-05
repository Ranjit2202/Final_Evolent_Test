using System;
using System.Web.Http;
using System.Linq;
using CRUDUsingMVC.Repository;
using CRUDUsingMVC.Models;
using System.Collections.Generic;

namespace jQuery_AJAX_WebAPI_CRUD_MVC.Controllers
{

    public class AjaxAPIController : ApiController
    {
        // CRUD Operation Using Store Procedure + REST API

        EmpRepository EmpRepo = new EmpRepository();
        [Route("api/AjaxAPI/InsertContact")]
        [HttpPost]
        public bool InsertContact(Tbl_Contact _Contact)
        {
            EmpRepo.AddEmployee(_Contact);
            return true;
        }

        [Route("api/AjaxAPI/UpdateContact")]
        [HttpPost]
        public bool UpdateContact(Tbl_Contact _Contact)
        {
            EmpRepo.UpdateEmployee(_Contact);
            return true;
        }

        [HttpGet]
        public List<Tbl_Contact>  getContactList()
        {
            return EmpRepo.GetAllEmployees();
        }
        [Route("api/AjaxAPI/DeleteContact")]
        [HttpPost]
        public bool DeleteContact(int id)
        {
            EmpRepo.DeleteEmployee(id);
            return true;
        }
    }
}
