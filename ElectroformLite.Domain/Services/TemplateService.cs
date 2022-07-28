using ElectroformLite.Domain.Models;

namespace ElectroformLite.Domain.Services;

public class TemplateService
{
    public static List<Template> GetTemplates()
    {
        List<Template> templates = new();

        Template template = new()
        {
            Id = 0,
            Name = "Template for Cerere Alocare Credentiale Pentru Plata Impozitelor Și Taxelor Locale Pentru Persoane Fizice",
            Content = @"Subsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de
telefon [Contact.PhoneNumber], solicit a-mi fi atribuit credențial în
vederea plății prin www.ghiseul.ro
	- Sunt de acord ca orice corespondență să fie expediată doar pe adresa
de e-mail mai sus menționată sau telefonic;
	- Ridicarea credențialului se va face personal sau prin mandatar, dacă
nu este comunicat la adresa de e-mail mai sus menționată;
	- Plata se va efectua doar prin intermediul unui card bancar;
	- Atașez la prezenta cerere, copie a actului de identitate a numitului/ei
[Person.FirstName] [Person.LastName]

Data {DateTime.Today}							Semnătura"
        };

        templates.Add(template);

        return templates;
    }
}
