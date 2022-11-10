namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public string Title{ get; set; }
    public string Description{ get; set; }
    public bool IsCompleted{ get; set; }
    public User Owner{ get; set; }

     public Post(User owner, string title, string description, bool isCompleted)
     { 
         Owner=owner;
         Title = title;
         Description = description;
         IsCompleted = isCompleted;
     }
    
    public List<User>? UserPostMatch { get; set; }
    
}