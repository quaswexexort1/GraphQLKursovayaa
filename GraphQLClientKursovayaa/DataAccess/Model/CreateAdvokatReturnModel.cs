namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class CreateAdvokatReturnModel
    {
        public int AdvokatId { get; set; }
        public string? Name { get; set; }

        public string? Specialization { get; set; }

        public string? LicenseNumber { get; set; }

        public decimal HourlyRate { get; set; } // Почасовая ставка

    }
}
