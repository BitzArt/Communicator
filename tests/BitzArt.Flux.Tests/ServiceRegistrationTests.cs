using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Flux;

public class ServiceRegistrationTests
{
    [Fact]
    public void AddFlux_WithEmptyConfiguration_ShouldAddEmptyFluxServiceFactory()
    {
        var services = new ServiceCollection();

        services.AddFlux(x => { });

        var serviceProvider = services.BuildServiceProvider();
        var factory = serviceProvider.GetService<IFluxFactory>();

        Assert.NotNull(factory);
        Assert.NotNull(factory.ServiceContexts);
        Assert.Empty(factory.ServiceContexts);
    }

    [Fact]
    public void AddFlux_Twice_ShouldThrowOnSecondAdd()
    {
        var services = new ServiceCollection();

        services.AddFlux(x => { });

        Assert.ThrowsAny<Exception>(() => services.AddFlux(x => { }));
    }

    [Fact]
    public void AddFlux_Empty_ShouldAddFluxContext()
    {
        var services = new ServiceCollection();
        services.AddFlux(x => { });
        var serviceProvider = services.BuildServiceProvider();

        var context = serviceProvider.GetService<IFluxContext>();
        Assert.NotNull(context);
    }
}