using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.Json;
using Volo.Abp.Uow;

namespace AggregateRootEventTriggeringBug.Products;

public class ProductEventHandler : ILocalEventHandler<EntityUpdatedEventData<Product>>, ITransientDependency
{
    private readonly IJsonSerializer _jsonSerializer;
    private readonly IRepository<ProductHistory, Guid> _productHistoryRepository;
    private readonly IGuidGenerator _guidGenerator;

    public ProductEventHandler(IJsonSerializer jsonSerializer, IRepository<ProductHistory, Guid> productHistoryRepository, IGuidGenerator guidGenerator)
    {
        _jsonSerializer = jsonSerializer;
        _productHistoryRepository = productHistoryRepository;
        _guidGenerator = guidGenerator;
    }

    [UnitOfWork]
    public virtual async Task HandleEventAsync(EntityUpdatedEventData<Product> eventData)
    {
        var modificationTime = eventData.Entity.LastModificationTime ?? eventData.Entity.CreationTime;

        var serializedEntityData = _jsonSerializer.Serialize(eventData.Entity);

        await _productHistoryRepository.InsertAsync(new ProductHistory(_guidGenerator.Create(), eventData.Entity.Id, modificationTime, serializedEntityData));
    }
}