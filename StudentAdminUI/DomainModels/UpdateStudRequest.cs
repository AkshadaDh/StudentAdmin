namespace StudentAdminUI.DomainModels
{
    public class UpdateStudRequest
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public Guid GenderId { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PostalAddress { get; set; }
    }
}
