using System.ComponentModel.DataAnnotations;

namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class CreateCaseModel
    {
        [Required(ErrorMessage = "Title Is Required")]
        public string? Title { get; set; }


        [Required(ErrorMessage = "Description Is Required")]
        public string? Description { get; set; }



        [Required(ErrorMessage = "NominalCost Is Required")]
        public decimal NominalCost { get; set; } //В случае проигрыша клиент оплачивает конторе ее услуги по номинальной стоимости



        [Required(ErrorMessage = "PremiumPercent Is Required")]
        public decimal PremiumPercent { get; set; } // в случае выигрыша — с учетом премиальных, установленных в договорном порядке для данного дела.



        [Required(ErrorMessage = "IsWon Is Required")]
        public bool IsWon { get; set; } // выиграно/проиграно



        [Required(ErrorMessage = "StartDate Is Required")]
        public DateTime StartDate { get; set; } // дата открытия дела



        [Required(ErrorMessage = "EndDate Is Required")]
        public DateTime? EndDate { get; set; } // дата закрытия дела

    }
}
