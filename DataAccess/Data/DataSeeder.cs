using Faker;
using GraphQLKursovayaa.DataAccess.Entity;
using System.Diagnostics;

namespace GraphQLKursovayaa.DataAccess.Data
{
    public class DataSeeder
    {
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
                        Phone = Phone.Number()
                    });
                }
            }

            for (int i = 0; i < 5; i++)
            {
                db.Advokats.Add(new Advokat
                {
                    Name = Name.FullName(),
                    Specialization = Lorem.Sentence()
                });
            }
            db.SaveChanges();
        }
    }
}