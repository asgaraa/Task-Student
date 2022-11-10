using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Student;
using ServiceLayer.DTOs.StudentDetail;
using ServiceLayer.Services.Interfaces;
using System.Data;
using System.Security.Claims;

namespace Api.Controllers
{
 
    public class StudentController : BaseController
    {
        private readonly IStudentService _service;
        
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateStudent")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Create([FromBody] StudentDto studentDto)
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            studentDto.UserId = UserId;
            await _service.CreateAsync( studentDto);
            return Ok();
        }


        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        [Route("UpdateStudent")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Update([FromBody] StudentEditDto studenEditDto)
        {
            await _service.UpdateAsync(studenEditDto.Id, studenEditDto);
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllStudents")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetAll()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var identity = this.HttpContext.User.Identities.FirstOrDefault();
            var role = identity.Claims.FirstOrDefault(
             c => c.Type == ClaimTypes.Role)?.Value;
            if (role == "SuperAdmin")
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            else
            {
                var result = await _service.GetAllWithAdminAsync(UserId);
                return Ok(result);
                
            }
            


        }
    }
}
