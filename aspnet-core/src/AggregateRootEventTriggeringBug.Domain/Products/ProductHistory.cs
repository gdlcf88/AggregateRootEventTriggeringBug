using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace AggregateRootEventTriggeringBug.Products;

public class ProductHistory : AggregateRoot<Guid>
{
    public virtual Guid ProductId { get; protected set; }

    public virtual DateTime ModificationTime { get; protected set; }

    public virtual string SerializedEntityData { get; protected set; }

    protected ProductHistory() { }

    public ProductHistory(
        Guid id,
        Guid productId,
        DateTime modificationTime,
        string serializedEntityData) : base(id)
    {
        ProductId = productId;
        ModificationTime = modificationTime;
        SerializedEntityData = serializedEntityData;
    }
}