using FluentValidation;

namespace Online.Shopping.Application.Carts.RemoveLineItem
{
    public sealed class RemoveLineItemCommandValidator : AbstractValidator<RemoveLineItemCommand>
    {
        public RemoveLineItemCommandValidator() 
        {
            RuleFor(command => command.CartId)
                .NotEmpty().WithMessage("CartId is required");

            RuleFor(command => command.LineItemId)
                .NotEmpty().WithMessage("LineItemId is required");
        } 
    }
}
