using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    [Table("VentaDetalle")]
    public class VentaDetalle
    {
        public int VentaDetalleID { get; set; }
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Venta Venta{ get; set; }

    }
}
