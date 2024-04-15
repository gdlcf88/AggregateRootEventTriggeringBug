using System;
using Volo.Abp.Domain.Entities;

namespace AggregateRootEventTriggeringBug.Products;

public class ProductAttributeOption : Entity<Guid>
{
    public string Name { get; set; }

    protected ProductAttributeOption() { }

    public ProductAttributeOption(Guid id, string name) : base(id)
    {
        Name = name;
    }
}