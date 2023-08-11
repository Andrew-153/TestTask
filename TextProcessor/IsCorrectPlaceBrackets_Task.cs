using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TextProcessor
{
    public class IsCorrectPlaceBrackets_Task
    {
        // Поле хранит проверяемый текст:
        static string inputText = "";
        // Словарь хранит пары соответствия открывающейся
        // и закрывающейся скобок:
        static Dictionary<char, char> dictOfPairsBrackets = new Dictionary<char, char>()
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'}
        };

        /// <summary>
        /// Метод находит открывающуюся и закрывающиеся скобки, а 
        /// дальше, внутри этих скобок производит аналогичную проверку.
        /// 
        /// Если находит только одну из скобок, то метод завершается
        /// сообщение: "не корректно".
        /// 
        /// Если все скобки корректно открыты-закрыты, то метод завершается
        /// сообщение: "корректно"
        /// </summary>
        /// <param name="text">Проверяемая строка/текст</param>
        /// <returns></returns>
        public static string CheckCorrectBrackets(string text)
        {
            inputText = text;
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    int varTemp = FindeStartSymbIndex(i);
                    if (varTemp >= 0)
                    {
                        i = FinderBracketsInSubtext(varTemp);
                        if (i == -1) return "не корректно";
                    }
                    else if (varTemp == -1) { return "не корректно"; }
                    else return "корректно";
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return "не корректно";
            }
            
            return "корректно";
        }

        /// <summary>
        /// Вспомогательный метод
        /// </summary>
        /// <param name="startIndex">Индекс открывающейся скобки</param>
        /// <returns></returns>
        static int FinderBracketsInSubtext(int startIndex)
        {
            int endIndex = FindeEndSymbIndex(startIndex);
            if (endIndex == -1) return -1;

            int leftBorder = startIndex;
            int rightBorder = endIndex;
            while (leftBorder < rightBorder)
            {
                leftBorder = FindeStartSymbIndex(leftBorder + 1, rightBorder);
                if (leftBorder == -2) { break; }
                else if (leftBorder == -1) { return -1; }
                else
                {
                    rightBorder = FindeEndSymbIndex(leftBorder, rightBorder);
                    if (rightBorder == -1) { return -1; }
                }
            }

            return endIndex;
        }

        /// <summary>
        /// Метод возвращает индекс следующей открывающейся скобки
        /// </summary>
        /// <param name="startIndex">Позиция, с которой начинается поиск</param>
        /// <returns></returns>
        private static int FindeStartSymbIndex(int startIndex)
        {
            //return inputText.IndexOfAny(new char[] { '(', '{', '[' }, startIndex);
            return FindeStartSymbIndex(startIndex, inputText.Length);
        }

        /// <summary>
        /// Перегруженный метод, который возвращает индекс следующей 
        /// открывающейся скобки, но проверяет лишь определенный 
        /// диапазон знаков.
        /// Метод возвращает: индексную позицию найденной откр. скобки.
        /// Метод возвращает:-2, если не нашёл совпадений
        /// Метод возвращает: -1, если нашёл только закр. скобку 
        /// </summary>
        /// <param name="startIndex">Позиция, с которой начинается поиск</param>
        /// <param name="endIndex">Конечная позиция до которой производится поиск</param>
        /// <returns></returns>
        private static int FindeStartSymbIndex(int startIndex, int endIndex)
        {
            int foundIndexBracket = inputText.IndexOfAny(new char[] { '(', '{', '[', ')', '}', ']' },
                                        startIndex, endIndex - startIndex);
            // Если нашли только откр. скобку:
            if (foundIndexBracket != -1 && dictOfPairsBrackets.ContainsKey(inputText[foundIndexBracket]))
                return foundIndexBracket;
            // Если нашли только закр. скобку:
            else if (foundIndexBracket != -1 && !dictOfPairsBrackets.ContainsKey(inputText[foundIndexBracket]))
                return -1;
            // Если нет совпадений:
            else return -2;
        }

        /// <summary>
        /// Метод возвращает индекс парной скобки, для ранее
        /// найденной открывающейся скобки.
        /// </summary>
        /// <param name="startIndex">Позиция, с которой начинается поиск</param>
        /// <returns></returns>
        private static int FindeEndSymbIndex(int startIndex)
        {
            return inputText.IndexOf(dictOfPairsBrackets[inputText[startIndex]], startIndex);
        }

        /// <summary>
        /// Перегруженный метод возвращает индекс парной скобки, 
        /// для ранее найденной открывающейся скобки, но проверяет 
        /// лишь определенное количество знаков.
        /// </summary>
        /// <param name="startIndex">Позиция, с которой начинается поиск</param>
        /// <param name="endIndex">Конечная позиция до которой производится поиск</param>
        /// <returns></returns>
        private static int FindeEndSymbIndex(int startIndex, int endIndex)
        {
            return inputText.IndexOf(dictOfPairsBrackets[inputText[startIndex]],
                                     startIndex, endIndex - startIndex);
        }

    }
}
