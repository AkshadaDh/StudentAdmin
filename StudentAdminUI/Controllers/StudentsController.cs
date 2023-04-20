using AutoMapper;
using Azure.Core;
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
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudents();
            return Ok(mapper.Map<List<Student>>(students));


        }

        [HttpGet]

        [Route("[controller]/{studentId:guid}")]
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
            else
            {
                return NotFound();
            }
            return null;
        }
    }
}
