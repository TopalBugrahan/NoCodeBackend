using FluentValidation;
using KouMobilio.Application.DTOs.Project.Inputs;
using KouMobilio.Domain.Entities;

namespace KouMobilio.Application.Validators.Projects;

public class CreateProjectValidator : AbstractValidator<CreateProjectDto>
{
    public CreateProjectValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MinimumLength(3);
    }
}