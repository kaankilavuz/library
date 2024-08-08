using Application.Shareds.Entities;
using Domain.Shareds.Entities.Abstracts;

namespace Application.Categories.Commons
{
    public record CategoryDto : CreationAuditedEntityDto<Guid>, ISoftDelete
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public bool IsDeleted { get; init; }
        public DateTime? DeletionTime { get; init; }
        public Guid? DeleterId { get; init; }
    }
}
