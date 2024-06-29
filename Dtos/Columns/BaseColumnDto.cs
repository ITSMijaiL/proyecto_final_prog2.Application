using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Application.Dtos.Columns
{
    public class BaseColumnDto : BaseDto
    {
        [MaxLength(100)]
        [Required]
        public string column_title { get; set; }
    }
}
