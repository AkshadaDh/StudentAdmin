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

        public async Task<Student> GetStudentAsync(Guid studentId)
        {          

            return await context.Student
                .Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == studentId);        

        }

        public async Task<bool> Exists(Guid studentId)
        {
           return await context.Student.AnyAsync(x => x.Id == studentId);
        }
       public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingstud=await GetStudentAsync(studentId);
            if (existingstud != null)
            {
                existingstud.FName = request.FName;
                existingstud.LName = request.LName;
                existingstud.DOB = request.DOB;
                existingstud.Email = request.Email;
                existingstud.Mobile = request.Mobile;
                existingstud.GenderId = request.GenderId;
                existingstud.Address.CurrentAddress = request.Address.CurrentAddress;
                existingstud.Address.PostalAddress= request.Address.PostalAddress;
                
                await context.SaveChangesAsync();
                return existingstud;
            }
            return null;
        }

        public async Task<Student> DeleteStudentAsync(Guid studentId, Student request)
    }
}
