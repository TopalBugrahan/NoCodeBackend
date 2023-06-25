using KouMobilio.Application.DTOs.Project.Inputs;
using KouMobilio.Application.DTOs.Project.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace KouMobilio.Application.Abstraction.Services;

public interface IProjectService
{
    Task<Guid> CreateAsync(CreateProjectDto input);
    Task<ProjectDetailDto> GetAsync(Guid id);
    Task<List<ProjectDto>> GetListAsync();
    Task UpdateAsync(Guid id, UpdateProjectDto input);
    Task UpdateNameAsync(Guid id, string name);
    Task DeleteAsync(Guid id);
    Task<IActionResult> DownloadAsync(Guid id);
}