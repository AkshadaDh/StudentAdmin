using AutoMapper;
using Datamodels=StudentAdminUI.DataModels;
using StudentAdminUI.DomainModels;
using StudentAdminUI.Profiles.AfterMaps;

namespace StudentAdminUI.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Datamodels.Student, Student>()
            .ReverseMap();

            CreateMap<Datamodels.Gender, Gender>()
            .ReverseMap();

            CreateMap<Datamodels.Address, Address>()
            .ReverseMap();

            CreateMap<UpdateStudRequest, Datamodels.Student>()
                .AfterMap<UpdateStudAfterMap>();
        }

    }
}
