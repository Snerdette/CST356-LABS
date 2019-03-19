using System.Collections.Generic;
using Database.Entities;

public interface IBlogRepository
{
    List<Blog> GetAllBlogs();

    Blog GetBlogById(long blogId);

   // bool isGroupBlog(Blog blog);

    void AddBlog(Blog blog);

    void UpdateBlog(Blog blog);

    void DeleteBlog(long blogId);
}