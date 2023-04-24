using StudentAdminUI.DomainModels;

namespace StudentAdminUI.Repositories
{
    public class StaticUserRepository : IUserInterface
    {

        private List<User> users = new List<User>()
        {
            new User()
            {
                FName="Read Only", LName="User",EmailId="readonly@user.com",
                Id=Guid.NewGuid(),Username="readonly@user.com",Password="readonly@user",
                Roles=new List<string>{"reader"}

            },
             new User()
            {
                FName="Read Write", LName="User",EmailId="readwrite@user.com",
                Id=Guid.NewGuid(),Username="readwrite@user.com",Password="readwrite@user",
                Roles=new List<string>{"reader", "writer" }

            }
        };
        public async Task<User> Authenticate(string username, string password)
        {
            var user=users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) 
            && x.Password.Equals(password));

            if (user != null)
            {
                return user;
            }
            return user;
        }
    }
}
