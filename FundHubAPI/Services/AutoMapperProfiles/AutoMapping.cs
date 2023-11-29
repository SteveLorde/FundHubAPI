using AutoMapper;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace API.Services.AutoMapperProfiles;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<User, UserDTO>();
        CreateMap<Product, ProductDTO>();
        CreateMap<AuthRequestDTO, UserDTO>();
    }
}