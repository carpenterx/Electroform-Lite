// See https://aka.ms/new-console-template for more information
using Electroform_Lite.Models;

//TestDocumentClasses();
TestEnumerable();

void TestDocumentClasses()
{
    Document document = new();
    PDFDocument pdfDocument = new();
    document.Export();
    pdfDocument.Export();
    pdfDocument.Export("watermark");
}

/*void TestUserClasses()
{
    Admin admin = new("admin", "password");
    Console.WriteLine(admin.Name);
}*/

void TestEnumerable()
{
    User[] usersArray = new User[3]
    {
        new User("User1", "password1"),
        new User("User2", "1234"),
        new User("User3", "123456"),
    };


    Users users = new(usersArray);
    usersArray[0].Name = "Bla";
    foreach (User user in users)
    {
        Console.WriteLine($"User {user.Name} has password: {user.Password}");
    }
}
