using Microsoft.OpenApi.Expressions;

namespace api.Model;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }


    public Article CreateArticle(string Headline,string Author, string Body, string ArticleImgUrl)
    {
        try
        {
            return _articleRepository.CreateArticle(Headline,Author,Body,ArticleImgUrl);
        }
        catch (Exception)
        {
            throw new Exception("Could not create article");
        }
    }

    public List<NewsFeed> GetNewsFeed()
    {
        try
        {
            return _articleRepository.GetNewsFeed();
        }
        catch (Exception )
        {
            throw new Exception("Could not get news feed");
        }
    }

    public Article GetArticle(int id)
    {
        try
        {
            return _articleRepository.GetArticle(id);
        }
        catch (Exception)
        {
            throw new Exception("Could not get article");
        }
    }


    public bool DeleteArticle(int id)
    {
        try
        {
            return _articleRepository.DeleteArticle(id);
        }
        catch (Exception)
        {
            throw new Exception("Could not delete article");
        }
    }


    public Article UpdateArticle(Article article, int articleId)
    {
        try
        {
            return _articleRepository.UpdateArticle(article,articleId);
        }
        catch (Exception)
        {
            throw new Exception("Could not update article");
        }
    }


    public List<Article> SearchArticle(String searchterm, int pagesize )
    {
        try
        {
            return _articleRepository.SearchArticle(searchterm,pagesize);
        }
        catch (Exception)
        {
            throw new Exception("Could not search for articles");
        }
    }
}