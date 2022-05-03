using AutoMapper;
using DonorApi.Models;

namespace DonorApi.Contracts.Profiles;

public class DonorProfile : Profile
{
    public DonorProfile()
    {
        CreateMap<Donor, DonorDto>()
            .ForMember(dest => dest.Designations, opt => opt.MapFrom(src => string.Join(",", src.Designations.Select(d => d.Label))));
        
        
    }
}