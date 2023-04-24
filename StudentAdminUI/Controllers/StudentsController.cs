using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudents();
            return Ok(mapper.Map<List<Student>>(students));


        }

        [HttpGet]
        [Authorize]
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
        [Route("[controller]/{studentId:guid}")]
        [Authorize]
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
        [Route("[controller]/{studentId:guid}")]
        [Authorize]
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
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudRequest request)
        {
            var stud=await studentRepository.AddStudent(mapper.Map<DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = stud.Id },
                mapper.Map<Student>(stud));
        }

    }
}
