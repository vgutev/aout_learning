using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAanalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("alabalaBadExtension.foo");

            Assert.False(result);
        }

        [TestCase("filewithgoodextension.slf")]
        [TestCase("filewithgoodextension.SLF")]
        public void IsValidLogFileName_Validxtension_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result =analyzer.IsValidLogFileName(file);

            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer la = new LogAnalyzer();

            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [TestCase("badname.foo", false)]
        [TestCase("goodname.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLasFileNameValid(string filename, bool expected)
        {
            LogAnalyzer la = new LogAnalyzer();

            la.IsValidLogFileName(filename);

            Assert.AreEqual(expected, la.WasLastFileNameValid);
        }

        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator calc = new MemCalculator();

            int lastSum = calc.Sum();

            Assert.AreEqual(0, lastSum);
        }

        [Test]
        public void Add_WhenCalled_ChangesSum()
        {
            MemCalculator calc = new MemCalculator();

            calc.Add(5);
            int sum = calc.Sum();

            Assert.AreEqual(5, sum);
        }
    }
}
