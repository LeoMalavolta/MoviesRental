using FluentValidation;

namespace MoviesRental.Application.Features.Dvds.Commands.DeleteDvd
{
    public class DeleteDvdCommandValidator : AbstractValidator<DeleteDvdCommand>
    {
        public DeleteDvdCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Dvd Id is required.");
        }
    }
}
