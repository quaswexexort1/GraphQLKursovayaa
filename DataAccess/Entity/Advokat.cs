using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLKursovayaa.DataAccess.Entity
{
    public class Advokat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdvokatId { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Specialization { get; set; }

        [MaxLength(50)]
        public string? LicenseNumber { get; set; }

        public decimal HourlyRate { get; set; } // Почасовая ставка
        public virtual ICollection<Case> Cases { get; set; } = new List<Case>(); // Список дел, над которыми работает адвокат

    }
}
