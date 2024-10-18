using FluentValidation;
using ProductDB.Entities;

namespace WebApplication1.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).WithMessage("this field mus'nt be empty");

            RuleFor(x=> x.Price).GreaterThan(0).WithMessage("price must be greater than 0");

            RuleFor(x => x.Image).Must(LinkMustBeAUri).WithMessage("{PropertyName} is'nt url");
        }
        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
