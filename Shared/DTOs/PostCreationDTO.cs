using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public int Id { get; set; }
    
    public PostCreationDTO(int id,string title, string description, bool isCompleted)
    {
        Title = title;
        Description = description;
        Id = id;
        IsCompleted = isCompleted;
    }

    public PostCreationDTO(int selectedUserId, string postTitle, string postDesc)
    {
        Id = selectedUserId;
        Title = postTitle;
        Description = postDesc;
    }

    public PostCreationDTO()
    {
        
    }
}