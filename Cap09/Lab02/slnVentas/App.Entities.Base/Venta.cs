using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    [Table("Venta")]
    public class Venta
    {
        public int VentaID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int ClienteID { get; set; }

        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }

    }
}
