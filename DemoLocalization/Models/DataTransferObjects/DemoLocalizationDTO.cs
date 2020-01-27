using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLocalization.Models.DataTransferObjects
{
    public class DemoLocalizationDTO
    {
        [Required(ErrorMessage = "model.err.msg.The {0} field is required")]
        [Display(Name = "model.name")]
        public string Name { get; set; }

        [Display(Name = "model.description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "model.err.msg.The {0} field is required")]
        [StringLength(18, ErrorMessage = "model.err.msg.The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*\d)).+$", ErrorMessage = @"model.err.msg.password")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }
    }
}
