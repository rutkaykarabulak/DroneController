using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musala.EFModels
{
    [Table("Medication")]
    public class Medication
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, RegularExpression("^[a-zA-Z0-9\\_-]+$", ErrorMessage = "Allowing to entry only letters, numbers and dashes.")]

        public string Name { get; set; } = string.Empty;

        [Required]
        public double Weight { get; set; }

        [Required, MaxLength(100), RegularExpression("^[A-Z0-9\\_]+$", ErrorMessage = "Allowing only upper cases, under scores and numbers.")]
        public string Code { get; set; } = string.Empty;

        //[Required]
        //public Base64 Image { get; set; } // TODO ASK SENSEI


    }
}
