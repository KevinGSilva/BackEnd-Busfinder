using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFinder_2.Models
{
    public class Arduino
    {
        public int Id { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
