namespace Shared.DTOs;

public class UserCreationDTO
{
    public string UserName { get;}
    public string Password { get; }
    public string Name { get; }
    public int Age { get; }

    public UserCreationDTO(string userName, string password, int age, string name)
    {
        UserName = userName;
        Password = password;
        Age = age;
        Name = name;
    }

  
}