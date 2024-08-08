using Application.Categories.Commons;
using AutoMapper;
using Domain.Entities.Categories;
using Domain.Shareds.Uow;
using MediatR;

namespace Application.Categories.Commands.Create
{
    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.IsDeleted);

            await _categoryRepository.InsertAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
