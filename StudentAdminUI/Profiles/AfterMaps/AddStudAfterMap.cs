using AutoMapper;
using StudentAdminUI.DomainModels;

namespace StudentAdminUI.Profiles.AfterMaps
{
    public class AddStudAfterMap : IMappingAction<AddStudRequest, DataModels.Student>
    {
        public void Process(AddStudRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address =new DataModels.Address()
            {
                Id = Guid.NewGuid(),
                CurrentAddress = source.CurrentAddress,
                PostalAddress = source.PostalAddress

            };
        }
    }
}
