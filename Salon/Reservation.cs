using System;

namespace Salon
{
    public class Reservation
    {
        public Guid ClientId { get; set; }
        public DateTime DateTime { get; set; }

        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"{ClientId}: {DateTime} - {Cost}pln";
        }
    }
}
