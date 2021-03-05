using System;
using System.Diagnostics;
namespace BoxCorp.App {
    class Program {
        static void Main(string[] args) {
            string inputFile = "boxes.csv";
            CsvParser parser = new CsvParser();
            BoxFilter filter = new BoxFilter();
            Box[] allBoxes = parser.ParseFileToBoxes(inputFile);
            Stopwatch timer = new Stopwatch();

            timer.Start();
            ///Your code should go into the FilterBoxes method
            Box[] remainingBoxes = filter.FilterBoxes(allBoxes);
            timer.Stop();
            Console.WriteLine($"There are {remainingBoxes.Length} boxes remaining. Time taken: {timer.ElapsedMilliseconds}ms");
        }
    }
}
