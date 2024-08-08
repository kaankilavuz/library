namespace Application.Shareds.Entities
{
    public record BaseEntityDto<TKey> : CreationAuditedEntityDto<TKey>
    {
        public TKey Id { get; init; }
    }
}
