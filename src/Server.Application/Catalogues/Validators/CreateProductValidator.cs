namespace Dionysus.Server.Application.Catalogues.Validators;

using Dionysus.Server.Application.Catalogues.Commands;
using FluentValidation;

internal sealed class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator()
    {
        base.RuleFor(command => command.Name).NotEmpty().WithMessage("Please specify name");
    }
}
