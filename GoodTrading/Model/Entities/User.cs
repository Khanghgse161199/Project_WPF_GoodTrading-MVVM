using System;
using System.Collections.Generic;

namespace GoodTrading.Model.Entities;

public partial class User
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
