using Shared.Models;

namespace Shared.DTOs;

public class SearchPostParametersDTO
{
    public  string? TitleContains { get; }
    public SearchPostParametersDTO(string? titleContains)
    {
        TitleContains = titleContains;
    }
    
    
}