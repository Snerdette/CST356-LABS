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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger _logger;

        public ProjectController(IProjectService projectService, ILoggerFactory loggerFactory)
        {
            _projectService = projectService;
            _logger = loggerFactory.CreateLogger("Controllers.ProjectController");
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<ProjectDto>> GetAllProjects()
        {
            return _projectService.GetAllProjects();
        }

        [HttpGet("{projectId}")]
        public ActionResult<Project> GetProjectById(int projectId)
        {
            var project = _projectService.GetProjectById(projectId);

            if (project != null) {
                return project;
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Project> AddProject(Project project)
        {
            _projectService.AddProject(project);

            // return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
        }

        [HttpPut("{projectId}")]
        public ActionResult UpdateProject(long projectId, Project projectUpdate)
        {
            projectUpdate.ProjectId = projectId;
            _projectService.UpdateProject(projectUpdate);

            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public ActionResult DeleteProject(int projectId)
        {
            _projectService.DeleteProject(projectId);

            return Ok();
        }
    }
}