using StudentAdminUI.DataModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentAdminUI.Repositories
{
    public class SqlStudentRepository:IStudentRepository
    {
        private  ApplicationDbContext context;
        public SqlStudentRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Student>> GetStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return students;
        }
    }
}
