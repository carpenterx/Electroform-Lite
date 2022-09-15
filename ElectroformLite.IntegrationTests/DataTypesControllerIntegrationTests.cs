using ElectroformLite.API;
using ElectroformLite.API.Dto;
using ElectroformLite.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

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
        Assert.AreEqual(Utilities.TextTypeValue, dataTypeDto.Value);
    }

    [TestMethod]
    public async Task GetDataType_ShouldReturn_ExistingDataType()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"data-types/{Utilities.TextDataTypeId}");

        var result = await response.Content.ReadAsStringAsync();
        DataTypeDto? dataTypeDto = JsonConvert.DeserializeObject<DataTypeDto>(result);

        Assert.AreEqual(Utilities.TextTypeValue, dataTypeDto?.Value);
        Assert.AreEqual(Utilities.TextDataTypeId, dataTypeDto?.Id);
    }

    [TestMethod]
    public async Task CreateDataType_ShouldReturn_CreatedResponse()
    {
        var client = _factory.CreateClient();
        var response = await client.PostAsJsonAsync("data-types", "New Type");

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
    }

    [TestMethod]
    public async Task CreateDataType_ShouldReturn_CreatedDataType()
    {
        var client = _factory.CreateClient();
        string typeValue = "Created Type";
        var response = await client.PostAsJsonAsync("data-types", typeValue);

        var result = await response.Content.ReadAsStringAsync();
        DataTypeDto? dataTypeDto = JsonConvert.DeserializeObject<DataTypeDto>(result);

        Assert.AreEqual(typeValue, dataTypeDto?.Value);
    }

    [TestMethod]
    public async Task UpdateDataType_ShouldReturn_UpdatedDataType()
    {
        var client = _factory.CreateClient();
        string newValue = "Phone Edited";
        DataTypeDto editedDataTypeDto = new()
        {
            Id = Utilities.PhoneDataTypeId,
            Value = newValue
        };
        await client.PutAsync($"data-types/{Utilities.PhoneDataTypeId}",
               new StringContent(JsonConvert.SerializeObject(editedDataTypeDto), Encoding.UTF8, "application/json"));

        var response = await client.GetAsync($"data-types/{Utilities.PhoneDataTypeId}");

        var result = await response.Content.ReadAsStringAsync();
        DataTypeDto? dataTypeDto = JsonConvert.DeserializeObject<DataTypeDto>(result);

        Assert.AreEqual(Utilities.PhoneDataTypeId, dataTypeDto?.Id);
        Assert.AreEqual(newValue, dataTypeDto?.Value);
    }

    [TestMethod]
    public async Task UpdateDataType_WithWrongId_ShouldReturn_BadRequest()
    {
        var client = _factory.CreateClient();
        string newValue = "Phone Edited";
        DataTypeDto editedDataTypeDto = new()
        {
            Id = Utilities.PhoneDataTypeId,
            Value = newValue
        };
        var response = await client.PutAsync($"data-types/{Guid.Empty}",
               new StringContent(JsonConvert.SerializeObject(editedDataTypeDto), Encoding.UTF8, "application/json"));

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [TestMethod]
    public async Task DeleteDataType_ShouldReturn_NoContentResponse()
    {
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync($"data-types/{Utilities.EmailDataTypeId}");

        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
    }

    [TestMethod]
    public async Task DeleteDataType_WithNotFoundId_ShouldReturn_NotFound()
    {
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync($"data-types/{Guid.Empty}");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _factory.Dispose();
    }
}