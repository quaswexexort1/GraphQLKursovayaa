using System.ComponentModel.DataAnnotations;

namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class CreateAdvokatReturnModel
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Specialization Is Required")]
        public string? Specialization { get; set; }



        [Required(ErrorMessage = "LicenceNumber Is Required")]
        public string? LicenseNumber { get; set; }



        [Required(ErrorMessage = "HourlyRate Is Required")]
        public decimal HourlyRate { get; set; } // Почасовая ставка

    }
}
