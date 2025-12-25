namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class Action
    {
        public int ActionId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }
        public bool IsCompleted { get; set; }         // Статус выполнения действия (true - завершено, false - в работе)
        public DateTime DatePerformed { get; set; }         // Дата выполнения действия
        public DateTime? EndDate { get; set; }
        public int CaseId { get; set; }                 // Fk
        public virtual Case Case { get; set; }         // дело, к которому относится действие

        public override string ToString()
        {
            return
                $"ActionId: {ActionId},\n" +
                $"Title: {Title},\n" +
                $"Description: {Description},\n" +
                $"Cost: {Cost},\n" +
                $"IsCompleted: {IsCompleted},\n" +
                $"DatePerformed: {DatePerformed},\n" +
                $"EndDate: {EndDate},\n" +
                $"CaseId: {CaseId}\n";
        }


    }
}
