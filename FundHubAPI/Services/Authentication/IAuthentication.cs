﻿using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(LoginRequest loginreq);
    public Task<bool> Register(RegisterRequestDTO registerreq);
}