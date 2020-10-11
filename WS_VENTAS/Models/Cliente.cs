﻿using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
