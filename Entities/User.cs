using System;
using System.Collections.Generic;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? UserFname { get; set; }

    public string? UserLname { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
