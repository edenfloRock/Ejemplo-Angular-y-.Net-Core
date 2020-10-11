using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class Venta
    {
        public Venta()
        {
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdCliente { get; set; }
        public decimal? ImporteTotal { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
