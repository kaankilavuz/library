namespace Domain.Shareds.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; }


        public virtual string Check(string value,
            string property,
            int maxLength = int.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(property);

            if (value.Length > maxLength)
                throw new ArgumentOutOfRangeException(property);

            return value;
        }
    }
}
