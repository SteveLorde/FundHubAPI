using AutoMapper;
using FundHubAPI.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Data.Repositories;

class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public GenericRepository(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<List<T>> GetAll()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public async Task<T?> Get(string entityidorname)
    {
        return await _db.Set<T>().FindAsync(entityidorname);
    }

    public async Task<T> Add(TDTO entitydao)
    {
        T entity = _mapper.Map<T>(entitydao);
        await _db.Set<T>().AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<T> Update(T entitydao)
    {
        
    }

    public async Task<T> Remove(T entityid)
    {
        throw new NotImplementedException();
    }
}