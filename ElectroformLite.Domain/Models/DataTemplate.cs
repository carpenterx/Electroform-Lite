﻿using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataTemplate
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Placeholder { get; set; }

    public ICollection<Data> UserData { get; set; }

    public DataTemplate()
    {

    }

    public DataTemplate(string placeholder, ICollection<Data> userData)
    {
        Placeholder = placeholder;
        UserData = userData;
    }
}
