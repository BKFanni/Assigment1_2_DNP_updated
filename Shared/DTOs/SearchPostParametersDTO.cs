using Shared.Models;

namespace Shared.DTOs;

public class SearchPostParametersDTO
{
    public  string? TitleContains { get; }
    public int? UserId { get; }
    
    public string? UserName { get; }
    public bool? completedStatus { get; }
    public SearchPostParametersDTO(int? UserID, string? UserName, string? titleContains, bool? completedStatus)
    {
        UserId = UserID;
        this.UserName = UserName;
        TitleContains = titleContains;
        this.completedStatus = completedStatus;
    }
    
   
    
    
}