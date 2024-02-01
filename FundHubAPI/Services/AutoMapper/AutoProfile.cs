using AutoMapper;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.AutoMapper;

public class AutoProfile : Profile
{
    public AutoProfile()
    {
        //model to DTO
        CreateMap<User,UserDTO>();
        CreateMap<Project,ProjectResponseDTO>();
        CreateMap<Donation, DonationResponseDTO>();
        //DTO to Model
        CreateMap<ProjectRequestDTO, Project>();
        CreateMap<DonationResponseDTO, Donation >();
    }
    
}