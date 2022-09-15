using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure.Database;

namespace ElectroformLite.IntegrationTests.Helpers;

public static class Utilities
{
    public static void InitializeDbForTests(ElectroformDbContext db)
    {
        var textDataType = new DataType("TextLite");
        var emailDataType = new DataType("EmailLite");
        var PhoneDataType = new DataType("PhoneLite");

        db.DataTypes.AddRange(textDataType, emailDataType, PhoneDataType);

        db.SaveChanges();
    }
}
