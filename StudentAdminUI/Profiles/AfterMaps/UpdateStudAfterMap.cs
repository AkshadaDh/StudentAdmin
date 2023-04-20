using AutoMapper;
using StudentAdminUI.DomainModels;

namespace StudentAdminUI.Profiles.AfterMaps
{
    public class UpdateStudAfterMap : IMappingAction<UpdateStudRequest, DataModels.Student>
    {
        public void Process(UpdateStudRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new DataModels.Address()
            {
                CurrentAddress = source.CurrentAddress,
                PostalAddress = source.PostalAddress

            };
        }
    }
}
