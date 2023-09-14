using api.Model;
using Dapper;
using Npgsql;

namespace api;

public class ArticleRepository : IArticleRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public ArticleRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }


    public Article CreateArticle(string Headline, string Author, string Body, string ArticleImgUrl)
    {
        var sql =
            $@" INSERT INTO news.articles(headline,author,body,articleimgurl) VALUES (@Headline,@Author, @Body, @ArticleImgUrl)
 RETURNING 
articleid as {nameof(Article.ArticleId)},
 headline as {nameof(Article.Headline)},
 body as {nameof(Article.Body)},
 author as {nameof(Article.Author)},
 articleimgurl as {nameof(Article.ArticleImgUrl)}                                             
 
 ;";


        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new { Headline, Body, Author, ArticleImgUrl });
        }
    }


    public Article GetArticle(int id)
    {
        var sql =
            $@" SELECT 
                  articles.headline AS Headline,
                  articles.author AS Author,
                  articles.body AS Body,
                  articles.articleid AS ArticleId,
                  articles.articleimgurl AS ArticleImgUrl
 
     FROM news.articles WHERE articles.articleid=@id;";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirstOrDefault<Article>(sql, new { id });
        }
    }

    public List<NewsFeed> GetNewsFeed()
    {
        var sql =
            $@"SELECT articles.articleid AS ArticleId,
                  articles.headline AS Headline,
                  LEFT(articles.body, 50) AS Body,
                  articles.articleimgurl AS ArticleImgUrl
          FROM news.articles";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<NewsFeed>(sql).ToList();
        }
    }

    public bool DeleteArticle(int articleId)
    {
        var sql =
            $@" DELETE FROM news.articles WHERE articleid=@articleId;";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new { articleId }) == 1; //execute returns number of affected rows
        }
    }


    public Article UpdateArticle(Article article, int articleId)
    {
        var sql =
            $@" UPDATE news.articles SET headline=@headline, body=@body, author=@author, articleimgurl=@articleimgurl
 WHERE articleid=@articleId
 RETURNING 
 articleid as {nameof(Article.ArticleId)},
 headline as {nameof(Article.Headline)},
 body as {nameof(Article.Body)},
 author as {nameof(Article.Author)},
 articleimgurl as {nameof(Article.ArticleImgUrl)};";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql,
                new { articleid = articleId, article.Headline, article.Body, article.Author, article.ArticleImgUrl });
        }

    }

    public List<Article> SearchArticle(String searchterm, int pagesize)
    {
        var sql =
            $@" SELECT * FROM news.articles
 WHERE headline LIKE @searchterm OR body LIKE @searchterm
 LIMIT @pagesize;";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Article>(sql, new { searchterm = $"%{searchterm}%", pagesize }).ToList();
        }
    }
}