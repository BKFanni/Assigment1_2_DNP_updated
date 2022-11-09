using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDTO userToCreate);
    public Task<IEnumerable<User>> GetAsync(SearchUserParameterDTO searchParameters);
}