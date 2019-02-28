using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    public class Input
    {
        public int RowsCount { get; set; }
        public int ColumnsCount { get; set; }
        public int VehiclesCount { get; set; }
        public int RidesCount { get; set; }
        public int StartingTheRideOnTimeBonus { get; set; }
        public int StepsCount { get; set; }
        public IList<Ride> Rides { get; set; }
    }
}
