using AutoMapper;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.JWT.DTO;

namespace FundHubAPI.Services.AutoMapper;

public class AutoProfile : Profile
{
    public AutoProfile()
    {
        //model to DTO
        CreateMap<User,UserDTO>();
        CreateMap<Project,ProjectResponseDTO>();
        CreateMap<Donation, DonationResponseDTO>();
        CreateMap<News,NewsResponseDTO>();
        CreateMap<User,JWTRequestDTO>();

        //DTO to Model
        CreateMap<ProjectRequestDTO, Project>();
        CreateMap<DonationRequestDTO, Donation>();
        CreateMap<DonationResponseDTO, Donation >();
        CreateMap<UserDTO, User>();
    }
    
}