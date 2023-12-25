using AutoMapper;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Repositories;

namespace FundHubAPI.Data.Repositories;

class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(db, mapper, hostingEnvironment)
    {
        
    }
    
}