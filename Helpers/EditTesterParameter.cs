using BuildSheets.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Helpers
{
    public class EditTesterParameter
    {
        public int Id { get; set; }

        public TesterParameterCodeType Type { get; set; }

        [Required(ErrorMessage = "Please enter parameter name.")]
        [RegularExpression(@"[^\s]+", ErrorMessage = "Spaces are not allowed for Parameter Name")]
        public string ParameterName { get; set; }

        [Required(ErrorMessage = "Please enter parameter value.")]
        public string ParameterValue { get; set; }
        public int Index { get; set; }
    }
}
