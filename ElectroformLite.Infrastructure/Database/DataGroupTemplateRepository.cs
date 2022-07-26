﻿using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroformLite.Infrastructure.Database;

public class DataGroupTemplateRepository : IDataGroupTemplateRepository
{
    private readonly ElectroformDbContext _context;

    public DataGroupTemplateRepository(ElectroformDbContext context)
    {
        _context = context;
    }

    public void Create(DataGroupTemplate dataGroupTemplate)
    {
        _context.DataGroupTemplates.Add(dataGroupTemplate);
    }

    public void Delete(DataGroupTemplate dataGroupTemplate)
    {
        _context.DataGroupTemplates.Remove(dataGroupTemplate);
    }

    public async Task<DataGroupTemplate?> GetDataGroupTemplate(Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _context.DataGroupTemplates
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataGroupTemplate;
    }

    public async Task<DataGroupTemplate?> GetDataGroupTemplateWithDataGroups(Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _context.DataGroupTemplates
            .Include(d => d.DataGroups)
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataGroupTemplate;
    }

    public async Task<DataGroupTemplate?> GetDataGroupTemplateWithDataTemplates(Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _context.DataGroupTemplates
            .Include(d => d.DataTemplates)
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataGroupTemplate;
    }

    public async Task<DataGroupTemplate?> GetDataGroupTemplateWithAliasTemplates(Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _context.DataGroupTemplates
            .Include(d => d.AliasTemplates)
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataGroupTemplate;
    }

    public async Task<DataGroupTemplate?> GetDataGroupTemplateWithDataGroupType(Guid id)
    {
        DataGroupTemplate? dataGroupTemplate = await _context.DataGroupTemplates
            .Include(d => d.DataTemplates)
            .Include(d => d.DataGroupType)
            .SingleOrDefaultAsync(d => d.Id == id);

        return dataGroupTemplate;
    }

    public async Task<List<DataGroupTemplate>> GetDataGroupTemplates()
    {
        return await _context.DataGroupTemplates
            .Include(d => d.DataTemplates)
            .Include(d => d.DataGroupType)
            .ToListAsync();
    }

    public void Update(DataGroupTemplate dataGroupTemplate)
    {
        _context.DataGroupTemplates.Update(dataGroupTemplate);
    }
}
