namespace Shared.DTOs;

public class PostUpdateDTO
{
    public int Id { get; }
    public int OwnerId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public PostUpdateDTO(int id)
    {
        Id = id;
    }
}