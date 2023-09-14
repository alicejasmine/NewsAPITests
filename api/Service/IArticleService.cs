namespace api.Model;

public interface IArticleService
{
    Article CreateArticle(string Headline, string Author, string Body, string ArticleImgUrl);
    List<NewsFeed> GetNewsFeed();
    Article GetArticle(int id);
    bool DeleteArticle(int id);
   Article UpdateArticle(Article article, int articleId);
   List<Article> SearchArticle(string searchterm, int pagesize);
}