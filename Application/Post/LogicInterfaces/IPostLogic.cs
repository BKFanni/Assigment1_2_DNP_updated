using Shared.DTOs;

namespace Application.Post.LogicInterfaces;

public interface IPostLogic
{
    Task<Shared.Models.Post> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<Shared.Models.Post>> GetAsync(SearchPostParametersDTO searchParameters);
    Task UpdateAsync(PostUpdateDTO post);
}