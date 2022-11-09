using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text.Json;
using HttpClient.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClient.Implementations;

public class PostHttpClient : IPostService
{
    private readonly System.Net.Http.HttpClient client;
    private IPostService _postServiceImplementation;

    public PostHttpClient(System.Net.Http.HttpClient client)
    {
        this.client = client;
    }

    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts", dto);
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }
                
                
                Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
                Console.WriteLine(post);
                return post;
    }

    public async Task<ICollection<Post>> GetAsync(string? userName, int? userId, string? titleContains)
    {
        HttpResponseMessage response = await client.GetAsync("/posts");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions{
            
        PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<IEnumerable<Post>> GetPosts(string? titleContains = null)
    {
        string uri = "/posts";
        if (!string.IsNullOrEmpty(titleContains))
        {
            uri += $"?title={titleContains}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}