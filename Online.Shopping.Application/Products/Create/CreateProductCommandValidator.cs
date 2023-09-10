using FluentValidation;

namespace Online.Shopping.Application.Products.Create
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Please supply a product name");

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Please supply a description");

            RuleFor(command => command.Price)
                .NotEmpty().WithMessage("Please supply a price");

            RuleFor(command => command.Currency)
                .NotEmpty().WithMessage("Please supply a currency");

            RuleFor(command => command.Sku)
                .NotEmpty().WithMessage("Please supply sku");
        }
    }
}
