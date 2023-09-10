using FluentValidation;
using Online.Shopping.Application.Carts.Create;

namespace Online.Shopping.Application.Carts.Get
{
    public sealed class GetCartQueryValidator : AbstractValidator<GetCartQuery>
    {
        public GetCartQueryValidator()
        {
            RuleFor(command => command.CartId)
                .NotEmpty().WithMessage("CartId is required");



        }
    }
}
