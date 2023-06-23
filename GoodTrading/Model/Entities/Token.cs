using System;
using System.Collections.Generic;

namespace GoodTrading.Model.Entities;

public partial class Token
{
    public string UserId { get; set; } = null!;

    public string AccessToken { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }

    public string Id { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
