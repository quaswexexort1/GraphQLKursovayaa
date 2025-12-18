using Faker;
using GraphQLKursovayaa.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Mail;

namespace GraphQLKursovayaa.DataAccess.Data
{
    public class DataSeeder
    {
        private static readonly Random _random = new Random();
        public static void SeedData(SampleAppDbContext db)
        {
            if (!db.Clients.Any())
            {
                // 10 клиентов
                for (int i = 0; i < 10; i++)
                {
                    db.Clients.Add(new Client
                    {
                        Name = Name.FullName(),
                        Phone = Phone.Number(),
                        Address = Address.StreetAddress(),
                        Email = Faker.Internet.Email()
                    });
                }
            }

            if (!db.Advokats.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    db.Advokats.Add(new Advokat
                    {
                        Name = Name.FullName(),
                        Specialization = Lorem.Sentence(),
                        LicenseNumber = "LIC-" + Faker.RandomNumber.Next(100000, 100000000),
                        HourlyRate = Faker.RandomNumber.Next(1000, 5000)
                    });
                }
            }

            db.SaveChanges();



            if (!db.Cases.Any())
            {
                var clients = db.Clients.ToList();
                var advokats = db.Advokats.ToList();

                for (int i = 0; i < 20; i++)
                {
                    var client = clients[Faker.RandomNumber.Next(0, clients.Count - 1)];
                    var caseItem = new Case
                    {
                        Title = $"Дело {Lorem.Sentence()} {Faker.RandomNumber.Next(100, 999)}",
                        Description = Lorem.Sentence(10),
                        NominalCost = (decimal)(Faker.RandomNumber.Next(50000, 500000) / 100.0),
                        PremiumPercent = (decimal)(Faker.RandomNumber.Next(10, 50) / 100.0), // 10-50%
                        IsWon = _random.Next(2) == 1,
                        StartDate = DateTime.Now.AddDays(Faker.RandomNumber.Next(1, 365)),
                        EndDate = _random.Next(0, 1) == 1 ? DateTime.Now.AddDays(_random.Next(1, 30)) : null,
                        ClientId = client.ClientId
                    };
                    db.Cases.Add(caseItem);
                }
            }

            db.SaveChanges();

            if (!db.Actions.Any())
            {
                var cases = db.Cases.ToList();

                for (int i = 0; i < 50; i++)
                {
                    var caseItem = cases[Faker.RandomNumber.Next(0, cases.Count - 1)];
                    db.Actions.Add(new Entity.Action
                    {
                        Title = $"Процедура {Lorem.Sentence()} #{Faker.RandomNumber.Next(1, 100)}",
                        Description = Lorem.Sentence(5),
                        Cost = (decimal)(Faker.RandomNumber.Next(1000, 50000) / 100.0),
                        IsCompleted = _random.Next(2) == 1,
                        DatePerformed = DateTime.Now.AddDays(-Faker.RandomNumber.Next(1, 90)),
                        EndDate = _random.Next(10) == 1 ? DateTime.Now.AddDays(-_random.Next(1, 30)) : null,
                        CaseId = caseItem.CaseId
                    });
                }
            }

            db.SaveChanges(); 
        }
    }
    
}