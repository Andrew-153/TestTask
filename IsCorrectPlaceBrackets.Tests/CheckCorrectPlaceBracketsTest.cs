using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TextProcessor;

namespace IsCorrectPlaceBrackets.Tests
{
    [TestClass]
    public class CheckCorrectPlaceBracketsTest
    {
        
        static void CheckoutSolution (string str , string exeptedResult)
        {
            var result = IsCorrectPlaceBrackets_Task.CheckCorrectBrackets(str);
            Assert.AreEqual(result, exeptedResult);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var inputString = "Этот текст (строка) предназначен для тестирования [бы{стр}ой] " +
                              "проверки вхождения скобок {любых [из трех видов]}";
            CheckoutSolution(inputString, "корректно");
        }

        [TestMethod]
        public void NullExeption()
        {
            string inputString = null;
            CheckoutSolution(inputString, "не корректно");
        }

        [TestMethod]
        public void TestsFromFile()
        {
            var readText = File.ReadAllLines("TestsFromFile.txt");
            foreach (var line in readText)
            {
                var inputString  = line.Split('|');
                CheckoutSolution(inputString[0], inputString[1].Trim());
            }
        }
    }
}
