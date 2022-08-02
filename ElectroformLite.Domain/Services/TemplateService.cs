﻿using ElectroformLite.Domain.Models;

namespace ElectroformLite.Domain.Services;

public class TemplateService
{
    public static List<Template> GetTemplates()
    {
        List<Template> templates = new();

        Template template = new()
        {
            Id = 0,
            Name = "Template for Cerere Alocare Credentiale Pentru Plata Impozitelor Si Taxelor Locale Pentru Persoane Fizice",
            Content = @"Subsemnatul/a [Person.FirstName] [Person.LastName], e-mail [Contact.Email], numar de
telefon [Contact.PhoneNumber], solicit a-mi fi atribuit credential in
vederea platii prin www.ghiseul.ro
	- Sunt de acord ca orice corespondenta sa fie expediata doar pe adresa
de e-mail mai sus mentionata sau telefonic;
	- Ridicarea credentialului se va face personal sau prin mandatar, daca
nu este comunicat la adresa de e-mail mai sus mentionata;
	- Plata se va efectua doar prin intermediul unui card bancar;
	- Atasez la prezenta cerere, copie a actului de identitate a numitului/ei
[Person.FirstName] [Person.LastName]

Data {DateTime.Today}							Semnatura"
        };

        templates.Add(template);

        return templates;
    }
}