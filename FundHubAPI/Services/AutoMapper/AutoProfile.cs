using AutoMapper;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.AutoMapper;

public class AutoProfile : Profile
{
    public AutoProfile()
    {
        CreateMap<UserDTO,User>();
        CreateMap<ProjectDTO,Project>();
    }
    
}