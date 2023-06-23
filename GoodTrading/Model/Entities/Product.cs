using System;
using System.Collections.Generic;

namespace GoodTrading.Model.Entities;

public partial class Product
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public virtual User User { get; set; } = null!;
}
