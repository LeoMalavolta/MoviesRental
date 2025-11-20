using MediatR;

namespace MoviesRental.Application.Features.Directors.Commands.DeleteDiretor
{
    public record DeleteDiretorCommand(Guid Id) : IRequest<bool>;
}
