using System;
using CalculatorAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTestProjects
{
    [TestClass]
    public class ValueNodeTests
    {

        
        [TestMethod]
        public void CreateTest()
        {
            var result = new ValueElement(5);
            var expected = "5";
            Assert.AreEqual(expected, result.ToString());
        }
        [TestMethod]
        public void CreateEuro()
        {
            ValueElement result = new ValueElement(5) { Valuetype = ValueElement.valuetype.Euro };
            string expected = "€5";
            Assert.AreEqual(expected, result.ToString());
        }
        [TestMethod]
        public void CreatePercentage()
        {
            ValueElement actual = new ValueElement(7) { Valuetype = ValueElement.valuetype.Percentage };
            string expected = "7%";
            Assert.AreEqual(expected, actual.ToString());
        }
        ValueElement fiveNone = new ValueElement(5);
        [TestMethod]
        public void NoneAdd()
        {
            ValueElement a = new ValueElement(5);
            None(a);
        }
        [TestMethod]
        public void None(ValueElement a)
        {
            ValueElement b = new ValueElement(7);

        }

        [TestMethod]
        public void NoneAddEuro()
        {
            ValueElement b = new ValueElement(8) { Valuetype = ValueElement.valuetype.Euro };
            ValueElement c = fiveNone + b;
            Assert.AreEqual(c, new ValueElement(8 + 5) { Valuetype = ValueElement.valuetype.none });
        }


        [TestMethod]
        public void NoneAddPercentage()
        {
            ValueElement b = new ValueElement(7) { Valuetype = ValueElement.valuetype.Percentage };
            ValueElement c = fiveNone + b;
            Assert.AreEqual(c, new ValueElement(7 + 5) { Valuetype = ValueElement.valuetype.none });
        }
    }
}
