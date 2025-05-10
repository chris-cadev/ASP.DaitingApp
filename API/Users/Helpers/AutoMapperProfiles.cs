using System;
using API.Accounts.Entities;
using API.Accounts.Extensions;
using API.Users.DTOs;
using AutoMapper;

namespace API.Users.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, UserDto>()
        .ForMember(
            d => d.Age,
            o => o.MapFrom(
                s => s.DateOfBirth.CalculateAge()
            )
        )
        .ForMember(
            d => d.PhotoUrl,
            o => o.MapFrom(
                s => s.Photos.FirstOrDefault(
                    x => x.IsMain
                )!.Url
            )
        );
        CreateMap<Photo, PhotoDto>();
    }

}
