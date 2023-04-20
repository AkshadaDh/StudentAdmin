namespace StudentAdminUI.DomainModels
{
    public class Address
    {
       public Guid Id { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PostalAddress { get; set; }
        public Guid StudentId { get; set; }
    }
}
