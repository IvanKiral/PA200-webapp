using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using PA200_webapp.models.MongoDB;

namespace PA200_webapp.Repository.MongoDB;

public abstract class BaseRepository<T>: Interfaces.IBaseRepository<T> where T: BaseDocument
{
    public IMongoCollection<T> Collection { get; set; }

    public IEnumerable<T> GetAll() =>
        Collection.Find(_ => true).ToEnumerable();

    public async Task<IEnumerable<T>> GetAllAsync() =>
        (await Collection.FindAsync(_ => true)).ToEnumerable();

    public IEnumerable<T> FilterBy(Expression<Func<T, bool>> filter) =>
        Collection.Find(filter).ToEnumerable();
  

    public async Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> filter) =>
        (await Collection.FindAsync(filter)).ToEnumerable();

    public T Create(T element)
    {
        Collection.InsertOne(element);
        return element;
    }

    public async Task<T> CreateAsync(T element)
    {
        await Collection.InsertOneAsync(element);
        return element;
    }

    public T Update(T element)
    {
        var filter = Builders<T>.Filter.Eq(el => el.Id, element.Id);
        Collection.FindOneAndReplace(filter, element);
        return element;
    }

    public async Task<T> UpdateAsync(T element)
    {
        var filter = Builders<T>.Filter.Eq(el => el.Id, element.Id);
        await Collection.FindOneAndReplaceAsync(filter, element);
        return element;
    }

    public void Delete(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);
        Collection.FindOneAndDelete(filter);
    }

    public async Task DeleteAsync(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);
        await Collection.FindOneAndDeleteAsync(filter);
    }
}