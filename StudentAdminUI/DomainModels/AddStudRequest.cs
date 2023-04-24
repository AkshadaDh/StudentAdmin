namespace StudentAdminUI.DomainModels
{
    public class AddStudRequest
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImgURl { get; set; }
        public Guid GenderId { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PostalAddress { get; set; }
    }
}
