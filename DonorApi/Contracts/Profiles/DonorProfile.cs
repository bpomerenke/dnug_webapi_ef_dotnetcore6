using AutoMapper;
using DonorApi.Models;

namespace DonorApi.Contracts.Profiles;

public class DonorProfile : Profile
{
    public DonorProfile()
    {
        CreateMap<Donor, DonorDto>()
            .ForMember(dest => dest.AdditionalInfo,
                opt => opt.MapFrom(src => string.Join(",", src.Designations.Select(d => d.Label))))
            .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.CurrentDriveStatus));

    }
}