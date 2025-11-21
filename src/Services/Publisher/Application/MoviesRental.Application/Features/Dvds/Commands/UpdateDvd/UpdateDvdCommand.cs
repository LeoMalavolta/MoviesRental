using MediatR;

namespace MoviesRental.Application.Features.Dvds.Commands.UpdateDvd
{
     public record UpdateDvdCommand(Guid Id) : IRequest<UpdateDvdResponse>;
}
