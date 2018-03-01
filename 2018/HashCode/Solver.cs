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
        public int VehiclesCount { get; set; }
        public int RidesCount { get; set; }
        public int Bonus { get; set; }
        public int Steps { get; set; }
        public double[][] DistancesRides;


        public List<Vehicle> Vehicles { get; set; }
        public List<Ride> Rides { get; set; }

        public Solver()
        {
            Rides = new List<Ride>();
            Vehicles = new List<Vehicle>();
        }

        public void Solve()
        {

            Vehicles.First().Rides.Add(new Ride() { Id = 0 });
            Vehicles.Skip(1).First().Rides.Add(new Ride() { Id = 2 });
            Vehicles.Skip(1).First().Rides.Add(new Ride() { Id = 1 });

            // Output
            foreach (var vehicle in Vehicles)
            {
                Console.Write($"{vehicle.Rides.Count}");
                foreach (var ride in vehicle.Rides)
                {
                    Console.Write($" {ride.Id}");
                }
                Console.Write(Environment.NewLine);
            }
        }
        public static double Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }


        public int CalculMove(Point departure, Point arrival)
        {
            var result = 0d;
            result = Math.Sqrt(Math.Pow(Math.Abs(departure.X - arrival.X), 2) + Math.Pow(Math.Abs(departure.Y - arrival.Y), 2));
            return (int)Math.Ceiling(result);
        }



        public void MatriceDistanceCourses()
        {
            for (int i = 0; i < RidesCount; i++)
            {
                for (int j =0;j<RidesCount;j++)
                {
                    if (i != j)
                    {

                        DistancesRides[i][j] = Distance(Rides[i].FinishingPoint.X, Rides[j].StartingPoint.X, Rides[i].FinishingPoint.Y, Rides[j].FinishingPoint.Y);
                        DistancesRides[i][j] = Distance(Rides[i].FinishingPoint.X, Rides[j].StartingPoint.X, Rides[i].FinishingPoint.Y, Rides[j].FinishingPoint.Y);
                    }
                    else
                    {
                        DistancesRides[i][j] = 0;
                    }
                }
            }




        }

    }
}
