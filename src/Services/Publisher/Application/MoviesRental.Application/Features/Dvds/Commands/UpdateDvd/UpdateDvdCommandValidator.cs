using FluentValidation;

namespace MoviesRental.Application.Features.Dvds.Commands.UpdateDvd
{
    public class UpdateDvdCommandValidator : AbstractValidator<UpdateDvdCommand>
    {
        public UpdateDvdCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Dvd Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Dvd Id cannot be an empty GUID.");
        }
    }
}
