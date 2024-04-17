using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Entity;
using Services;
using Services.Implementation;
using Services.Interfaces;

namespace EmployeeWebAPI.Controllers
{

    public class EmployeeController : ApiController
    {

        // GET api/employee
        //[HttpGet]

        
        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            IEmployee empref = new EmployeeService();

            employees = empref.GetAllEmployees();

            return employees;
            //return Json(employees, JsonRequestBehavior.AllowGet);
        }




    }
}
