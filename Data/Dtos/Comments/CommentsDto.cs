namespace marketplace.Data.Dtos
{
    public record CommentDto(int Id, string Name, string Message);
    public record CreateCommentDto(string Name, string Message);
    public record UpdateCommentDto(string Message);
}

