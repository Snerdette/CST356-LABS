using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Database.Entities;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRespository;
    private readonly ILogger _logger;

    public BlogService(IBlogRepository blogRepository, ILoggerFactory loggerFactory)
    {
        _blogRespository = blogRepository;
        _logger = loggerFactory.CreateLogger("Controllers.BlogService");
    }

    public List<BlogDto> GetAllBlogs()
    {
        var blogDtos = new List<BlogDto>();

        foreach(var blog in _blogRespository.GetAllBlogs())
        {
            blogDtos.Add(new BlogDto {
                BlogId = blog.BlogId,
                Heading = blog.Heading,
                Body = blog.Body,
                Date = blog.Date
            });
        }

        return blogDtos;
    }

    public Blog GetBlogById(long blogId)
    {
        return _blogRespository.GetBlogById(blogId);
    }

    public void AddBlog(Blog blog)
    {
        _blogRespository.AddBlog(blog);
    }

    public void UpdateBlog(Blog blog)
    {
        _blogRespository.UpdateBlog(blog);
    }

    public void DeleteBlog(long blogId)
    {
        _blogRespository.DeleteBlog(blogId);
    }
}