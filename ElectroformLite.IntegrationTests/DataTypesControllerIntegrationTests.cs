using ElectroformLite.API;
using Microsoft.AspNetCore.Mvc.Testing;
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

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _factory.Dispose();
    }
}