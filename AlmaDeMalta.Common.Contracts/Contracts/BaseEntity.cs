namespace AlmaDeMalta.Common.Contracts.Contracts;
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public virtual IList<string> ItemType { get; protected set; } = [nameof(BaseEntity)];
        public bool isActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
