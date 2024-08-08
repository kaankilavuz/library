using Domain.Entities.Categories;
using System.ComponentModel.DataAnnotations;

namespace Application.Categories.Commons
{
    public record CreateOrUpdateCategoryBaseDto
    {
        [Required]
        [MaxLength(Category.NameMaxLength)]
        public string Name { get; init; } = string.Empty;
        [Required]
        [MaxLength(Category.DescriptionMaxLength)]
        public string Description { get; init; } = string.Empty;
        public bool IsDeleted { get; init; } = false;
    }
}
