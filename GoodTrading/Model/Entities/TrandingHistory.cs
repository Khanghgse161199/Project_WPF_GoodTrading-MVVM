using System;
using System.Collections.Generic;

namespace GoodTrading.Model.Entities;

public partial class TrandingHistory
{
    public string Id { get; set; } = null!;

    public string FromGood { get; set; } = null!;

    public string ToGood { get; set; } = null!;

    public string FromUser { get; set; } = null!;

    public string ToUser { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}
