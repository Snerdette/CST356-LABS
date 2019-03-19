using System.Collections.Generic;
using Database.Entities;

public interface IProjectService
{
    List<ProjectDto> GetAllProjects();

    Project GetProjectById(long projectId);

    void AddProject(Project project);

    void UpdateProject(Project project);

    void DeleteProject(long projectId);
}