namespace Domain.Shareds.Entities.Abstracts
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
        DateTime? DeletionTime { get; }
        Guid? DeleterId { get; }
    }
}
