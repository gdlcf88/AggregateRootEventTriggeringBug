using System;
using System.Linq;
using System.Threading.Tasks;
using AggregateRootEventTriggeringBug.Products;
using AggregateRootEventTriggeringBug.Samples;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AggregateRootEventTriggeringBug.EntityFrameworkCore.Domains;

[Collection(AggregateRootEventTriggeringBugTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AggregateRootEventTriggeringBugEntityFrameworkCoreTestModule>
{
    private IRepository<Product, Guid> ProductRepository { get; }
    private IRepository<ProductHistory, Guid> ProductHistoryRepository { get; }

    public EfCoreSampleDomainTests()
    {
        ProductRepository = GetRequiredService<IRepository<Product, Guid>>();
        ProductHistoryRepository = GetRequiredService<IRepository<ProductHistory, Guid>>();
    }

    [Fact]
    public async Task Reproduce_The_Problem()
    {
        var productId = Guid.NewGuid();

        await WithUnitOfWorkAsync(async () =>
        {
            await ProductRepository.InsertAsync(new Product(
                    productId,
                    [new Sku(Guid.NewGuid(), "MySku"), new Sku(Guid.NewGuid(), "MySku2")],
                    [
                        new ProductAttribute(Guid.NewGuid(), "Attr1",
                        [
                            new ProductAttributeOption(Guid.NewGuid(), "Opt1"),
                            new ProductAttributeOption(Guid.NewGuid(), "Opt2")
                        ])
                    ]
                ),
                true
            );
        });

        var product = await ProductRepository.GetAsync(productId);
    }

    [Fact]
    public async Task Should_Trigger_Aggregate_Root_Updated_Event()
    {
        var productId = Guid.NewGuid();

        await WithUnitOfWorkAsync(async () =>
        {
            await ProductRepository.InsertAsync(new Product(
                    productId,
                    [new Sku(Guid.NewGuid(), "MySku")],
                    []
                ),
                true
            );
        });

        (await ProductHistoryRepository.GetCountAsync()).ShouldBe(0);

        await WithUnitOfWorkAsync(async () =>
        {
            var product = await ProductRepository.GetAsync(productId);

            product.Skus.First().Name = "new-sku-name";

            await ProductRepository.UpdateAsync(product, true);
        });

        (await ProductHistoryRepository.GetCountAsync()).ShouldBe(1);
    }
}