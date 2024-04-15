using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace AggregateRootEventTriggeringBug.Products;

public class Product : FullAuditedAggregateRoot<Guid>
{
    public virtual List<ProductAttribute> Attributes { get; set; }

    public virtual List<Sku> Skus { get; set; }

    protected Product()
    {
    }

    public Product(Guid id, List<Sku> skus, List<ProductAttribute> attributes) : base(id)
    {
        Attributes = attributes;
        Skus = skus;
    }
}
