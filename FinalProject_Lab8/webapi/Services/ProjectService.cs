using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Database.Entities;
using ProjectBusinessRules;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRespository;
    private readonly ILogger _logger;

    public ProjectService(IProjectRepository projectRepository, ILoggerFactory loggerFactory)
    {
        _projectRespository = projectRepository;
        _logger = loggerFactory.CreateLogger("Controllers.ProjectService");
    }

    public List<ProjectDto> GetAllProjects()
    {
        var projectDtos = new List<ProjectDto>();
        var projectCount = 0;

        foreach(var project in _projectRespository.GetAllProjects())
        {
            projectDtos.Add(new ProjectDto {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Type = project.Type,
                Site = project.Site,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
            });
            if (ProjectBusinessRules.isGroupProject(project))
            {
                _logger.LogInformation("Found isGroup project: " + project.ProjectId);
            }
            projectCount++;
        }

        return projectDtos;
    }

    public Project GetProjectById(long projectId)
    {
        return _projectRespository.GetProjectById(projectId);
    }
     
    public bool isGroupProject(long projectId)
    {
        var project = GetProjectById(projectId);
        if(project.Type == "Group"){
            return true;
        } else {
            return false;
        }
        
    }
    
    public void AddProject(Project project)
    {
        _projectRespository.AddProject(project);
    }

    public void UpdateProject(Project project)
    {
        _projectRespository.UpdateProject(project);
    }

    public void DeleteProject(long projectId)
    {
        _projectRespository.DeleteProject(projectId);
    }
}