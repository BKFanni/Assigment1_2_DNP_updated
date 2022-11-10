using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDTO
{
    public string Title { get; }
    public string Description { get; }
    public bool IsCompleted { get; }

    public int Id { get; }
    
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
}