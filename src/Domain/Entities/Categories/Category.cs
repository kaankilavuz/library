using Domain.Shareds.Entities;
using Domain.Shareds.Entities.Abstracts;

namespace Domain.Entities.Categories
{
    public class Category : CreationAuditedEntity<Guid>, ISoftDelete
    {

        #region constants

        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 200;

        #endregion

        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsDeleted { get; private set; }
        public DateTime? DeletionTime { get; private set; }
        public Guid? DeleterId { get; private set; }

        public Category(
            Guid id,
            string name,
            string description,
            bool isDeleted = false)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
            IsDeleted = isDeleted;
        }

        public bool SetName(string name)
        {
            Check(name, nameof(Name), NameMaxLength);
            Name = name;
            return true;
        }

        public bool SetDescription(string description)
        {
            Check(description, nameof(Description), DescriptionMaxLength);
            Description = description;
            return true;
        }
    }
}
