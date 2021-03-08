using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace BoxCorp.App.Tests {
    [TestClass]
    public class BoxFilterTests {
        private readonly BoxFilter boxFilter;

        public BoxFilterTests() {
            this.boxFilter = new BoxFilter();
        }

        [TestMethod]
        public void DidYouPass() {
            var reader = new CsvParser();
            var expectedBoxes = reader.ParseFileToBoxes("retained.csv").Select(b => b.Index).OrderBy(x => x).ToArray();
            var inputBoxes = reader.ParseFileToBoxes("boxes.csv");
            var actualBoxes = boxFilter.FilterBoxes(inputBoxes).Select(b => b.Index).OrderBy(x => x).ToArray();
            Assert.IsTrue(expectedBoxes.SequenceEqual(actualBoxes), $"Incorrect answer, expected {expectedBoxes.Length} boxes, got {actualBoxes.Length} boxes");
        }

        [TestMethod]
        public void TestSuppressionOfOverlappingBoxes() {
            var boxA = new Box(0, 0, 0, 10, 10, 0.7);
            var boxB = new Box(1, 2, 2, 10, 10, 0.6);
            var remainingBoxes = boxFilter.FilterBoxes(new Box[] { boxB, boxA });
            Assert.IsTrue(remainingBoxes[0].Index == 0);
        }

        [TestMethod]
        public void TestNoSuppressionBelowThreshold() {
            var boxA = new Box(0, 0, 0, 10, 10, 0.7);
            var boxB = new Box(1, 0, 0, 4, 10, 0.6);
            var remainingBoxes = boxFilter.FilterBoxes(new Box[] { boxB, boxA });
            Assert.IsTrue(remainingBoxes.Length == 2);
        }

        [TestMethod]
        public void TestSuppressionAboveThreshold() {
            var boxA = new Box(0, 0, 0, 10, 10, 0.7);
            var boxB = new Box(1, 0, 0, 6, 7, 0.6);
            var remainingBoxes = boxFilter.FilterBoxes(new Box[] { boxB, boxA });
            Assert.IsTrue(remainingBoxes.Length == 1);
            Assert.IsTrue(remainingBoxes[0].Index == 0);
        }

        [TestMethod]
        public void TestNotSuppressedWhenNoOverlap() {
            var boxA = new Box(0, 0, 0, 5, 5, 0.7);
            var boxB = new Box(1, 5, 0, 5, 5, 0.6);
            var remainingBoxes = boxFilter.FilterBoxes(new Box[] { boxB, boxA });
            Assert.IsTrue(remainingBoxes.Length == 2);
        }

        [TestMethod]
        public void TestThresholding() {
            var boxes = new Box[]{ new Box(0,0, 0, 1, 1, 0.4)
            ,new Box(1,1, 0, 1, 1, 0.4999)
            ,new Box(2,2, 0, 1, 1, 0.5)
            ,new Box(3,3, 0, 1, 1, 0.6) };
            var remainingBoxes = boxFilter.FilterBoxes(boxes);
            Assert.IsTrue(remainingBoxes.Any(b => b.Index == 2));
            Assert.IsTrue(remainingBoxes.Any(b => b.Index == 3));
        }
    }
}
