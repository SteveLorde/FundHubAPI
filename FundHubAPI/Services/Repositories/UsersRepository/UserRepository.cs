using AutoMapper;
using FundHubAPI.Data;

namespace FundHubAPI.Services.Repositories.UsersRepository;

class UserRepository : IUserRepository
{
    public UserRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        
    }
    
    
    
}