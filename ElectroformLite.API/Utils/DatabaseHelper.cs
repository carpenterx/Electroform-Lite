using ElectroformLite.Domain.Models;
using ElectroformLite.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ElectroformLite.API.Utils;

public static class DatabaseHelper
{
    public static void Initialize(ElectroformDbContext dbContext)
    {

    }

    public static async Task FixTemplatesContent(ElectroformDbContext dbContext)
    {
        var templates = await dbContext.Templates.ToListAsync();
        foreach (var template in templates)
        {
            template.Content = FixContent(template.Name, template.Content);
        }
        dbContext.SaveChanges();
    }

    private static string FixContent(string name, string content)
    {
        string fixedContent = name + " Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice\\n\\nSubsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de telefon [Contact.PhoneNumber], solicit a-mi fi atribuit credential in vederea platii prin www.ghiseul.ro\\n\t- Sunt de acord ca orice corespondenta sa fie expediata doar pe adresa de e-mail mai sus mentionata sau telefonic;\\n\t- Ridicarea credentialului se va face personal sau prin mandatar, daca nu este comunicat la adresa de e-mail mai sus mentionata;\\n\t- Plata se va efectua doar prin intermediul unui card bancar;\\n\t- Atasez la prezenta cerere, copie a actului de identitate a numitului/ei [Person.FirstName] [Person.LastName]\\n\\nData {DateTime.Today}\t\t\t\t\t\t\tSemnatura";
        fixedContent = Regex.Replace(fixedContent, "\\t", "    ");

        return fixedContent;
    }
}
