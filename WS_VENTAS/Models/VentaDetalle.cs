using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class VentaDetalle
    {
        public int IdVentaDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public DateTime Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ImporteTotal { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}
