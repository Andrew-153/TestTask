using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public class CorrectSeqOfBracketsMethod
    {
        /// <summary>
        /// Метод реализует проверку на правильную последовательность 
        /// скобок открывающихся и закрывающихся скобок.
        /// Метод реализован через коллекция Stack<T>
        /// 
        /// 
        /// Если метод находит закрывающуюся скобку, то производится
        /// проверка в стеке. Если пары нет, то выводится сообщение: "не корректно".
        /// 
        /// Если все скобки корректно открыты-закрыты, то метод завершается
        /// сообщение: "корректно"
        /// </summary>
        /// <param name="text">Проверяемая строка/текст</param>
        /// <returns></returns>
        public static string AnotherCheckCorrectBrackets(string text)
        {
            Dictionary<char, char> dictOfPairsBrackets = new Dictionary<char, char>()
            {
                {')', '('},
                {']', '['},
                {'}' , '{'}
            };
            // Добавляем в стек найденные откр. скобки:
            Stack stackSymbs = new Stack();
            // Проходим циклом по символам в строке:
            for (int i = 0; text != null && i < text.Length; i++)
            {
                var index = text.IndexOfAny(new char[] { '(', '[', '{', '}', ']', ')' }, i);
                if (index == -1) break;
                else if (isClosedBrackets(text[index]))
                {
                    if (stackSymbs.Count == 0 || dictOfPairsBrackets[text[index]] != (char)stackSymbs.Pop())
                        return "не корректно";
                }
                else
                {
                    stackSymbs.Push(text[index]);
                }
                i = index;
            }
            return stackSymbs.Count == 0 ? "корректно" : "не корректно";
        }

        public static bool isClosedBrackets(char symb)
        {
            return ") } ]".IndexOf(symb) > -1;
        }

    }

}
