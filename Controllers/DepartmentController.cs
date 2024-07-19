using FirstApi.data;
using FirstApi.Dto;
using FirstApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace FirstApi.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var departments = _context.Departments.ToList();
            var departmentDto = departments.Select(e => new DepartmentDto
            {
                DepartmentId = e.DepartmentId,
                DepartmentName = e.DepartmentName,
                CompanyName=e.CompanyName
            }).ToList();

            return Ok(departmentDto);
        }

        [HttpGet("{id}")]
        public ActionResult<DepartmentDto> GetDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(e=>e.DepartmentId == id);
            var dto = new DepartmentDto {
            DepartmentId=department.DepartmentId,
            DepartmentName=department.DepartmentName,
            CompanyName=department.CompanyName
            };
            if (id == 0)
            {
                return BadRequest("0 is not a valid ID.! ");
            }
            if (department == null)
            {
                return NotFound($"No Department found for the ID : {id}");
            }
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<DepartmentDto> Create([FromBody] DepartmentDto departmentDto)
        {
            var department = new Department
            {
                DepartmentId= departmentDto.DepartmentId,
                DepartmentName= departmentDto.DepartmentName,
                CompanyName= departmentDto.CompanyName
            };



            _context.Departments.Add(department);
            _context.SaveChanges();
            return Ok(departmentDto);
        }

        [HttpPut("{id}")]
        public ActionResult<DepartmentDto> Update(int id,[FromBody] DepartmentDto dto)
        {
            if(dto.DepartmentId!=0)
            {
                if(id != dto.DepartmentId)
                {
                    return BadRequest("You can't change the Depatment ID.!");
                }

            }
            var department = _context.Departments.FirstOrDefault(e => e.DepartmentId == id);
            if (department == null)
            {
                return NotFound($"No Department found for the ID : {id}");
            }
            department.DepartmentName = dto.DepartmentName;
            department.CompanyName = dto.CompanyName;
            if (dto.DepartmentId == 0)
            {
                dto.DepartmentId = id;
            }

            _context.Update(department);
            _context.SaveChanges();
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            var department =_context.Departments.FirstOrDefault(e=>e.DepartmentId==id);
            if (id == 0)
            {
                return BadRequest("0 is not a valid ID.! ");
            }
            if (department == null)
            {
                return NotFound($"No Department found for the ID : {id}");
            }
            return NoContent();
        }


        [HttpPatch("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DepartmentDto> PatchDepartment(int id, [FromBody] JsonPatchDocument<DepartmentDto> departmentPatch)
        {
            var department = _context.Departments.FirstOrDefault(e => e.DepartmentId == id);

            if (id == 0)
            {
                return BadRequest("0 is not a valid ID.! ");
            }
            if (department == null)
            {
                return NotFound($"No Department found for the ID : {id}");
            }

            var dto = new DepartmentDto
            {
               DepartmentId = department.DepartmentId,
               DepartmentName = department.DepartmentName,
               CompanyName = department.CompanyName

            };


            departmentPatch.ApplyTo(dto);

            department.DepartmentName = dto.DepartmentName;
                department.CompanyName= dto.CompanyName;
            department.DepartmentId = dto.DepartmentId;
            _context.Update(department);
            _context.SaveChanges();
            return Ok(dto);
        }
    }
}
