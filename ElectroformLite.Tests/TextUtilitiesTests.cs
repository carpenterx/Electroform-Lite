using ElectroformLite.Application.Utils;

namespace ElectroformLite.Tests;

public class TextUtilitiesTests
{
    [Fact]
    public void ReplacePlaceholdersShouldReplaceValues()
    {
        // Arrange
        string value = "Cerere 1 Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice\n\nSubsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de\ntelefon [Contact.PhoneNumber], solicit a-mi fi atribuit credential in\nvederea platii prin www.ghiseul.ro";
        Dictionary<string, string> dataDictionary = new()
        {
            { "[Person.FirstName]", "John" },
            { "[Person.LastName]", "Doe" },
            { "[Contact.Email]", "john@doe.com" },
            { "[Contact.PhoneNumber]", "1234567890" }
        };

        // Act
        string result = TextUtilities.ReplacePlaceholders(value, dataDictionary);

        // Assert
        Assert.Equal("Cerere 1 Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice\n\nSubsemnatul/a John Doe, e-mail john@doe.com, numar de\ntelefon 1234567890, solicit a-mi fi atribuit credential in\nvederea platii prin www.ghiseul.ro", result);
    }

    [Fact]
    public void ReplacePlaceholdersShouldNotContainSquareBrackets()
    {
        // Arrange
        string value = "Cerere 1 Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice\n\nSubsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de\ntelefon [Contact.PhoneNumber], solicit a-mi fi atribuit credential in\nvederea platii prin www.ghiseul.ro";
        Dictionary<string, string> dataDictionary = new()
        {
            { "[Person.FirstName]", "John" },
            { "[Person.LastName]", "Doe" },
            { "[Contact.Email]", "john@doe.com" },
            { "[Contact.PhoneNumber]", "1234567890" }
        };

        // Act
        string result = TextUtilities.ReplacePlaceholders(value, dataDictionary);

        // Assert
        Assert.DoesNotContain("[", result);
        Assert.DoesNotContain("]", result);
    }

    [Fact]
    public void GeneratePlaceholderShouldGenerateAPlaceholder()
    {
        // Arrange
        string aliasName = "Person";
        string dataPlaceholder = "LastName";

        // Act
        string result = TextUtilities.GeneratePlaceholder(aliasName, dataPlaceholder);

        // Assert
        Assert.Equal("[Person.LastName]", result);
    }
}
