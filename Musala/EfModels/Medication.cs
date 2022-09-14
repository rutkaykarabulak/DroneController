﻿using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Musala.Utils;
namespace Musala.EFModels
{
    [Table("Medication")]
    public class Medication
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, RegularExpression(Constants.regexOnlyLettersNumbersAndDashes, ErrorMessage = Constants.regexOnlyLettersNumbersAndDashesErr)]

        public string Name { get; set; } = string.Empty;

        [Required]
        public float Weight { get; set; }

        [Required, MaxLength(Constants.maxCharacterLength), RegularExpression(Constants.regexOnlyUpperCasesUnderScoreAndNumbers, ErrorMessage = Constants.regexOnlyUpperCasesUnderScoreAndNumbersErr)]
        public string Code { get; set; } = string.Empty;

        //[Required]
        //public Base64 Image { get; set; } // TODO


    }
}
