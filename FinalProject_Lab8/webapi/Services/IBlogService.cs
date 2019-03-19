using System.Collections.Generic;
using Database.Entities;

public interface IBlogService
{
    List<BlogDto> GetAllBlogs();

    Blog GetBlogById(long blogId);

    void AddBlog(Blog blog);

    void UpdateBlog(Blog blog);

    void DeleteBlog(long blogId);
}