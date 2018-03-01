﻿using CoperAlgoLib.Geometry;
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

        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Ride> Rides { get; set; }

        public Solver()
        {
            Rides = new List<Ride>();
            Vehicles = new List<Vehicle>();
        }

        public IEnumerable<string> Solve()
        {
            Vehicles.First().Rides.Add(new Ride() { Id = 0 });
            Vehicles.Skip(1).First().Rides.Add(new Ride() { Id = 2 });
            Vehicles.Skip(1).First().Rides.Add(new Ride() { Id = 1 });

            // Output
            foreach (var vehicle in Vehicles)
            {
                var res = $"{vehicle.Rides.Count}";
                foreach (var ride in vehicle.Rides)
                {
                    res += $" {ride.Id}";
                }
                yield return res;
            }
        }

        public static int CalculMove(Point departure, Point arrival)
        {
            var result = 0d;
            result = Math.Sqrt(Math.Pow(Math.Abs(departure.X - arrival.X), 2) + Math.Pow(Math.Abs(departure.Y - arrival.Y), 2));
            return (int)Math.Ceiling(result);
        }

    }
}
