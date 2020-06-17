using System;
using System.Linq;

using static System.Console;

namespace Salon
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var values = Enum.GetValues(typeof(Status));

            Enumerable.Range(0, 100).ToList().ForEach(i =>
            {
                Salon.AddNewClient((Status)values.GetValue(random.Next(values.Length)));
            });

            //foreach (var client in Salon.Clients)
            //{
            //    WriteLine(client);
            //}

            var chosenTenClients = Salon.Clients.OrderBy(x => random.Next()).Take(10).ToList();

            chosenTenClients.ForEach(client =>
            {
                var randomTime = DateTime.Today.AddHours(random.Next(DateTime.Now.Hour - 1, 24))
                                         .AddMinutes(random.Next(59))
                                         .TimeOfDay.ToString();
                
                WriteLine($"Radnom Time: {randomTime}");

                Salon.CreateNextReservation(client.Id, randomTime);
            });

            foreach (var reservation in Salon.Reservations)
            {
                WriteLine(reservation);
            }
        }
    }
}
