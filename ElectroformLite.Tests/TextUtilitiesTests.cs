using ElectroformLite.Application.Utils;

namespace ElectroformLite.Tests;

public class TextUtilitiesTests
{
    readonly string value = "Cerere 1 Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice\n\nSubsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de\ntelefon [Contact.PhoneNumber], solicit a-mi fi atribuit credential in\nvederea platii prin www.ghiseul.ro";
    readonly Dictionary<string, string> dataDictionary = new();

    public TextUtilitiesTests()
    {
        // Arrange
        dataDictionary.Add("[Person.FirstName]", "John");
        dataDictionary.Add("[Person.LastName]", "Doe");
        dataDictionary.Add("[Contact.Email]", "john@doe.com");
        dataDictionary.Add("[Contact.PhoneNumber]", "1234567890");
    }

    [Fact]
    public void ReplacePlaceholdersShoulReplaceValues()
    {
        // Arrange

        // Act
        string result = TextUtilities.ReplacePlaceholders(value, dataDictionary);

        // Assert
        Assert.Equal("Cerere 1 Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice\n\nSubsemnatul/a John Doe, e-mail john@doe.com, numar de\ntelefon 1234567890, solicit a-mi fi atribuit credential in\nvederea platii prin www.ghiseul.ro", result);
    }

    [Fact]
    public void ReplacePlaceholdersShouldNotContainSquareBrackets()
    {
        // Arrange

        // Act
        string result = TextUtilities.ReplacePlaceholders(value, dataDictionary);

        // Assert
        Assert.DoesNotContain("[", result);
        Assert.DoesNotContain("]", result);
    }
}
