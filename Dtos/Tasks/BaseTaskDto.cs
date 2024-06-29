using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Application.Dtos.Tasks
{
    public class BaseTaskDto : BaseDto
    {
        [MaxLength(100)]
        [Required]
        public string title { get; set; }

        [MaxLength(1200)]
        [Required]
        public string text { get; set; }
    }
}
