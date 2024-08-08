namespace Domain.Shareds.Entities
{
    public abstract class CreationAuditedEntity<TKey> : BaseEntity<TKey>
    {
        public DateTime CreationTime { get; protected set; }
        public Guid? CreatorId { get; protected set; }
    }
}
