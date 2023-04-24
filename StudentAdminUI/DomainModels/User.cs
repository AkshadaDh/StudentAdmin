namespace StudentAdminUI.DomainModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmailId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
