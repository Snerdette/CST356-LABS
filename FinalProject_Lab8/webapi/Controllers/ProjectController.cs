using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entities;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly WorkContext _dbContext;

        public ProjectController(WorkContext dbContext)
        {
            _dbContext = dbContext;
        }
        /* 
        // GET api/values
        [HttpGet]
        public ActionResult<List<Project>> Get()
        {
            var project = _dbContext.Project
                .SingleOrDefault(p => p.ProjectId == project_id);

            if (project != null) {
                return project;
            } else {
                return NotFound();
            }
        }
        */

          [HttpGet]
        public ActionResult<List<Project>> GetAllProjects()
        {
            return Ok(_dbContext.Project.ToList());
        }


        /* 
        private List<Project> getProjects(){
            return _dbContext.getProjects();
        }
        */


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
