namespace BlogApi.Models.DTOs
{
    public record AddPostDto(string? Title, string? Post1, int? Bloggerid);
    public record UpdatePostDto(string? Title, string? Post1);

    //------------------------------
}
