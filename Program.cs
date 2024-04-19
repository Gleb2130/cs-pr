using System;
using System.Text;
using System.Text.RegularExpressions;

namespace HW_13_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            task7();
        }

        static void task1()
        {
            double[] a = new double[5];
            double[,] b = new double[3, 4];

            Console.WriteLine("Enter elements of array A:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"A[{i}]: ");
                a[i] = double.Parse(Console.ReadLine());
            }

            Random rand = new Random();
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = rand.NextDouble() * 100;
                }
            }

            Console.WriteLine("\nArray A:");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n\nArray B:");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    Console.Write(b[i, j] + " ");
                }
                Console.WriteLine();
            }
            double maxA = a[0];
            double minA = a[0];
            double maxB = b[0, 0];
            double minB = b[0, 0];
            foreach (var item in a)
            {
                if (item > maxA)
                    maxA = item;
                if (item < minA)
                    minA = item;
            }
            foreach (var item in b)
            {
                if (item > maxB)
                    maxB = item;
                if (item < minB)
                    minB = item;
            }

            double sumA = 0;
            double productA = 1;
            double sumB = 0;
            foreach (var item in a)
            {
                sumA += item;
                productA *= item;
            }
            foreach (var item in b)
            {
                sumB += item;
            }

            double sumEvenA = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0)
                    sumEvenA += a[i];
            }
            double sumOddColumnsB = 0;
            for (int j = 0; j < b.GetLength(1); j++)
            {
                if (j % 2 != 0)
                {
                    for (int i = 0; i < b.GetLength(0); i++)
                    {
                        sumOddColumnsB += b[i, j];
                    }
                }
            }

            Console.WriteLine($"\nMaximum element of array A: {maxA}");
            Console.WriteLine($"Minimum element of array A: {minA}");
            Console.WriteLine($"Maximum element of array B: {maxB}");
            Console.WriteLine($"Minimum element of array B: {minB}");
            Console.WriteLine($"Total sum of elements of array A: {sumA}");
            Console.WriteLine($"Total product of elements of array A: {productA}");
            Console.WriteLine($"Total sum of elements of array B: {sumB}");
            Console.WriteLine($"Sum of even elements of array A: {sumEvenA}");
            Console.WriteLine($"Sum of odd columns of array B: {sumOddColumnsB}");

            Console.ReadLine();
        }

        static void task2()
        {
            int[,] array = new int[5, 5];
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = rand.Next(-100, 101);
                }
            }

            Console.WriteLine("Initial array:");
            PrintArray(array);

            int maxIndexI = 0, maxIndexJ = 0;
            int minIndexI = 0, minIndexJ = 0;
            int max = array[0, 0];
            int min = array[0, 0];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxIndexI = i;
                        maxIndexJ = j;
                    }
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minIndexI = i;
                        minIndexJ = j;
                    }
                }
            }
            Console.WriteLine($"\nMaximum element: {max}, located at position ({maxIndexI}, {maxIndexJ})");
            Console.WriteLine($"Minimum element: {min}, located at position ({minIndexI}, {minIndexJ})");
            int sum = 0;
            int startI = Math.Min(maxIndexI, minIndexI) + 1;
            int endI = Math.Max(maxIndexI, minIndexI) - 1;
            int startJ = Math.Min(maxIndexJ, minIndexJ) + 1;
            int endJ = Math.Max(maxIndexJ, minIndexJ) - 1;
            for (int i = startI; i <= endI; i++)
            {
                for (int j = startJ; j <= endJ; j++)
                {
                    sum += array[i, j];
                }
            }
            Console.WriteLine($"\nSum of elements located between minimum and maximum elements: {sum}");
        }

        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void task3()
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();

            int shift;
            do
            {
                Console.WriteLine("Enter Caesar cipher shift (integer):");
            } while (!int.TryParse(Console.ReadLine(), out shift));
            string encrypted = Encrypt(input, shift);
            Console.WriteLine($"Encrypted text: {encrypted}");
            string decrypted = Encrypt(encrypted, -shift);
            Console.WriteLine($"Decrypted text: {decrypted}");
        }

        static string Encrypt(string input, int shift)
        {
            string result = "";
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(c + shift);
                    if ((char.IsLower(c) && encryptedChar > 'z') || (char.IsUpper(c) && encryptedChar > 'Z'))
                    {
                        encryptedChar = (char)(c - (26 - shift));
                    }
                    result += encryptedChar;
                }
                else
                    result += c;
            }
            return result;
        }

        static void task4()
        {
            Console.WriteLine("Enter matrix dimensions (rows x columns):");
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix1 = ReadMatrix("First matrix", rows, cols);
            int[,] matrix2 = ReadMatrix("Second matrix", rows, cols);

            Console.WriteLine("\nFirst matrix:");
            PrintMatrix(matrix1);
            Console.WriteLine("\nSecond matrix:");
            PrintMatrix(matrix2);

            Console.WriteLine("\nMultiplying matrix by scalar");
            Console.Write("Enter scalar: ");
            int scalar = int.Parse(Console.ReadLine());
            int[,] scaledMatrix = MultiplyByScalar(matrix1, scalar);
            PrintMatrix(scaledMatrix);

            Console.WriteLine("\nAdding matrices:");
            int[,] sumMatrix = AddMatrices(matrix1, matrix2);
            PrintMatrix(sumMatrix);

            Console.WriteLine("\nMultiplying matrices:");
            int[,] productMatrix = MultiplyMatrices(matrix1, matrix2);
            PrintMatrix(productMatrix);
        }

        static int[,] ReadMatrix(string matrixName, int rows, int cols)
        {
            Console.WriteLine($"Enter elements of matrix {matrixName}:");
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrixName}[{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static int[,] MultiplyByScalar(int[,] matrix, int scalar)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }
            return result;
        }

        static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);
            if (cols1 != rows2)
            {
                Console.WriteLine("Unable to multiply matrices: incorrect dimensions.");
                return null;
            }
            int[,] result = new int[rows1, cols2];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        static void task5()
        {
            Console.WriteLine("Enter arithmetic expression (only addition and subtraction):");
            string expression = Console.ReadLine();
            double result = EvaluateExpression(expression);
            Console.WriteLine($"Result: {result}");
        }

        static double EvaluateExpression(string expression)
        {
            string[] tokens = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
            char[] operators = new char[expression.Length - tokens.Length];
            int operatorIndex = 0;
            foreach (char c in expression)
            {
                if (c == '+' || c == '-')
                {
                    operators[operatorIndex++] = c;
                }
            }
            double result = 0;
            if (double.TryParse(tokens[0], out result))
            {
                for (int i = 1; i < tokens.Length; i++)
                {
                    double operand;
                    if (double.TryParse(tokens[i], out operand))
                    {
                        if (operators[i - 1] == '+')
                        {
                            result += operand;
                        }
                        else if (operators[i - 1] == '-')
                        {
                            result -= operand;
                        }
                    }
                    else
                        return double.NaN;
                }
            }
            else
                return double.NaN;

            return result;
        }

        static void task6()
        {
            Console.WriteLine("Enter text:");
            string text = Console.ReadLine();
            string result = CapitalizeSentences(text);
            Console.WriteLine($"Result:\n{result}");
        }

        static string CapitalizeSentences(string text)
        {
            char[] punctuationMarks = { '.', '!', '?' };
            char[] chars = text.ToCharArray();
            bool flag = true;

            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]) && flag)
                {
                    chars[i] = char.ToUpper(chars[i]);
                    flag = false;
                }
                else if (punctuationMarks.Contains(chars[i]))
                {
                    flag = true;
                }
            }

            return new string(chars);
        }


        static void task7()
        {
            Console.WriteLine("Enter text:");
            string text = Console.ReadLine();

            Console.WriteLine("Enter forbidden words (separated by comma):");
            string[] forbiddenWords = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int replacedCount = 0;
            string result = FilterText(text, forbiddenWords, out replacedCount);

            Console.WriteLine("\nResult:");
            Console.WriteLine(result);

            Console.WriteLine($"\nStatistics: {replacedCount} replacements of forbidden words.");
        }
        static string FilterText(string text, string[] forbiddenWords, out int replacedCount)
        {
            replacedCount = 0;
            foreach (string word in forbiddenWords)
            {
                text = text.Replace(word, new string('*', word.Length));
                replacedCount += text.Split(new string[] { word }, StringSplitOptions.None).Length - 1;
            }

            return text;
        }
    }
}
