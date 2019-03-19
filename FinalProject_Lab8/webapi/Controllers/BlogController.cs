using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Database.Entities;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ILogger _logger;

        public BlogController(IBlogService blogService, ILoggerFactory loggerFactory)
        {
            _blogService = blogService;
            _logger = loggerFactory.CreateLogger("Controllers.BlogController");
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<BlogDto>> GetAllBlogs()
        {
            _logger.LogDebug("Getting all blogs");
            // return Ok(_dbContext.Blog.Include(p => p.Manufacturer).ToList());

            return _blogService.GetAllBlogs();
        }

        [HttpGet("{blogId}")]
        public ActionResult<Blog> GetBlog(int blogId)
        {
            var blog = _blogService.GetBlogById(blogId);

            if (blog != null) {
                return blog;
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Blog> AddBlog(Blog blog)
        {
            _blogService.AddBlog(blog);

            // return CreatedAtAction(nameof(GetBlog), new { id = blog.BlogId }, blog);

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
        }

        [HttpPut("{blogId}")]
        public ActionResult UpdateBlog(long blogId, Blog blogUpdate)
        {
            blogUpdate.BlogId = blogId;
            _blogService.UpdateBlog(blogUpdate);

            return NoContent();
        }

        [HttpDelete("{blogId}")]
        public ActionResult DeleteBlog(int blogId)
        {
            _blogService.DeleteBlog(blogId);

            return Ok();
        }
    }
}