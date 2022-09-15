using ElectroformLite.API;
using ElectroformLite.API.Dto;
using ElectroformLite.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;

namespace ElectroformLite.IntegrationTests;

[TestClass]
public class DataTypesControllerIntegrationTests
{
    private static TestContext _testContext;
    private static WebApplicationFactory<Startup> _factory;

    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        _testContext = testContext;
        _factory = new CustomWebApplicationFactory<Startup>();
    }

    [TestMethod]
    public async Task GetDataTypes_ShouldReturn_OkResponse()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("data-types");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task GetDataTypes_ShouldReturn_ExistingDataTypes()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("data-types");

        var result = await response.Content.ReadAsStringAsync();
        var dataTypeDtos = JsonConvert.DeserializeObject<List<DataTypeDto>>(result);

        DataTypeDto dataTypeDto = dataTypeDtos.First(d => d.Id == Utilities.TextDataTypeId);
        Assert.AreEqual("TextLite", dataTypeDto.Value);
    }

    [TestMethod]
    public async Task GetDataType_ShouldReturn_ExistingDataType()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"data-types/{Utilities.TextDataTypeId}");

        var result = await response.Content.ReadAsStringAsync();
        var dataType = JsonConvert.DeserializeObject<DataTypeDto>(result);

        Assert.AreEqual("TextLite", dataType?.Value);
        Assert.AreEqual(Utilities.TextDataTypeId, dataType?.Id);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _factory.Dispose();
    }
}