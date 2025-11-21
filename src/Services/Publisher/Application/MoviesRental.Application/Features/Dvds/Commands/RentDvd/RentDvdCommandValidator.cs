using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.RentDvd
{
    public class RentDvdCommandValidator : AbstractValidator<RentDvdCommand>
    {
        public RentDvdCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Dvd Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Dvd Id cannot be an empty GUID.");
        }
    }
}
