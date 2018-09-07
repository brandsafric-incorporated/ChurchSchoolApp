using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChurchSchool.API.MapperProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {


            CreateMap<Domain.Entities.Account, Identity.Model.User>()
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
                .ForSourceMember(source=> source.Errors, x=> x.Ignore())                
                .ReverseMap()
                ;

            CreateMap<Identity.Model.User, Domain.Entities.Account>()
                .ForMember(destination => destination.Password, opt => opt.ResolveUsing(source => source.PasswordHash));
        }
    }
}
