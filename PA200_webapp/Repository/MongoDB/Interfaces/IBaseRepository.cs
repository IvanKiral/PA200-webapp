using System.Linq.Expressions;
using MongoDB.Bson;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB.Interfaces;

public interface IBaseRepository<T> where T: BaseDocument
{
    public IEnumerable<T> GetAll();
    public Task<IEnumerable<T>> GetAllAsync();
    public IEnumerable<T> FilterBy(Expression<Func<T, bool>> filter);
    public Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> filter);
    public T Create(T element);
    public Task<T> CreateAsync(T element);
    public T Update(T element);
    public Task<T> UpdateAsync(T element);
    public void Delete(string id);
    public Task DeleteAsync(string id);
    
}