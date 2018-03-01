using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HashCode
{
    public partial class Solver
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Vehicles { get; set; }
        public int RidesCount { get; set; }
        public int Bonus { get; set; }
        public int Steps { get; set; }

        public ICollection<Ride> Rides { get; set; }

        public Solver()
        {
            Rides = new List<Ride>();         
        }

        public void Solve()
        {
            
        }
        
    }
}
