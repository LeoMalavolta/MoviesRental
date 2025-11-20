using FluentValidation;
using MoviesRental.Core.ValidationMessages;

namespace MoviesRental.Application.Features.Directors.Commands.DeleteDiretor
{
    public class DeleteDiretorCommandValidator : AbstractValidator<DeleteDiretorCommand>
    {
        public DeleteDiretorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE);
        }
    }
}
