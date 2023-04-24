using StudentAdminUI.DomainModels;

namespace StudentAdminUI.Repositories
{
    public interface IUserInterface
    {
        Task<User> Authenticate(string username, string password);
    }
}
