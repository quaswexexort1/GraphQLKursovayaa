using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLKursovayaa.DataAccess.Entity
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ClientId { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string?  Address { get; set; }

        [MaxLength(100)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public virtual ICollection<Case> Cases { get; set; } = new List<Case>(); // Список дел клиента
    }
}





