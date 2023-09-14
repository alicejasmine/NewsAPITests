using api.Model;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> _logger;
    private readonly IArticleService _service;

    public Controller(ILogger<Controller> logger, IArticleService service)
    {
        _service = service;
        _logger = logger;
    }
    
    //New article post
    
    [HttpPost]
    [Route("/api/articles")]
    public Article ControllerMethod([FromBody]PostArticleDTO article)
    {
    
        var newArticle = _service.CreateArticle(article.Headline, article.Author, article.Body, article.ArticleImgUrl);
      
        
        return newArticle;
    }
    
    //GET news feed
    
    [HttpGet]
    [Route("/api/feed")]
    public List<NewsFeed> GetNewsFeed()
    {
        return _service.GetNewsFeed();
    }
    
    
    //get Full Article: Retrieve an article by ID with full details.
    [HttpGet]
    [Route("/api/articles/{articleId}")]
    public Article GetArticle([FromRoute]int articleId)
    {
        return _service.GetArticle(articleId);
    }
    
    
    //delete
    
    [HttpDelete]
    [Route("/api/articles/{articleId}")]
    public object DeleteArticle([FromRoute] int articleId)
    {
        return _service.DeleteArticle(articleId);
    }
    
    //update id
    [HttpPut]
    [Route("/api/articles/{articleId}")]
    public Article UpdateArticle([FromBody] Article article, [FromRoute] int articleId) //article to get new data, id to identify article
    {
        return _service.UpdateArticle(article, articleId);
    }
    
    
    //search
    [HttpGet]
    [Route("/api/articles")]
    public List<Article> GetSearchedArticle([FromQuery] GetSearchArticleDTO getSearchArticleDto)
    {
        return _service.SearchArticle(getSearchArticleDto.SearchTerm,getSearchArticleDto.PageSize);
    }
}
