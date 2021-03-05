using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BoxCorp.App {
    public class CsvParser {
        public Box[] ParseFileToBoxes(string file) {
            return System.IO.File.ReadAllLines(file)
                .Skip(1)
                .Select(line => Box.FromRecord(line.Split(",", StringSplitOptions.RemoveEmptyEntries)))
                .ToArray();
        }
    }
}
