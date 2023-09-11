using FluentValidation;

namespace Online.Shopping.Application.Carts.AddLineItem
{
    public sealed class AddLineCommandValidator : AbstractValidator<AddLineItemCommand>
    {
        public AddLineCommandValidator() 
        { 
            RuleFor(command => command.ProductId.Value)
                .NotEmpty().WithMessage("ProductId is required");

            RuleFor(command => command.CartId)
                .NotEmpty().WithMessage("CartId is required");

            RuleFor(command => command.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThanOrEqualTo(1).WithMessage("Quantity must be more then 1");
        }
    }
}