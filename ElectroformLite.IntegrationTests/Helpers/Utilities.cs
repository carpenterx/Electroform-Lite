using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure.Database;

namespace ElectroformLite.IntegrationTests.Helpers;

public static class Utilities
{
    public static Guid TextDataTypeId { get; set; }
    public static Guid EmailDataTypeId { get; set; }

    public static void InitializeDbForTests(ElectroformDbContext db)
    {
        var textDataType = new DataType("TextLite");
        var emailDataType = new DataType("EmailLite");
        var phoneDataType = new DataType("PhoneLite");

        db.DataTypes.AddRange(textDataType, emailDataType, phoneDataType);

        db.SaveChanges();

        TextDataTypeId = db.DataTypes.First(x => x.Value == "TextLite").Id;
        EmailDataTypeId = db.DataTypes.First(x => x.Value == "EmailLite").Id;
    }
}