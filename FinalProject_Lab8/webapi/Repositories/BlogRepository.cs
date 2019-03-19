using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Database;
using Database.Entities;
using System;

public class BlogRepository : IBlogRepository
{
    private readonly WorkContext _dbContext;
    private readonly ILogger _logger;

    public BlogRepository(WorkContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
        _logger = loggerFactory.CreateLogger("Controllers.BlogRepository");
    }

    public List<Blog> GetAllBlogs()
    {
        try
        {
            return _dbContext.Blog.ToList();
        } 
        catch(Exception ex)
        {
            _logger.LogError("Failed to get blogs.", ex);
            
            return new List<Blog>();
        }
    }

    public Blog GetBlogById(long blogId)
    {
        return _dbContext.Blog.SingleOrDefault(p => p.BlogId == blogId);
    }

    public void AddBlog(Blog blog)
    {
        _dbContext.Blog.Add(blog);
        _dbContext.SaveChanges();
    }

    public void UpdateBlog(Blog blogUpdate)
    {
        var blog = GetBlogById(blogUpdate.BlogId);

        if (blog != null)
        {
            blog.Heading = blogUpdate.Heading;
            blog.Body = blogUpdate.Body;
            blog.Date = blogUpdate.Date;

            _dbContext.Update(blog);

            _dbContext.SaveChanges();
        }
    }

    public void DeleteBlog(long blogId)
    {
        var blog = new Blog { BlogId = blogId };

        _dbContext.Blog.Attach(blog);
        _dbContext.Blog.Remove(blog);
        _dbContext.SaveChanges();
    }
}