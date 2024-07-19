using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FirstApi.Store;
using FirstApi.Dto;
using System.ComponentModel.DataAnnotations;
using FirstApi.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

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
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees()
        {
         var employees = _context.Employees.ToList();
         var dto = employees.Select(e=> new EmployeeDto
            {
                    Name = e.Name,
                    Age = e.Age,
                    DepartmentId = e.DepartmentId
         }
                ).ToList();


            return Ok(dto);
        }




        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> GetEmployee(int id)
        {
            var employee =_context.Employees.FirstOrDefault(x => x.Id == id);
            if (id == 0)
            {
                return BadRequest("0 is not a valid ID.! ");
            }
            if (employee == null)
            {
                return NotFound($"No Employee found for the ID : {id}");
            }
            var dto = new EmployeeDto { 
            Name = employee.Name,
            Age = employee.Age,
            DepartmentId = employee.DepartmentId
            };
            return Ok(dto);
        }



        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> PostEmployee([FromBody]EmployeeDto employeeDto)
        {
            if (employeeDto.DepartmentId == 0)
            {
                return BadRequest("0 is not a valid id.!");
            }
            //if(employeeDto ==null)
            //{
            //    return NotFound($"There is no department with ID : {employeeDto.DepartmentId}");
            //}
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                DepartmentId = employeeDto.DepartmentId

            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employeeDto);
        }


        [HttpDelete("{id}")]
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteById(int id)

        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (id == 0)
            {
                return BadRequest("0 is not a valid ID.! ");
            }
            if (employee == null)
            {
                return NotFound($"No Employee found for the ID : {id}");
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }



        [HttpPut("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> UpdateEmployee(int id,[FromBody] EmployeeDto employeeDto)
        {
            var employee =_context.Employees.FirstOrDefault(e=>e.Id==id);
            if (id == 0)
            {
                return BadRequest("0 is not a valid ID.! ");
            }
            if (employee == null)
            {
                return NotFound($"No Employee found for the ID : {id}");
            }
            employee.Name = employeeDto.Name;
            employee.Age = employeeDto.Age;
            if (employeeDto.DepartmentId != 0)
            {
                employee.DepartmentId = employeeDto.DepartmentId;
            }
            if (employeeDto.DepartmentId == 0)
            {
                employeeDto.DepartmentId = employee.DepartmentId;
            }
                _context.Update(employee);
            _context.SaveChanges();
            return Ok(employeeDto);
        }




        [HttpPatch("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> PatchEmployee(int id, [FromBody] JsonPatchDocument<EmployeeDto> employeePatch)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (id == 0)
            {
                return BadRequest("0 is not a valid ID.! ");
            }
            if (employee == null)
            {
                return NotFound($"No Employee found for the ID : {id}");
            }

            var dto = new EmployeeDto
            {
                Name = employee.Name,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId
            };
           
           
            employeePatch.ApplyTo(dto);

            employee.Name = dto.Name;
            employee.Age = dto.Age;
            employee.DepartmentId = dto.DepartmentId;
            _context.Update(employee);
            _context.SaveChanges();
            return Ok(dto);
        }

    }
}
