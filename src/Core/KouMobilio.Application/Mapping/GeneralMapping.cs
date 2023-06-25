using AutoMapper;
using KouMobilio.Application.DTOs.Project.Inputs;
using KouMobilio.Application.DTOs.Project.Outputs;
using KouMobilio.Domain.Entities;
using KouMobilio.Domain.Entities.RestService;
using KouMobilio.Domain.Entities.RestService.ValueObjects;

namespace KouMobilio.Application.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        //Project
        CreateMap<CreateProjectDto, Project>();
        CreateMap<UpdateProjectDto, Project>();
        CreateMap<Project, ProjectDto>();
        CreateMap<Project, ProjectDetailDto>();
    }
}