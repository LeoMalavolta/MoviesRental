using MediatR;

namespace MoviesRental.WebApi.Controllers
{
    public class DirectorsController : ApiController
    {
        private readonly IMediator _mediator;

        public DirectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
