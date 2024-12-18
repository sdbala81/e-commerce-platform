﻿using System.Text.Json.Serialization;

namespace Ecommerce.Inventory.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    [JsonIgnore] public ProductCategory? Category { get; set; }

    public int CategoryId { get; set; }
}