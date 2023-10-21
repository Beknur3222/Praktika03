using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika03
{
    internal class Program
    {
        static void Exp01()
        {
            double[] A = new double[5];
            double[,] B = new double[3, 4];

            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Введите элемент A[{i}]: ");
                A[i] = Convert.ToDouble(Console.ReadLine());
            }


            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.NextDouble();
                }
            }

            Console.WriteLine("Массив A:");
            foreach (var element in A)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();

            Console.WriteLine("Массив B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{B[i, j]:F2}\t");
                }
                Console.WriteLine();
            }


            double maxA = A.Max();
            double minA = A.Min();
            double maxB = B.Cast<double>().Max();
            double minB = B.Cast<double>().Min();

            Console.WriteLine($"Максимальный элемент в A: {maxA}");
            Console.WriteLine($"Минимальный элемент в A: {minA}");
            Console.WriteLine($"Максимальный элемент в B: {maxB:F2}");
            Console.WriteLine($"Минимальный элемент в B: {minB:F2}");


            double sumA = A.Sum();
            double sumB = B.Cast<double>().Sum();
            double productA = A.Aggregate((x, y) => x * y);
            double productB = B.Cast<double>().Aggregate((x, y) => x * y);

            Console.WriteLine($"Сумма всех элементов в A: {sumA}");
            Console.WriteLine($"Сумма всех элементов в B: {sumB:F2}");
            Console.WriteLine($"Произведение всех элементов в A: {productA}");
            Console.WriteLine($"Произведение всех элементов в B: {productB:F2}");


            double sumEvenA = A.Where(x => x % 2 == 0).Sum();
            Console.WriteLine($"Сумма четных элементов в A: {sumEvenA:F2}");


            double sumOddColumnsB = 0;
            for (int j = 0; j < 4; j++)
            {
                if (j % 2 != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        sumOddColumnsB += B[i, j];
                    }
                }
            }
            Console.WriteLine($"Сумма нечетных столбцов в B: {sumOddColumnsB:F2}");
        }
        static void Exp02()
        {
            int[] M = { 1, 2, 3, 4, 5 };
            int[] N = { 3, 4, 5, 6, 7 };

            int[] commonElements = M.Intersect(N).ToArray();

            Console.WriteLine("Общие элементы без повторений:");
            foreach (int element in commonElements)
            {
                Console.Write(element + " ");
            }
        }
        static void Exp03()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            input = input.Replace(" ", "").ToLower();

            bool isPalindrome = true;
            int length = input.Length;

            for (int i = 0; i < length / 2; i++)
            {
                if (input[i] != input[length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
                Console.WriteLine("Это палиндром.");
            else
                Console.WriteLine("Это не палиндром.");
        }
        static void Exp04()
        {
            Console.Write("Введите предложение: ");
            string sentence = Console.ReadLine();

            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int wordCount = words.Length;
            Console.WriteLine($"Количество слов в предложении: {wordCount}");
        }
        static void Exp05()
        {
            int[,] matrix = new int[5, 5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = random.Next(-100, 101);
                }
            }

            int min = matrix[0, 0];
            int max = matrix[0, 0];
            int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            int sum = 0;
            bool betweenMinMax = false;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if ((i == minRow && j == minCol) || (i == maxRow && j == maxCol))
                    {
                        betweenMinMax = !betweenMinMax; 
                    }
                    else if (betweenMinMax)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine("Матрица:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Минимальный элемент: {min}");
            Console.WriteLine($"Максимальный элемент: {max}");
            Console.WriteLine($"Сумма элементов между минимумом и максимумом: {sum}");
        }
        static void Exp06()
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            char currentChar = '\0';
            char maxChar = '\0';
            int currentCount = 0;
            int maxCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == currentChar)
                {
                    currentCount++;
                }
                else
                {
                    currentChar = text[i];
                    currentCount = 1;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxChar = currentChar;
                }
            }

            Console.WriteLine($"Наибольшее количество идущих подряд одинаковых символов: {maxCount}");
            Console.WriteLine($"Символ, который повторяется: {maxChar}");
        }
        static void Exp07()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            int digitCount = 0;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }

            Console.WriteLine($"Количество цифр в строке: {digitCount}");
        }
        static void Exp08()
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            string name = "ваше имя";

            text = text.ToLower();
            name = name.ToLower();

            if (text.Contains(name))
            {
                Console.WriteLine("Ваше имя найдено: " + name);
            }
            else
            {
                Console.WriteLine("Нет имени.");
            }
        }
        static void Exp09()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            foreach (string word in words)
            {
                if (word.Length >= 2 && word[0] == word[word.Length - 1])
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество слов, у которых первый и последний символы совпадают: {count}");
        }
        static void Exp10()
        {
            Console.Write("Введите малую русскую букву: ");
            char lowercaseLetter = Console.ReadLine()[0];

            if (char.IsLower(lowercaseLetter) && lowercaseLetter >= 'а' && lowercaseLetter <= 'я')
            {
                char uppercaseLetter = char.ToUpper(lowercaseLetter);
                Console.WriteLine($"Соответствующая большая буква: {uppercaseLetter}");
            }
            else
            {
                Console.WriteLine("Это не малая русская буква.");
            }
        }
        static void Main(string[] args)
        {
            Exp01();
            Exp02();
            Exp03();
            Exp04();
            Exp05();
            Exp06();
            Exp07();
            Exp08();
            Exp09();
            Exp10();
            Console.ReadKey();
        }
    }
}
