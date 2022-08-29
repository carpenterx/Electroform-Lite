using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using Newtonsoft.Json.Linq;

namespace ElectroformLite.Tests;

public class DataGroupUtilsTests
{

    [Fact]
    public void GenerateDataGroupOutputShouldBeValid()
    {
        DataType textDataType = new("Text");
        DataTemplate firstNameDataTemplate = new() { Placeholder = "FirstName" };
        DataTemplate lastNameDataTemplate = new() { Placeholder = "LastName" };
        DataGroupTemplate personDataGroupTemplate = new () { Name = "Person" };
        DataGroup dataGroup = DataGroupGenerator.GenerateDataGroup(new DataGroupTemplate(), Array.Empty<string>());
        //Assert.Equal(expectedDataGroup, dataGroup);
        Assert.True(false);
    }
}