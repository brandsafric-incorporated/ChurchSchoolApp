using AutoMapper;
using System.Linq;

namespace ChurchSchool.API.MapperProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Domain.Entities.Identity.Account, Domain.Entities.Identity.User>()
                .ForMember(destination => destination.PasswordHash, opt => opt.ResolveUsing(source => source.Password))
                .ForMember(destination => destination.PersonId, opt => opt.ResolveUsing(source => source.PersonId))
                .ForMember(destination => destination.UserName, opt => opt.ResolveUsing(source => source.UserName))
                .ForMember(destinationMember => destinationMember.AccessFailedCount, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.Email, opt => opt.ResolveUsing(source => source.Email))
                .ForMember(destinationMember => destinationMember.EmailConfirmed, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.Id, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.IsDisabled, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.LockoutEnabled, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.LockoutEnd, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.NormalizedEmail, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.NormalizedUserName, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.PhoneNumber, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.SecurityStamp, opt => opt.Ignore())
                .ForMember(destinationMember => destinationMember.TwoFactorEnabled, opt => opt.Ignore())
                .ForSourceMember(source => source.Errors, x => x.Ignore())
                .ReverseMap()
                ;

            CreateMap<Domain.Entities.Identity.User, Domain.Entities.Identity.Account>()
                .ForMember(destination => destination.Password, opt => opt.ResolveUsing(source => source.PasswordHash));


            CreateMap<Domain.Entities.Course, Application.Models.CourseConsolidatedModel>()
                .ForMember(destination => destination.Id, opt => opt.ResolveUsing(source => source.Id))
                .ForMember(destination => destination.Name, opt => opt.ResolveUsing(source => source.Name))
                .ForMember(destination => destination.Description, opt => opt.ResolveUsing(source => source.Description))
                .ForMember(destination => destination.IsActive, opt => opt.ResolveUsing(source => source.isActive))
                .ForMember(destination => destination.Subjects, opt => opt.ResolveUsing(source => source?.CurrentConfiguration
                                                                                                        ?.ConfigCurriculumns
                                                                                                        ?.FirstOrDefault(x => x.IsActive)
                                                                                                        ?.Curriculum
                                                                                                        ?.Curriculum_Subjects
                                                                                                        .Select(x => x.Subject)))
                .ForMember(destination => destination.Documents, opt => opt.ResolveUsing(source => source?.CurrentConfiguration
                                                                                                         ?.EnrollDocuments
                                                                                                         ?.Select(x=> x.Type)))
                .ReverseMap()
                ;
        }
    }
}

