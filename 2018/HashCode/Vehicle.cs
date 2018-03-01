using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsDoingARide { get; set; }

        // Les rides sont dans l'ordre dans lequel elles ont été effectuées
        public ICollection<Ride> Rides {get; set;}

        public Vehicle()
        {
            Rides = new List<Ride>();
        }
    }
}
