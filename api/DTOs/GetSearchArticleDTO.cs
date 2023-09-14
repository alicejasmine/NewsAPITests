using System.ComponentModel.DataAnnotations;

namespace api.Model;

public class GetSearchArticleDTO
{
    [MinLength(3)]
    public string? SearchTerm { get; set; }

    [Range(1, int.MaxValue)]
    public int PageSize { get; set; }
}