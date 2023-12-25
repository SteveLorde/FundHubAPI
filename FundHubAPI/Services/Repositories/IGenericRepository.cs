using System.Linq.Expressions;
using FundHubAPI.Data.DTOs;

namespace FundHubAPI.Data.Repositories;

public interface IGenericRepository<T> where T : class
{
    public Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
    public Task<T?> Get(string entityidorname);
    public Task<bool> Add(TDTO entitydto);
    public Task<bool> AddDirect(T entity);
    public Task<bool> Update(TDTO entitydto);
    public Task<bool> Remove(string entityid);
}