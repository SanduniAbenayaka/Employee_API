using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Welcome" };
        }

        // GET 
        //api/values/GetAllEmployees

        [HttpGet("GetAllEmployees")]
        public ActionResult<IEnumerable<Employee>> GetallEmployees()
        {
            return EmployeeList.Emp;
        }

        // GET 
        //api/values/GetEmployee/1

        [HttpGet("GetEmployee/{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            return EmployeeList.Emp.Find(item=>item.id==id);
        }

        // GET 
        //api/values/GetEmp/sandu

        [HttpGet("GetEmp/{name}")]
        public ActionResult<Employee> GetEmp(string name)
        {
            List<Employee> list1 = new List<Employee>();
            var result =( from emp in EmployeeList.Emp where emp.name == name select emp).ToList();
            foreach (Employee e in result)
            {
                list1.Add(e);
            }
            return Ok(list1);
        }

        // GET 
        //api/values/GetEmp/town

        [HttpGet("GetEmpAdd/{address}")]
        public ActionResult<Employee> GetEmpAdd(string address)
        {
            List<Employee> list2 = new List<Employee>();
            var result = (from emp in EmployeeList.Emp where emp.address == address select emp).ToList();
            foreach (Employee e in result)
            {
                list2.Add(e);
            }
            return Ok(list2);
        }

        // POST 
        //api/values/PostEmployee

        [HttpPost("PostEmployee")]
        public string PostEmployee ([FromBody] Employee value)
        {
            var val = EmployeeList.Emp.Find(item => item.id == value.id);
            if (val==null)
            {
                EmployeeList.Emp.Add(value);
                return " Add successfully";
            }
            
            else
            {
                return "Employee already exist. ";
            }
           
        }
        // PUT 
        //api/values/UpdateEmployee/1

        [HttpPut("UpdateEmployee/{id}")]
        public string Put(int id, [FromBody] Employee value)
        {
            try
            {
                var updateemp = EmployeeList.Emp.Find(item => item.id == id);
                updateemp.name = value.name;
                updateemp.address = value.address;
                return "Updated successfully";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Id not found";
            }


        }

        // DELETE 
       //api/values/DeleteEmployee/1

        [HttpDelete("DeleteEmployee/{id}")]
        public string Delete(int id)
        {
             var deleteemp = EmployeeList.Emp.Find(item => item.id == id);
                if (deleteemp != null)
                {
                    EmployeeList.Emp.Remove(deleteemp);
                    return "Deleted successfully";
                }
                else
                {
                    return "Id not found";
                }
        }
 
    }

    public class Employee
    {
        public int id;
        public string name;
        public string address;

    }

    public static class EmployeeList
    {
       public static  List<Employee> Emp = new List<Employee>();
    }
}
