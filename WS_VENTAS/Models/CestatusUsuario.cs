using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class CestatusUsuario
    {
        public CestatusUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdEstatusUsuario { get; set; }
        public string DescEstatus { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
