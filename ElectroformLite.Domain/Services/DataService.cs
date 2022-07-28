using ElectroformLite.Domain.Models;

namespace ElectroformLite.Domain.Services;

public class DataService
{
    public static List<Data> GetData()
    {
        List<Data> data = new();

        Data firstName = new(0, "FirstName", "John");
        Data lastName = new(1, "LastName", "Doh");
        Data email = new(2, "Email", "john.doh@gmail.com");
        Data phone = new(3, "PhoneNumber", "1234567890");

        data.Add(firstName);
        data.Add(lastName);
        data.Add(email);
        data.Add(phone);

        return data;
    }
}
