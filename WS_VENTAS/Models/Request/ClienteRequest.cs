using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_VENTAS.Models.Request
{
    public class ClienteRequest
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int idCliente { get; set; }
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string nombreCliente { get; set; }

    }
}
