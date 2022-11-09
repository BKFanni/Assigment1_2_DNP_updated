using Shared.DTOs;
using Shared.Models;

namespace HttpClient.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreateAsync(PostCreationDTO dto);
    Task<ICollection<Post>> GetAsync(
        string? userName, 
        int? userId,
        string? titleContains
    );
    
    Task<IEnumerable<Post>> GetPosts(string? titleContains=null);
}