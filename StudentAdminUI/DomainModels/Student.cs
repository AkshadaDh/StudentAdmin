using StudentAdminUI.DataModels;

namespace StudentAdminUI.DomainModels
{
    public class Student
    {
        public Guid Id { get; set; }
        
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImgURl { get; set; }
        public Guid GenderId { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }
}
