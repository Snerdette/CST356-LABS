using System.Collections.Generic;
using Database.Entities;

public interface IProjectService
{
    List<ProjectDto> GetAllProjects();

    bool isGroupProject(Project project);
}