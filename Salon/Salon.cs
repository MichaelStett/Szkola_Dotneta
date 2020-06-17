using System;
using System.Collections.Generic;

using static System.Console;

namespace Salon
{
    public static class Salon
    {
        const decimal BASE_PRICE = 35.0m;

        public static List<Reservation> Reservations = new List<Reservation>();
        public static List<Client> Clients = new List<Client>();

        static Salon()
        { }

        public static decimal CreateNextReservation(Guid clientId, string time)
        {
            var client = Clients.Find(c => c.Id == clientId);

            if (client is null)
            {
                WriteLine("No client found");
                return 0.0m;
            }

            var dateTime = DateTime.Now.Date + Convert.ToDateTime(time).TimeOfDay;

            var timeDiff = DateTime.Now - dateTime;

            if (timeDiff > TimeSpan.Zero)
            {
                WriteLine("Can't reserve in past time.");
                return 0.0m;
            }

            var alreadyReserved = Reservations.Exists(r => r.DateTime == dateTime);

            if (alreadyReserved == true)
            {
                WriteLine("Already Reserved");
                return 0.0m;
            }

            var cost = BASE_PRICE * client.PriceMultiplier();

            Reservations.Add(new Reservation { ClientId = clientId, DateTime = dateTime, Cost = cost });

            return cost;
        }

        public static Guid AddNewClient(Status status = Status.None)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                Status = status
            };

            Clients.Add(client);

            return client.Id;
        }
    }
}
