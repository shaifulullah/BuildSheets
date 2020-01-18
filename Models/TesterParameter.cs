using BuildSheets.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Models
{
    public class TesterParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DeviceName { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Parameter { get; set; }
        public TesterParameterCode TesterParameterCode { get; set; }
    }
}
