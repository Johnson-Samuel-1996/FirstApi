using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FirstApi.Store;
using FirstApi.Dto;
using System.ComponentModel.DataAnnotations;
using FirstApi.data;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Controllers
{
    [Route("/api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }






        [HttpGet]
        [Route("AllEmployee")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
         var employees = _context.Employees.ToList();
         return Ok(employees);
        }









        [HttpGet]
        [Route("GetEmployeeById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var Employee =_context.Employees.FirstOrDefault(x => x.Id == id);
            if (id == 0)
            {
                return BadRequest();
            }
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }









        [HttpGet ]
        [Route( "GetEmployeeByName")]


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> GetEmployee(string name)
        {
            var Employee = _context.Employees.FirstOrDefault(e => e.Name == name);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }












        [HttpPost]


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> PostEmployee([FromBody]Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();
        }




        [HttpDelete]
        [Route("DeleteById")]


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteById(int id)

        {
            if (id == 0)
            {
                return NotFound();
            }
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            
            if (employee == null)
            {
                return BadRequest();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }












        [HttpDelete]
        [Route("DeleteByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteByName(string name)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Name == name);
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpPut]
        [Route("UpdateById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
            return NoContent();
        }














    }
}
