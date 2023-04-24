using StudentAdminUI.DomainModels;

namespace StudentAdminUI.Repositories
{
    public interface ITokenHandler
    {
       Task<string> CreateTokenAsync(User user);
    }
}
