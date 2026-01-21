using System;
using System.Collections.Generic;

namespace BlogApi.Models;

public partial class Blogger
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? RegTime { get; set; }

    public DateTime? ModTime { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
