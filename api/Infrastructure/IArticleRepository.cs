using api.Model;

namespace api;

public interface IArticleRepository
{
    Article CreateArticle(string Headline, string Author, string Body, string ArticleImgUrl);
    Article GetArticle(int id);
    List<NewsFeed> GetNewsFeed();
    bool DeleteArticle(int id);
    Article UpdateArticle(Article article, int articleId);
    List<Article> SearchArticle(string searchterm, int pagesize);
}