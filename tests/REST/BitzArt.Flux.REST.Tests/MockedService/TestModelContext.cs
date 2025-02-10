using BitzArt.Flux.REST;
using Microsoft.Extensions.Logging;
using RichardSzalay.MockHttp;

namespace BitzArt.Flux;

internal static class TestSetContext
{
    public static IFluxSetContext<TestModel> GetTestSetContext(string baseUrl, Action<MockHttpMessageHandler>? configureMockWebApi = null)
    {
        var mockedService = MockedService.GetService(configureMockWebApi);

        var serviceOptions = new FluxRestServiceOptions(baseUrl);
        var setOptions = new FluxRestSetOptions<TestModel, int>(serviceOptions, path: "model");

        var setContext = new FluxRestSetContext<TestModel, int>
            (mockedService.GetHttpClient(),
            new FluxRestServiceOptions(baseUrl),
            LoggerFactory.Create(x => { }).CreateLogger("Flux"),
            setOptions);

        return setContext;
    }
}
