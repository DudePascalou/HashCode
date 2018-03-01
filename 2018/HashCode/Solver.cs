using CoperAlgoLib.Geometry;
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
        public int[][] DistancesRides;


        public ICollection<Ride> Rides { get; set; }

        public Solver()
        {
            Rides = new List<Ride>();         
        }

        public void Solve()
        {
            
        }
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }

        public int CalculMove(Point departure, Point arrival)
        {
            for (int i = 0; i < RidesCount; i++)
            {
                for (int j =0;j<RidesCount;j++)
                {
                    if (i != j)
                    {
                        DistancesRides[i][j]= Distance()
                    }
                }
            }



            var result = 0d;
            result = Math.Sqrt(Math.Pow(Math.Abs(departure.X - arrival.X), 2) + Math.Pow(Math.Abs(departure.Y - arrival.Y), 2));
            return (int)Math.Ceiling(result);
        }

    }
}
