using System.ComponentModel.DataAnnotations;

namespace Musala.DbModels
{
    public class MedicationEntity
    {
        public int Id { get; set; }

        [RegularExpression("^[a-zA-Z0-9\\_-]+$", ErrorMessage = "Allowing to entry only letters, numbers and dashes.")]
        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }

        [MaxLength(100), RegularExpression("^[A-Z0-9\\_]+$", ErrorMessage = "Allowing only upper cases, under scores and numbers.")]
        public string Code { get; set; } = string.Empty;

        //public Base64 Image { get; set; } // TODO 
    }
}
