using Application.DAOInterfaces;
using Application.Post.DAOInterfaces;
using Application.Post.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Post.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDAO postDAO;
    private readonly IUserDAO userDAO;

    public PostLogic(IPostDAO postDao, IUserDAO userDao)
    {
        postDAO = postDao;
        userDAO = userDao;
    }

    public async Task<Shared.Models.Post> CreateAsync(PostCreationDTO dto)
    {
        User? user = await userDAO.GetByIdAsync(dto.Id);
        if (user == null)
        {
            throw new Exception($"User with id {dto.Id} was not found.");
        }

        ValidatePost(dto);
        Shared.Models.Post post = new Shared.Models.Post(user, dto.Title, dto.Description);
        user.Posts = new List<Shared.Models.Post>();
        user.Posts.Add(post);
        Shared.Models.Post created = await postDAO.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Shared.Models.Post>> GetAsync(SearchPostParametersDTO searchParameters)
    {
        return postDAO.GetAsync(searchParameters);
    }

    public async Task UpdateAsync(PostUpdateDTO dto)
    {
        Shared.Models.Post? existing = await postDAO.GetByIdAsync(dto.Id);
        if (existing == null)
        {
            throw new Exception($"Post with ID {dto.Id} not found!");
        }

        User? user = null;
        if (dto.OwnerId != null)
        {
            user = await userDAO.GetByIdAsync((int)dto.OwnerId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.OwnerId} was not found.");
            }
        }

        User userToUse = user ?? existing.Owner;
        string titleToUse = dto.Title ?? existing.Title;
        string descToUse = dto.Description ?? existing.Description;

            Shared.Models.Post updated = new(userToUse, titleToUse, descToUse)
        {
            Id = existing.Id
        };
        ValidatePost(updated);
    }

    private void ValidatePost(Shared.Models.Post post)
    {
        if (string.IsNullOrEmpty(post.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(post.Description)) throw new Exception("Description cannot be empty.");

    }
    private void ValidatePost(PostCreationDTO dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Description)) throw new Exception("Description cannot be empty.");
    }
}