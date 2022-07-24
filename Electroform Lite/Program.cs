// See https://aka.ms/new-console-template for more information
using Electroform_Lite.Models;

TestDocumentClasses();

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
