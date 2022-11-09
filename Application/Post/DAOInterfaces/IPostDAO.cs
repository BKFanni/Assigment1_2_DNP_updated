using Shared.DTOs;
using Shared.Models;

namespace Application.Post.DAOInterfaces;

public interface IPostDAO
{
    Task<Shared.Models.Post> CreateAsync(Shared.Models.Post post);
    Task<IEnumerable<Shared.Models.Post>> GetAsync(SearchPostParametersDTO searchParameters);
    Task UpdateAsync(Shared.Models.Post post);
    Task<Shared.Models.Post> GetByIdAsync(int id);
    }