using System;
using System.Linq;
using System.Threading.Tasks;
using AggregateRootEventTriggeringBug.Products;
using AggregateRootEventTriggeringBug.Samples;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AggregateRootEventTriggeringBug.EntityFrameworkCore.Domains;

[Collection(AggregateRootEventTriggeringBugTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AggregateRootEventTriggeringBugEntityFrameworkCoreTestModule>
{
    private IRepository<Product, Guid> ProductRepository { get; }

    public EfCoreSampleDomainTests()
    {
        ProductRepository = GetRequiredService<IRepository<Product, Guid>>();
    }

    [Fact]
    public async Task Reproduce_The_Problem()
    {
        var productId = Guid.NewGuid();

        await WithUnitOfWorkAsync(async () =>
        {
            await ProductRepository.InsertAsync(new Product(productId, [new Sku(Guid.NewGuid(), "MySku")]), true);
        });

        await WithUnitOfWorkAsync(async () =>
        {
            var product = await ProductRepository.GetAsync(productId);
            var sku = product.Skus.First();

            sku.Name = "new-name";

            await ProductRepository.UpdateAsync(product, true);
        });
    }
}