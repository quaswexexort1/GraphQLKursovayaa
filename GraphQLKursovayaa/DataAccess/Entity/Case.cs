using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLKursovayaa.DataAccess.Entity
{
    public class Case
    {
        public int CaseId { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal NominalCost { get; set; } //В случае проигрыша клиент оплачивает конторе ее услуги по номинальной стоимости

        public decimal PremiumPercent { get; set; } // в случае выигрыша — с учетом премиальных, установленных в договорном порядке для данного дела.

        public bool IsWon { get; set; } // выиграно/проиграно

        public DateTime StartDate { get; set; } // дата открытия дела

        public DateTime? EndDate { get; set; } // дата закрытия дела

        public int ClientId { get; set; } // FK
        public virtual Client Client { get; set; } // Клиент дела
        public virtual ICollection<Advokat> Advokats { get; set; } = new List<Advokat>(); // Адвокаты работающие

        public virtual ICollection<Action> Actions { get; set; } = new List<Action>(); // Действия по делу

    }
}
