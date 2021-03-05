using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BoxCorp.App {
    public class Box {
        public Box() { }
        public Box(int x, int y, int width, int height, double rank) {
            this.Rectangle = new Rectangle(x, y, width, height);
            this.Rank = rank;
        }
        public static Box FromRecord(string[] record) {
            return new Box(
                int.Parse(record[0]),
                int.Parse(record[1]),
                int.Parse(record[2]),
                int.Parse(record[3]),
                double.Parse(record[4]));
        }

        public Rectangle Rectangle { get; private set; }
        public double Rank { get; private set; }
    }
}
