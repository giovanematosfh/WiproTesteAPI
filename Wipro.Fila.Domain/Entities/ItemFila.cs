using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wipro.Fila.Domain.Entities
{
    [Table("ItensFila")]
    public class ItemFila : Entity
    {

        public string Moeda { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }

    }
}
