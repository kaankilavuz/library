using Application.Categories.Commons;
using MediatR;

namespace Application.Categories.Commands.Create
{
    public record CreateCategoryCommand : CreateOrUpdateCategoryBaseDto, IRequest<CategoryDto>;
}
