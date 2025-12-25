namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class CreateActionReturnModel
    {
        public int ActionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DatePerformed { get; set; }         // Дата выполнения действия
        public DateTime? EndDate { get; set; }
        public int CaseId { get; set; }                 // Fk

    }

}
