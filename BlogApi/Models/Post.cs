using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlogApi.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Post1 { get; set; }

    public DateTime? RegTime { get; set; }

    public DateTime? ModTime { get; set; }

    public int? Bloggerid { get; set; }

    [JsonIgnore]
    public virtual Blogger? Blogger { get; set; }
}
