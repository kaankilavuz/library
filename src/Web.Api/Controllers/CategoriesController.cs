using Application.Categories.Commands.Create;
using Application.Categories.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<CategoryDto> CreateAsync(CreateCategoryCommand input, CancellationToken cancellationToken) => _mediator.Send(input, cancellationToken);

    }
}
