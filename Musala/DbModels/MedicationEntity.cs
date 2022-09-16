using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Musala.Utils;
namespace Musala.DbModels
{
    public class MedicationEntity
    {
        public int Id { get; set; }

        [Required, RegularExpression(Constants.regexOnlyLettersNumbersAndDashes, ErrorMessage = Constants.regexOnlyLettersNumbersAndDashesErr)]
        public string Name { get; set; } = string.Empty;
        [DefaultValue(0)]
        public float Weight { get; set; } = 0;

        [Required, MaxLength(Constants.maxCharacterLength), RegularExpression(Constants.regexOnlyUpperCasesUnderScoreAndNumbers, ErrorMessage = Constants.regexOnlyUpperCasesUnderScoreAndNumbersErr)]
        public string Code { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
    }
}
