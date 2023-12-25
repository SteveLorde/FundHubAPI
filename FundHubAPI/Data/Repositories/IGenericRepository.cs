using FundHubAPI.Data.DTOs;

namespace FundHubAPI.Data.Repositories;

public interface IGenericRepository<T>
{
    public Task<List<T>> GetAll();
    public Task<T?> Get(string entityidorname);
    public Task<T> Add(TDTO entitydao);
    public Task<T> Update(TDTO entitydao);
    public Task<T> Remove(string entityid);
}