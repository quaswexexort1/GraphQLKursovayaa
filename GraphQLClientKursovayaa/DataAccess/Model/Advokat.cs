using System.ComponentModel.DataAnnotations;

namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class Advokat
    {
        public int AdvokatId { get; set; }
        public string? Name { get; set; }

        public string? Specialization { get; set; }
        public int CaseId { get; set; }

        public string? LicenseNumber { get; set; }

        public decimal HourlyRate { get; set; } // Почасовая ставка
        public virtual ICollection<Case> Cases { get; set; } = new List<Case>(); // Список дел, над которыми работает адвокат

        public override string ToString()
        {
            return $"AdvokatId: {AdvokatId},\n +" +
                $"Name: {Name},\n" +
                $"Specialization: {Specialization},\n" +
                $"LicenceNumber: {LicenseNumber},\n" +
                $"HourlyRate: {HourlyRate},\n";
        }
    }
}
