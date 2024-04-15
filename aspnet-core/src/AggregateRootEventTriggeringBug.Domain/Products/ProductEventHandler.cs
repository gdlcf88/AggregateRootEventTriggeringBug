using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace AggregateRootEventTriggeringBug.Products;

public class ProductEventHandler : ILocalEventHandler<EntityChangedEventData<Product>>, ITransientDependency
{
    private readonly IdentityUserManager _userManager;

    public ProductEventHandler(IdentityUserManager userManager)
    {
        _userManager = userManager;
    }

    [UnitOfWork]
    public virtual async Task HandleEventAsync(EntityChangedEventData<Product> eventData)
    {
        var userId = Guid.NewGuid();

        await _userManager.CreateAsync(new IdentityUser(userId, userId.ToString(), $"{userId}@abp.io"));
    }
}