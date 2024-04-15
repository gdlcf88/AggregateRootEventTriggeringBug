using System;
using Volo.Abp.Domain.Entities;

namespace AggregateRootEventTriggeringBug.Products;

public class Sku : Entity<Guid>
{
    public string Name { get; set; }

    public Sku(Guid id, string name) : base(id)
    {
        Name = name;
    }
}