using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StudentAdminUI.DataModels;
using StudentAdminUI.DomainModels;
using StudentAdminUI.Repositories;
using Student = StudentAdminUI.DomainModels.Student;

namespace StudentAdminUI.Controllers
{
    [ApiController]
    
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet("api/Students/GetAllStudents")]
        [EnableCors("Policy11")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudents();
            return Ok(students);


        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        [Route("[controller]/{studentId:guid}"),ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //fetch Student
            var student = await studentRepository.GetStudentAsync(studentId);

            //return Student
            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
             
        }

        [HttpPut]
        [Authorize(Roles = "writer")]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudRequest request)
        {
            if (await studentRepository.Exists(studentId))
            {
                //update details
                var UpdatedStud = await studentRepository.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));
                if (UpdatedStud != null)
                {
                    return Ok(mapper.Map<Student>(UpdatedStud));
                }

            }
            
                return NotFound();
            
        }


        [HttpDelete]
        [Authorize(Roles = "writer")]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if(await studentRepository.Exists(studentId))
            {
                var stud=await studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(stud));

            }
            return NotFound();


        }

        [HttpPost]
        [Route("[controller]/Add")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudRequest request)
        {
            var stud=await studentRepository.AddStudent(mapper.Map<DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = stud.Id },
                mapper.Map<Student>(stud));
        }

    }
}
