﻿namespace AngularWebApi.Infrastructure.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Province> Provinces { get; set; } = [];
}