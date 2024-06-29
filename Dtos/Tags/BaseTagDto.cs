using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Application.Dtos.Tags
{
    public class BaseTagDto : BaseDto
    {
        [MaxLength(25)]
        [Required]
        public string tag_name { get; set; }
    }
}
