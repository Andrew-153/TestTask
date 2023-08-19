using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TextProcessor;

namespace IsCorrectPlaceBrackets.Tests
{
    [TestClass]
    public class CheckCorrectPlaceBracketsTest
    {
        static void CheckoutSolution(string str, string exeptedResult)
        {
            //var result = IsCorrectPlaceBrackets_Task.CheckCorrectBrackets(str);
            // Тестируем метод со стеком:
            var result = CorrectSeqOfBracketsMethod.AnotherCheckCorrectBrackets(str);
            Assert.AreEqual(result, exeptedResult);
        }

        /// <summary>
        /// Чтение строки
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var inputString = "Этот текст (строка) предназначен для тестирования [бы{стр}ой] " +
                              "проверки вхождения скобок {любых [из трех видов]}";
            CheckoutSolution(inputString, "корректно");
        }

        /// <summary>
        /// Проверка на Null
        /// </summary>
        [TestMethod]
        public void NullExeption()
        {
            string inputString = null;
            CheckoutSolution(inputString, "корректно");
        }

        /// <summary>
        /// Чтение тестовых значений из файла
        /// </summary>
        [TestMethod]
        public void TestsFromFile()
        {
            var readText = File.ReadAllLines("TestsFromFile.txt");
            foreach (var line in readText)
            {
                var inputString = line.Split('|');
                CheckoutSolution(inputString[0], inputString[1].Trim());
            }
        }
    }
}
