using System.Text.Json.Serialization;

namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public string Title{ get;private  set; }
    public string Description{ get; set; }
    public bool IsCompleted{ get; set; }
    
    public User Owner{ get;private set; }

     public Post(User owner, string title, string description, bool isCompleted)
     { 
         Owner=owner;
         Title = title;
         Description = description;
         IsCompleted = isCompleted;
     }
     private Post(){}
    
    //public List<User>? UserPostMatch { get; set; }
    
}