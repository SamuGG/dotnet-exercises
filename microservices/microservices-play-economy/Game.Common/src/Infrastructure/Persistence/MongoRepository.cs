using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Game.Common.Application.Common.Interfaces;
using Game.Common.Domain.Entities;
using MongoDB.Driver;

namespace Game.Common.Infrastructure.Persistence;

public class MongoRepository<T> : ITrackedRepository<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _dbCollection;
    private readonly IEntityTracker<T> _entityTracker;
    private static readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public MongoRepository([NotNull] IMongoDatabase database, string collectionName, [NotNull] IEntityTracker<T> entityTracker)
    {
        ArgumentNullException.ThrowIfNull(database);
        ArgumentNullException.ThrowIfNull(entityTracker);
        if (string.IsNullOrWhiteSpace(collectionName)) throw new ArgumentNullException(nameof(collectionName));

        _dbCollection = database.GetCollection<T>(collectionName);
        _entityTracker = entityTracker;
    }

    public T[] GetTrackedEntitiesArray() =>
        _entityTracker.GetEntitiesArray();

    public void UntrackAllWithoutDomainEvents() =>
        _entityTracker.RemoveAllWithoutDomainEvents();

    public async Task AddNewAsync([NotNull] T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _dbCollection.InsertOneAsync(entity);
        _entityTracker.Track(entity);
    }

    public async Task<T> FindOneAndDeleteAsync(Guid id)
    {
        var entity = await _dbCollection.FindOneAndDeleteAsync(_filterBuilder.Eq(dbEntity => dbEntity.Id, id));
        _entityTracker.Track(entity);
        return entity;
    }

    public Task<T> FindOneAsync(Guid id) =>
        _dbCollection
            .Find(_filterBuilder.Eq(dbEntity => dbEntity.Id, id))
            .Limit(1)
            .FirstOrDefaultAsync();

    public Task<T> FindOneAsync(Expression<Func<T, bool>> filter) =>
        _dbCollection
            .Find(filter)
            .Limit(1)
            .FirstOrDefaultAsync();

    public async Task<IReadOnlyCollection<T>> GetAllAsync() =>
        await _dbCollection
            .Find(_filterBuilder.Empty)
            .ToListAsync();

    public async Task<IReadOnlyCollection<T>> FindAllAsync(Expression<Func<T, bool>> filter) =>
        await _dbCollection
            .Find(filter)
            .ToListAsync();

    public async Task<T> FindOneAndReplaceAsync([NotNull] T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var replacedEntity = await _dbCollection.FindOneAndReplaceAsync(
            _filterBuilder.Eq(dbEntity => dbEntity.Id, entity.Id),
            entity,
            new FindOneAndReplaceOptions<T>()
            {
                ReturnDocument = ReturnDocument.After
            });

        _entityTracker.Track(replacedEntity);

        return replacedEntity;
    }
}