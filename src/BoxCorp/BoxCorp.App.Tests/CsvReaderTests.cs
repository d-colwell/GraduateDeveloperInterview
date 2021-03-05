using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BoxCorp.App.Tests {
    [TestClass]
    public class CsvReaderTests {
        private readonly CsvParser parser;

        public CsvReaderTests() {
            this.parser = new CsvParser();
        }
        [TestMethod]
        public void TestSampleFile() {
            var boxes = parser.ParseFileToBoxes("boxes.csv");
            Assert.AreEqual(10000, boxes.Length);
        }

        [TestMethod]
        public void HeaderSkippingWorks() {
            File.WriteAllText("header.csv","header\r\n0,0,10,10,0.2");
            var result = parser.ParseFileToBoxes("header.csv");
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result[0].Rank == 0.2);
        }
    }
}
