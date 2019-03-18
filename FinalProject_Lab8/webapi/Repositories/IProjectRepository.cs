using System.Collections.Generic;
using Database.Entities;

public interface IProjectRepository
{
    List<Project> GetAllProjects();
    Project GetProjectById(long projectId);

    void AddProject(Project project);

    void UpdateProject(Project project);

    void DeleteProject(long projectId);
}