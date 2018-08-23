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
            var result = new ValueNode(5);
            var expected = "5";
            Assert.AreEqual(expected, result.ToString());
        }
        [TestMethod]
        public void CreateEuro()
        {
            ValueNode result = new ValueNode(5) { Valuetype = ValueNode.valuetype.Euro };
            string expected = "€5";
            Assert.AreEqual(expected, result.ToString());
        }
        [TestMethod]
        public void CreatePercentage()
        {
            ValueNode actual = new ValueNode(7) { Valuetype = ValueNode.valuetype.Percentage };
            string expected = "7%";
            Assert.AreEqual(expected, actual.ToString());
        }
        ValueNode fiveNone = new ValueNode(5);
        [TestMethod]
        public void NoneAdd()
        {
            ValueNode a = new ValueNode(5);
            None(a);
        }
        [TestMethod]
        public void None(ValueNode a)
        {
            ValueNode b = new ValueNode(7);

        }

        [TestMethod]
        public void NoneAddEuro()
        {
            ValueNode b = new ValueNode(8) { Valuetype = ValueNode.valuetype.Euro };
            ValueNode c = fiveNone + b;
            Assert.AreEqual(c, new ValueNode(8 + 5) { Valuetype = ValueNode.valuetype.none });
        }


        [TestMethod]
        public void NoneAddPercentage()
        {
            ValueNode b = new ValueNode(7) { Valuetype = ValueNode.valuetype.Percentage };
            ValueNode c = fiveNone + b;
            Assert.AreEqual(c, new ValueNode(7 + 5) { Valuetype = ValueNode.valuetype.none });
        }
    }
}
