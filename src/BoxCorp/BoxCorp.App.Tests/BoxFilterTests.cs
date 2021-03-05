using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxCorp.App.Tests {
    [TestClass]
    public class BoxFilterTests {
        private readonly BoxFilter boxFilter;

        public BoxFilterTests() {
            this.boxFilter = new BoxFilter();
        }
        [TestMethod]
        public void TestOverlappingBoxes() {
            var boxA = new Box(0, 0, 10, 10, 0.7);
            var boxB = new Box(2, 2, 10, 10, 0.6);
            var remainingBoxes = boxFilter.FilterBoxes(new Box[] { boxA, boxB });
            Assert.IsTrue(remainingBoxes[0].Rank == 0.7);
            Assert.IsTrue(remainingBoxes.Length == 1);
        }

        [TestMethod]
        public void TestThresholding() {
            var boxes = new Box[]{ new Box(0, 0, 1, 1, 0.4)
            ,new Box(1, 0, 1, 1, 0.4999)
            ,new Box(2, 0, 1, 1, 0.5)
            ,new Box(3, 0, 1, 1, 0.6) };
            var remainingBoxes = boxFilter.FilterBoxes(boxes);
            Assert.IsTrue(remainingBoxes.Any(b => b.Rank == 0.5));
            Assert.IsTrue(remainingBoxes.Any(b => b.Rank == 0.6));
        }
    }
}
