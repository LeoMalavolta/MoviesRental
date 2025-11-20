using MediatR;

namespace MoviesRental.Application.Features.Directors.Commands.UpdateDiretor
{
    public record UpdateDirectorCommand(Guid Id, string Name, string Surname, DateTime UpdateAt) : IRequest<UpdateDirectorResponse>;
}
