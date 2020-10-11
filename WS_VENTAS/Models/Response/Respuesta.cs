using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_VENTAS.Models.Response
{
    public class Respuesta
    {
        /// <summary>
        /// Indicador de Éxito
        /// </summary>
        public int Exito { get; set; }

        /// <summary>
        /// Mensaje de Respuesta
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Datos de la Respuesta
        /// </summary>
        public object Data { get; set; }

        public Respuesta() {
            Exito = 0;
        }
    }
}
