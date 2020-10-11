using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class Animal
    {
        public int IdAnimal { get; set; }
        public string DescAnimal { get; set; }
        public int? IdClase { get; set; }

        public virtual ClaseAnimal IdClaseNavigation { get; set; }
    }
}
