using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entities;

namespace Database.Entities
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly WorkContext _dbContext;

        public BlogController(WorkContext dbContext)
        {
            _dbContext = dbContext;
        }
       
         [HttpGet]
        public ActionResult<List<Blog>> GetAllBlogs()
        {
            return Ok(_dbContext.Blog.ToList());
        }
        
         public ActionResult<int> getBlogCount(Blog blog)
        {
            return Blog.BlogCount;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
