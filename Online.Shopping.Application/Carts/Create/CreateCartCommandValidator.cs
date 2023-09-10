using FluentValidation;

namespace Online.Shopping.Application.Carts.Create
{
    public sealed class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator() 
        { 
            RuleFor(command => command.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required");

        }
    }
}