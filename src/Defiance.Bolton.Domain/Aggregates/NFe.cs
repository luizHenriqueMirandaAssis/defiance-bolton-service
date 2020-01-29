namespace Defiance.Bolton.Domain.Aggregates
{
    public class NFe
    {
        public string AccessKey { get; private set; }
        public decimal TotalAmount { get; private set; }

        public static NFe Build(string accessKey, decimal totalAmount)
        {
            return new NFe()
            {
                AccessKey = accessKey,
                TotalAmount = totalAmount
            };
        }
    }
}
