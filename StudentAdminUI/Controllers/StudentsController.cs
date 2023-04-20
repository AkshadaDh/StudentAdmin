using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminUI.DataModels;
using StudentAdminUI.Repositories;

namespace StudentAdminUI.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult >GetAllStudents()
        {
            var students=await studentRepository.GetStudents();
            return Ok(mapper.Map<List<Student>>(students));

           
        }
    }
}
