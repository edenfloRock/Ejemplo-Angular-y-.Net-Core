using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public int IdEstatusUsuario { get; set; }
        public int? Edad { get; set; }

        public virtual CestatusUsuario IdEstatusUsuarioNavigation { get; set; }
    }
}
