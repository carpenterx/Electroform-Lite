﻿using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface ITemplateRepository
{
    void Create(Template template);
    void Delete(int id);
    void Update(Template template);
    Data GetTemplate(int id);
    List<Template> GetTemplates();
}
