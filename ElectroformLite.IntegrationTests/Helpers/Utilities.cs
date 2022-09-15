using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure.Database;

namespace ElectroformLite.IntegrationTests.Helpers;

public static class Utilities
{
    public static Guid TextDataTypeId { get; set; }
    public static Guid EmailDataTypeId { get; set; }
    public static Guid PhoneDataTypeId { get; set; }

    public static string TextTypeValue { get; } = "TextLite";
    public static string EmailTypeValue { get; } = "EmailLite";
    public static string PhoneTypeValue { get; } = "PhoneLite";

    public static void InitializeDbForTests(ElectroformDbContext db)
    {
        DataType textDataType = new(TextTypeValue);
        DataType emailDataType = new(EmailTypeValue);
        DataType phoneDataType = new(PhoneTypeValue);

        db.DataTypes.AddRange(textDataType, emailDataType, phoneDataType);

        db.SaveChanges();

        DataType textDatatype = db.DataTypes.First(x => x.Value == TextTypeValue);

        TextDataTypeId = textDatatype.Id;
        EmailDataTypeId = db.DataTypes.First(x => x.Value == EmailTypeValue).Id;
        PhoneDataTypeId = db.DataTypes.First(x => x.Value == PhoneTypeValue).Id;

        DataTemplate dataTemplate = new("FirstName", TextDataTypeId);

        db.DataTemplates.Add(dataTemplate);

        textDatatype.DataTemplates.Add(dataTemplate);

        db.SaveChanges();
    }
}