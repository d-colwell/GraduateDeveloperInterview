using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BoxCorp.App {
    public class Box {
        public Box() { }
        public Box(int index,int x, int y, int width, int height, double rank) {
            this.Index = index;
            this.Rectangle = new Rectangle(x, y, width, height);
            this.Rank = rank;
        }
        public static Box FromRecord(string[] record) {
            return new Box(
                int.Parse(record[0]),
                int.Parse(record[1]),
                int.Parse(record[2]),
                int.Parse(record[3]),
                int.Parse(record[4]),
                double.Parse(record[5]));
        }
        public int Index { get; set; }
        public Rectangle Rectangle { get; private set; }
        public double Rank { get; private set; }
    }
}
