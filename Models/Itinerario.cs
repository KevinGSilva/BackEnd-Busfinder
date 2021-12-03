using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFinder_2.Models
{
    public class Itinerario
    {
        public int Id { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public string Horario { get; set; }

        public List<ItinerarioVeiculo> ItinerarioVeiculo { get; set; }
    }
}
