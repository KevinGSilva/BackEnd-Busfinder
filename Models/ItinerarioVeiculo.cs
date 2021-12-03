using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFinder_2.Models
{
    public class ItinerarioVeiculo
    {
        public int VeiculoId { get; set; }
        public int ItinerarioId { get; set; }

        public Itinerario Itinerario { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
