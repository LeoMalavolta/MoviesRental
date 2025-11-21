using FluentValidation;
using MoviesRental.Application.Features.Dvds.Commands.RentDvd;

namespace MoviesRental.Application.Features.Dvds.Commands.ReturnDvd
{
    public class ReturnDvdCommandValidator : AbstractValidator<ReturnDvdCommand>
    {
        public ReturnDvdCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Dvd Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Dvd Id cannot be an empty GUID.");
        }
    }
}
