namespace Application.Shareds.Entities
{
    public record CreationAuditedEntityDto<TKey>
    {
        public DateTime CreationTime { get; init; }
        public Guid? CreatorId { get; init; }
    }
}
