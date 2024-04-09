using System;

namespace завдання_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueExecution = true;

            while (continueExecution)
            {
                // Виведення меню опцій
                Console.WriteLine("Оберіть опцію:");
                Console.WriteLine("1. Ввести масив з клавіатури");
                Console.WriteLine("2. Заповнити масив випадковими числами");
                Console.WriteLine("3. Вийти з програми");

                // Зчитування вибору користувача
                string input = Console.ReadLine();

                // Обробка вибору користувача
                switch (input)
                {
                    case "1":
                        RunTaskA(); // Виклик функції для ручного введення масиву
                        break;
                    case "2":
                        RunTaskB(); // Виклик функції для заповнення масиву випадковими числами
                        break;
                    case "3":
                        continueExecution = false; // Вихід з програми
                        break;
                    default:
                        Console.WriteLine("Некоректний вибір. Будь ласка, введіть число від 1 до 3.");
                        break;
                }
            }
        }

        // Функція для ручного введення масиву
        static void RunTaskA()
        {
            Console.WriteLine("Введіть розмірність масиву n:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле додатне число для розмірності масиву.");
                return;
            }

            int[] array = new int[n];
            InputArray(array); // Виклик функції для введення масиву
            PrintResults(array); // Вивід результатів обробки масиву
        }

        // Функція для заповнення масиву випадковими числами
        static void RunTaskB()
        {
            Console.WriteLine("Введіть розмірність масиву n:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле додатне число для розмірності масиву.");
                return;
            }

            int[] array = new int[n];
            FillArrayRandom(array); // Виклик функції для заповнення масиву випадковими числами

            // Виведення масиву на екран
            Console.WriteLine("Згенерований масив:");
            PrintArray(array);

            PrintResults(array); // Вивід результатів обробки масиву
        }

        // Функція для ручного введення масиву
        static void InputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введіть елемент масиву {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
                    i--; // Повторення введення для даного індексу
                }
            }
        }

        // Функція для заповнення масиву випадковими числами
        static void FillArrayRandom(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-100, 101); // Генерація випадкового числа з відрізка [-100, 100]
            }
        }

        // Функція для виведення масиву на екран
        static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        // Функція для виведення результатів обробки масиву
        static void PrintResults(int[] array)
        {
            int minAbsValue = FindMinAbsValue(array);
            Console.WriteLine($"Мінімальний за модулем елемент масиву: {minAbsValue}");

            int product = CalculateProduct(array);
            Console.WriteLine($"Добуток елементів масиву між першим і останнім нульовими елементами: {product}");
        }

        // Функція для знаходження мінімального за модулем елементу масиву
        static int FindMinAbsValue(int[] array)
        {
            int minAbsValue = Math.Abs(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                int absValue = Math.Abs(array[i]);
                if (absValue < minAbsValue)
                {
                    minAbsValue = absValue;
                }
            }
            return minAbsValue;
        }

        // Функція для обчислення добутку елементів масиву між першим і останнім нульовими елементами
        static int CalculateProduct(int[] array)
        {
            int firstZeroIndex = -1;
            int lastZeroIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    if (firstZeroIndex == -1)
                    {
                        firstZeroIndex = i;
                    }
                    lastZeroIndex = i;
                }
            }

            if (firstZeroIndex == -1 || firstZeroIndex == lastZeroIndex)
            {
                return 0;
            }

            int product = 1;
            for (int i = firstZeroIndex + 1; i < lastZeroIndex; i++)
            {
                product *= array[i];
            }

            return product;
        }
    }
}
