namespace AlmaDeMalta.Common.Contracts.Contracts;
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public virtual IList<string> ItemType { get; } = [nameof(BaseEntity)];
    }
