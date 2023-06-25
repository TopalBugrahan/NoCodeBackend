using FluentValidation;
using KouMobilio.Application.DTOs.Project.Inputs;
using KouMobilio.Domain.Entities;

namespace KouMobilio.Application.Validators.Projects;

public class UpdateProjectValidator : AbstractValidator<UpdateProjectDto>
{
    public UpdateProjectValidator()
    {
        RuleFor(p => p.Content)
            .NotEmpty()
            .MinimumLength(20);
        RuleFor(p => p.GlobalStyles)
            .NotEmpty()
            .MinimumLength(2);
    }
}