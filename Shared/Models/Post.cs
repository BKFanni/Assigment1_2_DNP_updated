namespace Shared.Models;

public class Post
{
    public int Id;
    public string Title;
    public string Description;
    public User Owner;

    public Post(User owner, string title, string description)
    {
        Owner=owner;
        Title = title;
        Description = description;
    }
    
    public List<User>? UserPostMatch { get; set; }
}