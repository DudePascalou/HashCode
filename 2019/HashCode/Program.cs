using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode
{
    public class Program
    {
        private const string path = @"C:\Users\sbeaulieu.stage\Desktop\hashcode\HashCode\2019\HashCode\Input\";
        private const string outputPath = @"C:\Users\sbeaulieu.stage\Desktop\hashcode\HashCode\2019\HashCode\Output\";
        private static string[] inputFiles =
        {
            "a_example.txt",
            "b_lovely_landscapes.txt",
            "c_memorable_moments.txt",
            "d_pet_pictures.txt",
            "e_shiny_selfies.txt"
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

            //4
            //H 3 cat beach sun
            //V 2 selfie smile
            //V 2 garden selfie
            //H 2 garden cat

            int inputRowNumber = 0;
            input[inputRowNumber].FirstIs<int>(i => solver.PhotoCount = i);
            inputRowNumber++;

            var photoId = 0;
            for (int i = 0; i < solver.PhotoCount; i++)
            {
                var photo = new Photo();
                photo.Id = photoId++;
                input[inputRowNumber].FirstIs<char>(hv => photo.IsHorizontal = (hv == 'H'));
                input[inputRowNumber].FirstIs<char>(hv => photo.IsVertical = (hv == 'V'));
                input[inputRowNumber].SecondIs<int>(tagCount => photo.TagCount = tagCount);
                for (int tagIndex = 2; tagIndex < photo.TagCount + 2; tagIndex++)
                {
                    input[inputRowNumber].NthIs<string>(tagIndex, tag => photo.Tags.Add(tag));
                }
                solver.Photos.Add(photo);
                //Console.WriteLine(photo);
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
