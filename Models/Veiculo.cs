using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusFinder_2.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int ArduinoId { get; set; }

        public Arduino Arduino { get; set; }
        public List<ItinerarioVeiculo> ItinerarioVeiculo { get; set; }
    }
}
