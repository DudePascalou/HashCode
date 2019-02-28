using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode
{
    public class Program
    {
        private const string path = @"C:\Users\fdescaves.stage\Source\Repos\HashCode\2018\HashCode\Input\";
        private const string outputPath = @"C:\Users\fdescaves.stage\Source\Repos\HashCode\2018\HashCode\Output\";
        private static string[] inputFiles =
        {
            "a_example.in",
            "b_should_be_easy.in",
            "c_no_hurry.in",
            "d_metropolis.in",
            "e_high_bonus.in"
        };

        public static void Main(string[] args)
        {
            foreach (var inputFile in inputFiles)
            {
                Console.WriteLine(inputFile);
                var inputFilePath = Path.Combine(path, inputFile);
                var outputFilePath = Path.Combine(outputPath, Path.ChangeExtension(inputFile, "out"));
                var input = new List<string>();
                var solver = ParseInput(File.ReadAllLines(inputFilePath));
                var result = solver.Solve();
                File.WriteAllLines(outputFilePath, result.ToArray());
            }
            Console.Error.WriteLine("Traitement terminé. À soumettre viiiite !!!");
            Console.Read();
        }

        public static Solver ParseInput(IList<string> input)
        {
            var solver = new Solver();
            
            int inputRowNumber = 0;
            input[inputRowNumber].FirstIs<int>(i => solver.Rows = i);
            input[inputRowNumber].SecondIs<int>(i => solver.Columns = i);
            input[inputRowNumber].ThirdIs<int>(i => solver.VehiclesCount = i);
            input[inputRowNumber].FourthIs<int>(i => solver.RidesCount = i);
            input[inputRowNumber].FifthIs<int>(i => solver.Bonus = i);
            input[inputRowNumber].SixthIs<int>(i => solver.TotalSteps = i);
            inputRowNumber++;

            for (int i = 0; i < solver.VehiclesCount; i++)
            {
                var vehicle = new Vehicle
                {
                    Id = i
                };
                solver.Vehicles.Add(vehicle);
            }

            for (int index = 0; index < solver.RidesCount; index++)
            {
                var ride = new Ride();
                ride.Id = index;
                input[inputRowNumber].FirstIs<int>(startingRow => ride.StartingRow = startingRow);
                input[inputRowNumber].SecondIs<int>(startingColumn => ride.StartingColumn = startingColumn);
                input[inputRowNumber].ThirdIs<int>(finishingRow => ride.FinishingRow = finishingRow);
                input[inputRowNumber].FourthIs<int>(finishingColumn => ride.FinishingColumn = finishingColumn);
                input[inputRowNumber].FifthIs<int>(earliestStart => ride.EarliestStart = earliestStart);
                input[inputRowNumber].SixthIs<int>(latestFinish => ride.LatestFinish = latestFinish);

                ride.InitPosition();

                solver.Rides.Add(ride);
                inputRowNumber++;
            }
            return solver;
        }
    }

    public static class UsefulExtensions
    {
        private const char _Separator = ' ';

        // Get single
        public static T GetAs<T>(this IList<string> input, int rowIndex, int colIndex) { return input.Row(rowIndex).Col(colIndex).As<T>(); }
        public static string Row(this IList<string> list, int rowIndex) { return list.Skip(rowIndex).First(); }
        public static string Col(this string input, int index) { return input.Split(_Separator)[index]; }
        public static T As<T>(this string input) { return (T)Convert.ChangeType(input, typeof(T)); }
        // Get list
        public static IList<T> GetAsListOf<T>(this IList<string> input, int rowStartIndex, int rowCount) { return input.Skip(rowStartIndex).Take(rowCount).Select(s => s.As<T>()).ToList(); }
        public static IList<T> GetAsListOf<T>(this string row) { return row.Split(_Separator).Select(s => s.As<T>()).ToList(); }
        // Fluent parsing
        public static string FirstIs<T>(this string input, Action<T> affectTo) { return input.NthIs<T>(0, affectTo); }
        public static string SecondIs<T>(this string input, Action<T> affectTo) { return input.NthIs<T>(1, affectTo); }
        public static string ThirdIs<T>(this string input, Action<T> affectTo) { return input.NthIs<T>(2, affectTo); }
        public static string FourthIs<T>(this string input, Action<T> affectTo) { return input.NthIs<T>(3, affectTo); }
        public static string FifthIs<T>(this string input, Action<T> affectTo) { return input.NthIs<T>(4, affectTo); }
        public static string SixthIs<T>(this string input, Action<T> affectTo) { return input.NthIs<T>(5, affectTo); }
        public static string NthIs<T>(this string input, int colIndex, Action<T> affectTo) { affectTo(input.Col(colIndex).As<T>()); return input; }
    }
}
