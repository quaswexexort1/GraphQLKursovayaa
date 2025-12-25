using System.ComponentModel.DataAnnotations;

namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class CreateClientModel
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address Is Required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Phone Is Required")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        public string? Email { get; set; }


    }
}
