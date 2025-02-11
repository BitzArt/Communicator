using BitzArt.Flux.REST;
using BitzArt.Pagination;
using RichardSzalay.MockHttp;
using System.Net;
using System.Net.Http.Json;

namespace BitzArt.Flux;

public class MockedRestServiceTests
{
    [Theory]
    [InlineData("http://mockedservice", 0)]
    [InlineData("http://mocked.service/", 1)]
    [InlineData("https://mockedservice", 10)]
    [InlineData("https://mockedservice/", 100)]
    [InlineData("https://mocked.service", 1000)]
    [InlineData("https://mockedservice/test/", 10)]
    [InlineData("https://mockedservice/test", 10)]
    [InlineData("https://mocked.service/second.segment/third.segment/test/", 10)]
    public async Task GetAllAsync_MockedHttpClient_ReturnsAll(string baseUrl, int setCount)
    {
        // Arrange
        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model")
            .Respond(
                HttpStatusCode.OK,
                JsonContent.Create(TestModel.GetAll(setCount)));
        });

        // Act
        var result = await setContext.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        if (setCount > 0) Assert.True(result.Any());
        Assert.True(result.Count() == setCount);
    }

    //[Fact]
    //public async Task GetAllAsync_WithParameters_ReturnsAll()
    //{
    //    // Arrange
    //    var baseUrl = "https://mocked.service";
    //    var setCount = 10;

    //    var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
    //    {
    //        x.When($"{baseUrl.TrimEnd('/')}/model?sort=id")
    //        .Respond(HttpStatusCode.OK,
    //        JsonContent.Create(TestModel.GetAll(setCount)));
    //    });

    //    ((FluxRestSetContext<TestModel, int>)setContext)
    //        .SetOptions.EndpointOptions.Path = "model?sort={sort}";

    //    ((FluxRestSetContext<TestModel, int>)setContext)
    //        .SetOptions.EndpointOptions.ParametersType = typeof(RequestParameters);

    //    ((FluxRestSetContext<TestModel, int>)setContext)
    //        .SetOptions.EndpointOptions.TransformRequestParametersFunc = (x) =>
    //        {
    //            return new RestRequestParameters()
    //            {
    //                { "sort", ((RequestParameters)x).Parameters.First()! }
    //            };
    //        };

    //    // Act
    //    var parameters = new RequestParameters("id");
    //    var result = await setContext.GetAllAsync(parameters);

    //    // Assert
    //    Assert.NotNull(result);
    //    if (setCount > 0) Assert.True(result.Any());
    //    Assert.True(result.Count() == setCount);
    //}

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 0, 10)]
    [InlineData(100, 0, 10)]
    [InlineData(1000, 0, 10)]
    [InlineData(10, 5, 10)]
    [InlineData(100, 1, 100)]
    public async Task GetPageAsync_MockedHttpClient_ReturnsPage(int setCount, int offset, int limit)
    {
        // Arrange
        var baseUrl = "https://mocked.service";

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model?offset={offset}&limit={limit}")
            .Respond(
                HttpStatusCode.OK,
                JsonContent.Create(TestModel.GetPage(setCount, offset, limit)));
        });

        // Act
        var result = await setContext.GetPageAsync(offset, limit);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Items);
        if (offset < setCount) Assert.True(result.Items.Any());
        if (offset + limit > setCount)
        {
            var shouldCount = setCount - offset;
            Assert.Equal(shouldCount, result.Items.Count());
        }
    }

    [Theory]
    [InlineData("http://mockedservice")]
    [InlineData("http://mocked.service/")]
    [InlineData("https://mockedservice")]
    [InlineData("https://mockedservice/")]
    [InlineData("https://mocked.service")]
    [InlineData("https://mockedservice/test/")]
    [InlineData("https://mockedservice/test")]
    [InlineData("https://mocked.service/second.segment/third.segment/test.test/test/")]
    public async Task GetAsync_MockedHttpClient_ReturnsModel(string baseUrl)
    {
        // Arrange
        var modelCount = 10;
        var id = 1;

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model/{id}")
            .Respond(
                HttpStatusCode.OK,
                JsonContent.Create(TestModel.GetAll(modelCount).FirstOrDefault(x => x.Id == id)));
        });

        // Act
        var result = await setContext.GetAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Theory]
    [InlineData("http://mockedservice")]
    [InlineData("http://mocked.service/")]
    [InlineData("https://mockedservice")]
    [InlineData("https://mockedservice/")]
    [InlineData("https://mocked.service")]
    [InlineData("https://mockedservice/test/")]
    [InlineData("https://mockedservice/test")]
    [InlineData("https://mocked.service/second.segment/third.segment/test.test/test/")]
    public async Task GetAsync_CustomIdEndpointLogic_ReturnsModel(string baseUrl)
    {
        // Arrange
        var modelCount = 1;
        var id = 1;

        var setContext = 
            TestSetContext.GetTestSetContext(baseUrl, x =>
            {
                x.When($"{baseUrl.TrimEnd('/')}/model/{id}/specific")
                .Respond(
                    HttpStatusCode.OK,
                    JsonContent.Create(TestModel.GetAll(modelCount).FirstOrDefault(x => x.Id == 1)));
            });

        var setOptions = ((FluxRestSetContext<TestModel, int>)setContext).SetOptions;
        var idEndpointOptions = new FluxRestSetIdEndpointOptions<TestModel, int, RestRequestParameters?>(setOptions, getPath: (id) => $"{id}/specific");
        setOptions.EndpointCollection.Add(idEndpointOptions);

        // Act
        var result = await setContext.GetAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    //[Fact]
    //public async Task GetAsyncWithParameters_MockedHttpClient_Returns()
    //{
    //    var baseUrl = "https://mocked.service";
    //    var id = 1;

    //    var database = TestModel.GetAll(100);
    //    var changedName = "Changed Name";
    //    var defaultModel = database.First(x => x.Id == id);
    //    var defaultName = defaultModel.Name;
    //    var changedModel = new TestModel() { Id = id, Name = changedName };

    //    var setContext = (FluxRestSetContext<TestModel, int>)
    //        TestSetContext.GetTestSetContext(baseUrl, x =>
    //    {
    //        x.When($"{baseUrl.TrimEnd('/')}/model/{id}?changeName=False")
    //        .Respond(HttpStatusCode.OK,
    //        JsonContent.Create(defaultModel));

    //        x.When($"{baseUrl.TrimEnd('/')}/model/{id}?changeName=True")
    //        .Respond(HttpStatusCode.OK,
    //        JsonContent.Create(changedModel));
    //    });

    //    setContext.SetOptions.IdEndpointOptions.GetPathFunc = (id, parameters) =>
    //    {
    //        return $"model/{id}?changeName={parameters!.First()}";
    //    };

    //    var parameters = new FluxRequestParameters(false);
    //    var resultWithParameterFalse = await setContext.GetAsync(id, parameters);
    //    Assert.Equal(defaultName, resultWithParameterFalse.Name);

    //    parameters = new FluxRequestParameters(true);
    //    var resultWithParameterTrue = await setContext.GetAsync(id, parameters);
    //    Assert.Equal(changedName, resultWithParameterTrue.Name);
    //}

    [Fact]
    public async Task GetPageAsyncWithParameters_MockedHttpClient_Returns()
    {
        // Arrange
        var baseUrl = "https://mocked.service";

        var setContext = (FluxRestSetContext<TestModel, int>)
            TestSetContext.GetTestSetContext(baseUrl, x =>
            {
                x.When($"{baseUrl.TrimEnd('/')}/model/1/test?offset=0&limit=10")
                .Respond(HttpStatusCode.OK,
                JsonContent.Create(TestModel.GetPage(100, 0, 10)));
            });

        var setOptions = setContext.SetOptions;
        var endpointOptions = new FluxRestSetPageEndpointOptions<TestModel, int, RestRequestParameters>(setOptions, path: "{parentId}/test");
        setContext.SetOptions.EndpointCollection.Add(endpointOptions);

        var pageRequest = new PageRequest(0, 10);
        var parameters = new RestRequestParameters()
        {
            { "parentId", 1 }
        };

        // Act
        var result = await setContext.GetPageAsync(pageRequest, parameters);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(10, result.Items!.Count());
    }

    [Fact]
    public async Task AddAsync_MockedHttpClient_ReturnsModel()
    {
        // Arrange
        var baseUrl = "https://mocked.service";
        var id = 1;
        var name = "model";

        var setContext = (FluxRestSetContext<TestModel, int>)
            TestSetContext.GetTestSetContext(baseUrl, x =>
            {
                x.When($"{baseUrl.TrimEnd('/')}/model")
                .Respond(HttpStatusCode.Created,
                JsonContent.Create(new TestModel { Id = id, Name = name }));
            });

        var model = new TestModel { Id = id, Name = name };

        // Act
        var result = await setContext.AddAsync(model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
    }

    [Fact]
    public async Task AddAsync_WithResponseType_ReturnsUpdateResponse()
    {
        // Arrange
        var baseUrl = "https://mocked.service";
        var id = 1;
        var name = "model";

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model")
            .Respond(HttpStatusCode.Created,
            JsonContent.Create(new TestModelUpdateResponse(id, name)));
        });

        var model = new TestModel { Id = id, Name = name };

        // Act
        var result = await setContext.AddAsync<TestModelUpdateResponse>(model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
    }

    [Fact]
    public async Task UpdateAsync_MockedHttpClient_ReturnsModel()
    {
        // Arrange
        var baseUrl = "https://mocked.service";
        var id = 1;
        var name = "updated model";

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model/{id}")
            .Respond(HttpStatusCode.OK,
            JsonContent.Create(new TestModel { Id = id, Name = name }));
        });

        var model = new TestModel { Id = id, Name = name };

        // Act
        var result = await setContext.UpdateAsync(id, model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
    }

    [Fact]
    public async Task UpdateAsync_WithResponseType_ReturnsUpdateResponse()
    {
        // Arrange
        var baseUrl = "https://mocked.service";
        var id = 1;
        var name = "updated model";

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model/{id}")
            .Respond(HttpStatusCode.OK,
            JsonContent.Create(new TestModelUpdateResponse { Id = id, Name = name }));
        });

        var model = new TestModel { Id = id, Name = name };

        // Act
        var result = await setContext.UpdateAsync<TestModelUpdateResponse>(id, model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
    }

    [Fact]
    public async Task UpdateAsync_Partial_ReturnsModel()
    {
        // Arrange
        var baseUrl = "https://mocked.service";
        var id = 1;
        var name = "updated model 1";

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model/{id}")
            .Respond(HttpStatusCode.OK,
            JsonContent.Create(new TestModel { Id = id, Name = name }));
        });

        var model = new TestModel { Id = id, Name = name };

        // Act
        var result = await setContext.UpdateAsync(id, model, partial: true);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
    }

    [Fact]
    public async Task UpdateAsyncWithResponseType_Partial_ReturnsUpdateResponse()
    {
        // Arrange
        var baseUrl = "https://mocked.service";
        var id = 1;
        var name = "updated model 1";

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model/{id}")
            .Respond(HttpStatusCode.OK,
            JsonContent.Create(new TestModelUpdateResponse { Id = id, Name = name }));
        });

        var model = new TestModel { Id = id, Name = "model" };

        // Act
        var result = await setContext.UpdateAsync<TestModelUpdateResponse>(id, model, partial: true);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
    }

    [Fact]
    public async Task UpdateAsync_IdAsParameter_ReturnsModel()
    {
        // Arrange
        var baseUrl = "https://mocked.service";
        var modelId = 1;
        var name = "updated model";

        var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
        {
            x.When($"{baseUrl.TrimEnd('/')}/model?id={modelId}")
            .Respond(HttpStatusCode.OK,
            JsonContent.Create(new TestModel { Id = modelId, Name = name }));
        });

        var model = new TestModel { Id = modelId, Name = name };



        // Act
        var result = await setContext.UpdateAsync(model, new() { "id", modelId }, partial: false);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(modelId, result.Id);
        Assert.Equal(name, result.Name);
    }

    //[Fact]
    //public async Task UpdateAsync_CustomIdEndpointLogic_ReturnsModel()
    //{
    //    var baseUrl = "https://mocked.service";
    //    var id = 1;
    //    var name = "updated model";

    //    var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
    //    {
    //        x.When($"{baseUrl.TrimEnd('/')}/model/specific/{id}")
    //        .Respond(HttpStatusCode.OK,
    //        JsonContent.Create(new TestModel { Id = id, Name = name }));
    //    });

    //    ((FluxRestSetContext<TestModel, int>)setContext)
    //        .SetOptions.IdEndpointOptions.GetPathFunc = (key, _) => $"model/specific/{key}";

    //    var model = new TestModel { Id = id, Name = name };

    //    var result = await setContext.UpdateAsync(id, model);

    //    Assert.NotNull(result);
    //    Assert.Equal(id, result.Id);
    //    Assert.Equal(name, result.Name);
    //}

    //[Fact]
    //public async Task UpdateAsyncWithResponseType_IdAsParameter_ReturnsUpdateResponse()
    //{
    //    var baseUrl = "https://mocked.service";
    //    var modelId = 1;
    //    var name = "updated model";

    //    var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
    //    {
    //        x.When($"{baseUrl.TrimEnd('/')}/model?id={modelId}")
    //        .Respond(HttpStatusCode.OK,
    //        JsonContent.Create(new TestModelUpdateResponse { Id = modelId, Name = name }));
    //    });

    //    ((FluxRestSetContext<TestModel, int>)setContext)
    //        .SetOptions.IdEndpointOptions.GetPathFunc = (_, parameters) => $"model?id={parameters!.First()}";

    //    var model = new TestModel { Id = modelId, Name = name };

    //    var parameters = new FluxRequestParameters(modelId);
    //    var result = await setContext.UpdateAsync<TestModelUpdateResponse>(model, parameters, partial: false);

    //    Assert.NotNull(result);
    //    Assert.Equal(modelId, result.Id);
    //    Assert.Equal(name, result.Name);
    //}

    //[Fact]
    //public async Task UpdateAsyncWithResponseType_CustomIdEndpointLogic_ReturnsUpdateResponse()
    //{
    //    var baseUrl = "https://mocked.service";
    //    var id = 1;
    //    var name = "updated model";

    //    var setContext = TestSetContext.GetTestSetContext(baseUrl, x =>
    //    {
    //        x.When($"{baseUrl.TrimEnd('/')}/model/specific/{id}")
    //        .Respond(HttpStatusCode.OK,
    //        JsonContent.Create(new TestModelUpdateResponse { Id = id, Name = name }));
    //    });

    //    ((FluxRestSetContext<TestModel, int>)setContext)
    //        .SetOptions.IdEndpointOptions.GetPathFunc = (key, _) => $"model/specific/{key}";

    //    var model = new TestModel { Id = id, Name = name };

    //    var result = await setContext.UpdateAsync<TestModelUpdateResponse>(id, model);

    //    Assert.NotNull(result);
    //    Assert.Equal(id, result.Id);
    //    Assert.Equal(name, result.Name);
    //}
}