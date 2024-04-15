using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AggregateRootEventTriggeringBug.Products;

public class Product : AggregateRoot<Guid>
{
    public List<Sku> Skus { get; set; }

    protected Product()
    {
    }

    public Product(Guid id, List<Sku> skus) : base(id)
    {
        Skus = skus;
    }
}