using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessor;
//using TextProcessing;

namespace ConsoleApp_IsCorrectPlaceBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа проверяет корректность расстановки скобок" +
                "\nВведите пожалуйста для проверки текст:");
            string text = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введенный текст: \n{0}", text);
            //Console.WriteLine(IsCorrectPlaceBrackets_Task.CheckCorrectBrackets(text));
            Console.WriteLine(CorrectSeqOfBracketsMethod.AnotherCheckCorrectBrackets(text));
        }
    }
}
