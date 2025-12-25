namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class CreateCaseReturnModel
    {
        public int CaseId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal NominalCost { get; set; } //В случае проигрыша клиент оплачивает конторе ее услуги по номинальной стоимости

        public decimal PremiumPercent { get; set; } // в случае выигрыша — с учетом премиальных, установленных в договорном порядке для данного дела.

        public bool IsWon { get; set; } // выиграно/проиграно

        public DateTime StartDate { get; set; } // дата открытия дела

        public DateTime? EndDate { get; set; } // дата закрытия дела

        public int ClientId { get; set; } // FK

    }
}
