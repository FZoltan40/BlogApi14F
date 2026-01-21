using System;
using System.Collections.Generic;

namespace BlogApi.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Post1 { get; set; }

    public DateTime? RegTime { get; set; }

    public DateTime? ModTime { get; set; }

    public int? Bloggerid { get; set; }

    public virtual Blogger? Blogger { get; set; }
}
