using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDTO
{
    public string Title { get; }
    public string Description { get; }

    public int Id { get; }
    
    public PostCreationDTO(int id,string title, string description)
    {
        Title = title;
        Description = description;
        Id = id;
    }
    
}