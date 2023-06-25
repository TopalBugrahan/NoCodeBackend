using KouMobilio.Application.Abstraction.Services;
using KouMobilio.Application.DTOs.Project.Inputs;
using KouMobilio.Application.DTOs.Project.Outputs;
using KouMobilio.Application.Repositories;
using KouMobilio.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KouMobilio.WebAPI.Controllers.v1;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/v1/projects")]
public class ProjectController : BaseController, IProjectService
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public Task<Guid> CreateAsync(CreateProjectDto input)
    {
        return _projectService.CreateAsync(input);
    }

    [HttpGet("{id}")]
    public Task<ProjectDetailDto> GetAsync(Guid id)
    {
        return _projectService.GetAsync(id);
    }

    [HttpGet]
    public Task<List<ProjectDto>> GetListAsync()
    {
        return _projectService.GetListAsync();
    }

    [HttpPut("{id}")]
    public Task UpdateAsync(Guid id, UpdateProjectDto input)
    {
        return _projectService.UpdateAsync(id, input);
    }

    [HttpPut("{id}/name/{name}")]
    public Task UpdateNameAsync(Guid id, string name)
    {
        return _projectService.UpdateNameAsync(id, name);   
    }

    [HttpDelete("{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _projectService.DeleteAsync(id);
    }

    [HttpGet("{id}/download")]
    public Task<IActionResult> DownloadAsync(Guid id)
    {
        return _projectService.DownloadAsync(id);
    }
}