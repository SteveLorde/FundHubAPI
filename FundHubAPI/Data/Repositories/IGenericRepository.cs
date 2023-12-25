using FundHubAPI.Data.DTOs;

namespace FundHubAPI.Data.Repositories;

public interface IGenericRepository<T>
{
    Task<List<T>> GetAll();
    Task<T?> Get(string entityidorname);
    Task<bool> Add(TDTO entitydto);
    Task<bool> AddDirect(T entity);
    Task<bool> Update(TDTO entitydto);
    Task<bool> Remove(string entityid);
}