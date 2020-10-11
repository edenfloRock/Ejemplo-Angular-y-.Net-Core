using System;
using System.Collections.Generic;

namespace WS_VENTAS.Models
{
    public partial class ClaseAnimal
    {
        public ClaseAnimal()
        {
            Animal = new HashSet<Animal>();
        }

        public int IdClase { get; set; }
        public string DescClase { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}
