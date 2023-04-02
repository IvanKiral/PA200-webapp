using System.Linq.Expressions;

namespace PA200_webapp.Repository;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    T Create(T entity);
    T Update(T entity);
    void Delete(T entity);
}