using System;
using System.Collections.Generic;
using System.IO;
using ExpressionEvaluator;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class CalculatorTest
    {
      
        #region TestMethod
        [TestMethod]
            public void TestCalculateFinalResult()
            {
            long ExpectedResult = 275225993853;
            Calculator.input = new Dictionary<long, string>();
            Calculator.Result = new Dictionary<long, long>();
            string[] lines = File.ReadAllLines("input.txt");
            Calculator.input = lines.Select(line => line.Split(':')).ToDictionary(keyValue => Convert.ToInt64(keyValue[0]), bits => bits[1]);
            long key = Calculator.input.Take(1).Select(d => d.Key).First();
            long ActualResult =  Calculator.CalculateFinalResult(key);

            Assert.AreEqual(ExpectedResult, ActualResult);
            }

        #endregion

    }

}
