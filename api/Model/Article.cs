using System.ComponentModel.DataAnnotations;

namespace api.Model;

public class Article
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
    public int ArticleId { get; set; }
    public string ArticleImgUrl { get; set; }

}