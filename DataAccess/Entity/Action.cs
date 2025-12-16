using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLKursovayaa.DataAccess.Entity
{
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public bool IsCompleted { get; set; }         // Статус выполнения действия (true - завершено, false - в работе)


        public DateTime DatePerformed { get; set; }         // Дата выполнения действия
        public int CaseId { get; set; }                 // Fk
        public virtual Case Case { get; set; }         // дело, к которому относится действие


    }
}
