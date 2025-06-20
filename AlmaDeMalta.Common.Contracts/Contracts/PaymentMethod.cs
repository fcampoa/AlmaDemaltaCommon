using AlmaDeMalta.Common.Contracts.Attributes;

namespace AlmaDeMalta.Common.Contracts.Contracts;
    [CollectionName("PaymentMethod")]
    public class PaymentMethod: BaseEntity
    {
        public override IList<string> ItemType => [nameof(PaymentMethod)];
        public string Name { get; set; } = string.Empty;
        public PaymentType Type { get; set; } = PaymentType.Other;
        public decimal Fee { get; set; } = 0.0m;

        public decimal CalculateFee(decimal amount)
        {
            return (Fee / 100) * amount;
        }
    }
