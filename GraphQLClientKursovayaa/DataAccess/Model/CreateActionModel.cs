using System.ComponentModel.DataAnnotations;

namespace GraphQLClientKursovayaa.DataAccess.Model
{
    public class CreateActionModel
    {
        [Required(ErrorMessage ="Title Is Required")]
        public string Title { get; set; }



        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }



        [Required(ErrorMessage = "Cost Is Required")]
        public decimal Cost { get; set; }



        [Required(ErrorMessage = "IsCompleted Is Required")]
        public bool IsCompleted { get; set; }



        [Required(ErrorMessage = "DatePerformed Is Required")]
        public DateTime DatePerformed { get; set; }




    }
}
