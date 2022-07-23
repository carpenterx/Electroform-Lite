// See https://aka.ms/new-console-template for more information
using Electroform_Lite.Models;

Admin admin = new("admin", "password");
Console.WriteLine(admin.Name);
