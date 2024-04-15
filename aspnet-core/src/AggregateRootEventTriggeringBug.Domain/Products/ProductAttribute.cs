using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AggregateRootEventTriggeringBug.Products;

public class ProductAttribute : Entity<Guid>
{
    public string Name { get; set; }

    public virtual List<ProductAttributeOption> Options { get; protected set; }

    protected ProductAttribute() { }

    public ProductAttribute(Guid id, string name, List<ProductAttributeOption> options) : base(id)
    {
        Name = name;
        Options = options;
    }
}
