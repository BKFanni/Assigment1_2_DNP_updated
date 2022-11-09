using Application.Post.DAOInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class PostFileDAO : IPostDAO
{
    private readonly FileContext Context;


    public PostFileDAO(FileContext context)
    {
        Context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;

        if (Context.Posts.Any())
        {
            postId = Context.Posts.Max(p => p.Id);
            postId++;
        }

        post.Id = postId;
        Context.Posts.Add(post);
        Context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO searchParameters)
    {
        IEnumerable<Post> result = Context.Posts.AsEnumerable();


        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            result = result.Where(p =>
                p.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result);

    }

    public Task UpdateAsync(Post post)
    {
        Post? existing = Context.Posts.FirstOrDefault(p => p.Id == post.Id);
        if (existing == null)
        {
            throw new Exception($"Todo with id {post.Id} does not exist!");
        }

        Context.Posts.Remove(existing);
        Context.Posts.Add(post);
    
        Context.SaveChanges();
    
        return Task.CompletedTask;
    }

    public Task<Post> GetByIdAsync(int id)
    {
        Post? existing = Context.Posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(existing);
    }
}