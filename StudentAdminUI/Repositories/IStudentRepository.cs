using StudentAdminUI.DataModels;

namespace StudentAdminUI.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
    }
}
