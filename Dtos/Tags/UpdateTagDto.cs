using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Application.Dtos.Tags
{
    public class UpdateTagDto : BaseTagDto
    {
        public int ID { get; set; }
        public Guid TagUpdate { get; set; }
    }
}
