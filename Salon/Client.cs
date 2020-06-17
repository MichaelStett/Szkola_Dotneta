using System;

namespace Salon
{
    public class Client
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public decimal PriceMultiplier()
        {
            return (1 - ((int)Status / 100.0m));
        }

        public override string ToString()
        {
            return $"{Id}: {Status}";
        }
    }
}
