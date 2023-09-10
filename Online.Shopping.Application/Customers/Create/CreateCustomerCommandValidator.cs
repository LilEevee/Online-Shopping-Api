using FluentValidation;
using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Application.Customers.Create
{
    public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name must be populated")
                .MaximumLength(50).WithMessage("Must not be longer then 50 characters");

            RuleFor(command => command.Surname)
                .NotEmpty().WithMessage("Surname must be populated")
                .MaximumLength(50).WithMessage("Must not be longer then 50 characters");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email must be populated")
                .MaximumLength(50).WithMessage("Must not be longer then 50 characters");
        }
    }
}
