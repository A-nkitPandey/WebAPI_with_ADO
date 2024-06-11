using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_with_ADO.Models;

namespace WebAPI_with_ADO.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        ContextDbcs db = new ContextDbcs();

        [HttpGet]
        [ActionName("GetEmp")]
        public IEnumerable<Employee> Get()
        {
            return db.GetEmp().ToList();
        }

        //[HttpGet]
        //[ActionName("GetEmpByID")]
        public IEnumerable<Employee> Get(int id)
        {
            db.GetEmp().Where(Model => Model.EmployeeId == id).FirstOrDefault();
            return default;
        }


        // POST api/values
        public void Post(Employee obj)
        {
            if (ModelState.IsValid == true)
            {
                db.Add(obj);
            }
        }

        // PUT api/values/5
        public void Put(int id, Employee obj)
        {
            if (ModelState.IsValid == true)
            {
                db.Update(id, obj);
            }
        }

        // DELETE api/values/5
        public void Delete(int Id)
        {
            if (ModelState.IsValid == true)
            {
                db.Delete(Id);
            }
        }
    }
}
