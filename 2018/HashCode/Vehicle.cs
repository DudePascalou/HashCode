using CoperAlgoLib.Geometry;
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

        public Point CurrentPosition { get; set; }
        /// <summary>
        /// Nb d'étapes total
        /// </summary>
        public int Times { get; set; }
        // Les rides sont dans l'ordre dans lequel elles ont été effectuées
        public ICollection<Ride> Rides { get; set; }
        
        public Vehicle()
        {
            Rides = new List<Ride>();

            CurrentPosition = new Point(0, 0);
        }

        public void MoveToNextRideFinishingPoint()
        {
            var ride = Rides.LastOrDefault();
            if (ride == null || CurrentPosition == ride.FinishingPoint) return;
            var steps = CalculMove(CurrentPosition, ride.StartingPoint);
            steps += CalculMove(ride.StartingPoint, ride.FinishingPoint);

            Times += steps;
            //if (!IsDoingARide)
            //{
            //    if (ride.CanStart(currentStep))
            //    {
            //        IsDoingARide = true;
            //    }
            //    //!\\ Peut-être un pbm d'indice ???
            //    // Se diriger vers la (pt départ) prochaine course :
            //    if (ride.StartingPoint.X > CurrentPosition.X)
            //    {
            //        CurrentPosition.X++;
            //    }
            //    else if (ride.StartingPoint.X < CurrentPosition.X)
            //    {
            //        CurrentPosition.X--;
            //    }
            //    else if (ride.StartingPoint.Y > CurrentPosition.Y)
            //    {
            //        CurrentPosition.Y++;
            //    }
            //    else if (ride.StartingPoint.Y < CurrentPosition.Y)
            //    {
            //        CurrentPosition.Y--;
            //    }
            //}
            //else
            //{
            //    // Se diriger vers le (pt arrivée) course courante :
            //    if (ride.FinishingPoint.X > CurrentPosition.X)
            //    {
            //        CurrentPosition.X++;
            //    }
            //    else if (ride.FinishingPoint.X < CurrentPosition.X)
            //    {
            //        CurrentPosition.X--;
            //    }
            //    else if (ride.FinishingPoint.Y > CurrentPosition.Y)
            //    {
            //        CurrentPosition.Y++;
            //    }
            //    else if (ride.FinishingPoint.Y < CurrentPosition.Y)
            //    {
            //        CurrentPosition.Y--;
            //    }

            //    if (ride.FinishingPoint == CurrentPosition)
            //    {
            //        // Arrivée :
            //        IsDoingARide = false;
            //    }
            //}
        }

        public int CalculMove(Point departure, Point arrival)
        {
            var result = 0d;
            result = Math.Sqrt(Math.Pow(Math.Abs(departure.X - arrival.X), 2) + Math.Pow(Math.Abs(departure.Y - arrival.Y), 2));
            return (int)Math.Ceiling(result);
        }
    }
}
