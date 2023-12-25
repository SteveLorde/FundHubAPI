using AutoMapper;
using FundHubAPI.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Data.Repositories;

class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    public  DataContext _db;
    public  IMapper _mapper;
    
    public GenericRepository()
    {
        
    }

    public GenericRepository(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<List<T>> GetAll()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public async Task<T?> Get(string entityid)
    {
        return await _db.Set<T>().FindAsync(Guid.Parse(entityid));
    }

    public async Task<bool> Add(TDTO entitydto)
    {
        T newentity = new T();
        newentity = _mapper.Map<T>(entitydto);
        await _db.Set<T>().AddAsync(newentity);
        await _db.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> AddDirect(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> Update(TDTO entitydao)
    {
        var selectedentity = await _db.Set<T>().FindAsync(Guid.Parse(entitydao.id));
        selectedentity = _mapper.Map<T>(entitydao);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(string entityid)
    {
        var selectedentity = await _db.Set<T>().FindAsync(Guid.Parse(entityid));
        _db.Set<T>().Remove(selectedentity);
        return true;
    }
}