using System.ComponentModel.DataAnnotations;

namespace api;

public class PostArticleDTO
{
    [Required]
    [MaxLength(30)]
    [MinLength(5)]
    public string Headline { get; set; }
   
    [RegularExpression("^(Bob|Rob|Dob|Lob)$")]
    public string Author { get; set; }
    
    [Required]
    [MaxLength(1000)]
    public string Body { get; set; }
    public string ArticleImgUrl { get; set; }

}