using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;

namespace PA200_webapp.Repository;

public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: class
{
    protected SocialNetworkContext SocialNetworkContext { get; set; }

    protected RepositoryBase(SocialNetworkContext socialNetworkContext)
    {
        SocialNetworkContext = socialNetworkContext;
    }
    
    public IQueryable<T> FindAll() => SocialNetworkContext.Set<T>().AsNoTracking();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
        SocialNetworkContext.Set<T>().Where(expression).AsNoTracking();
    public T Create(T entity) => SocialNetworkContext.Set<T>().Add(entity).Entity;
    public T Update(T entity) => SocialNetworkContext.Set<T>().Update(entity).Entity;
    public void Delete(T entity) => SocialNetworkContext.Set<T>().Remove(entity);
}