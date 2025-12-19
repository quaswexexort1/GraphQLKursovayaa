using System.ComponentModel.DataAnnotations;

namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class Client
    {
        public int ClientId { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Case> Cases { get; set; } = new List<Case>(); // Список дел клиента
        public override string ToString()
        {
            return $"ClientId: {ClientId}\n" +
                $"Name: {Name}\n" +
                $"Address: {Address}\n" +
                $"Phone: {Phone}\n" +
                $"Email: {Email}\n";
        }
    }
}
