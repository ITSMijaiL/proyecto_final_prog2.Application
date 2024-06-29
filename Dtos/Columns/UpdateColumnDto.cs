using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_prog2.Application.Dtos.Columns
{
    public class UpdateColumnDto : BaseColumnDto
    {
        public int ID { get; set; }
        public Guid ColumnUpdate { get; set; }
    }
}
