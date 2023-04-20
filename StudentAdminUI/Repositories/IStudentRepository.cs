using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StudentAdminUI.DataModels;

namespace StudentAdminUI.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentAsync(Guid studentId);

        Task<Student> UpdateStudent(Guid studentId,Student request);

        Task<bool> Exists(Guid studentId);
    }
}
