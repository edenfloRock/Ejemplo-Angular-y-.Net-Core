using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class Producto
    {
        public Producto()
        {
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Costo { get; set; }

        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
