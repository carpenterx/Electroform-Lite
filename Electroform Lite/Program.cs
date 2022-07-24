// See https://aka.ms/new-console-template for more information
using Electroform_Lite.Models;

TestDocumentClasses();
TestEnumerable();

void TestDocumentClasses()
{
    Document document = new();
    PDFDocument pdfDocument = new();
    SealedPDFDocument sealedPDFDocument = new();
    SpecialPDFDocument specialPDFDocument = new();
    document.Export();
    pdfDocument.Export();
    pdfDocument.Export("watermark");
    sealedPDFDocument.Export();
    specialPDFDocument.Export();
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
    Users users2 = (Users)users.Clone();

    foreach (User user in users)
    {
        Console.WriteLine($"User {user.Name} has password: {user.Password}");
    }

    foreach (User user in users2)
    {
        Console.WriteLine($"User {user.Name} has password: {user.Password}");
    }
}
