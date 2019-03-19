using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Database;
using Database.Entities;
using System;

public class ProjectRepository : IProjectRepository
{
    private readonly WorkContext _dbContext;
    private readonly ILogger _logger;

    public ProjectRepository(WorkContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
        _logger = loggerFactory.CreateLogger("Controllers.ProjectRepository");
    }

    public List<Project> GetAllProjects()
    {
        try
        {
            return _dbContext.Project.ToList();
        } 
        catch(Exception ex)
        {
            _logger.LogError("Failed to get projects.", ex);
            
            return new List<Project>();
        }
    }

    public Project GetProjectById(long projectId)
    {
        return _dbContext.Project.SingleOrDefault(p => p.ProjectId == projectId);
    }

    public bool isGroup(Project project){
       // _dbContext.getProjectById(project);
       /* 
       if(_dbcontext.Project.isGroup(project)){
           return true;
       }
       var id = project.ProjectId;
       bool isGroup = _dbContext.getProjectById(id);
        if(project.getIsGroup()){
            isGroup = true;
        }*/

        var isGroup = true;
        return isGroup;
    }

    public void AddProject(Project project)
    {
        _dbContext.Project.Add(project);
        _dbContext.SaveChanges();
    }

    public void UpdateProject(Project projectUpdate)
    {
        var project = GetProjectById(projectUpdate.ProjectId);

        if (project != null)
        {
            project.Title = projectUpdate.Title;
            project.Type = projectUpdate.Type;
            //project.Site = projectUpdate.Site;
            //project.StartDate = projectUpdate.StartDate;
            //project.EndDate = projectUpdate.EndDate;


            _dbContext.Update(project);

            _dbContext.SaveChanges();
        }
    }

    public void DeleteProject(long projectId)
    {
        var project = new Project { ProjectId = projectId };

        _dbContext.Project.Attach(project);
        _dbContext.Project.Remove(project);
        _dbContext.SaveChanges();
    }
}