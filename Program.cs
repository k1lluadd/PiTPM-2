using System;

namespace Lab2_Functions_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №2: Функции (C#)");
                Console.WriteLine("Выберите задание для выполнения:");
                Console.WriteLine(" 1  - Поиск максимума и его индекса в массиве");
                Console.WriteLine(" 2  - Периметр треугольника по трем сторонам");
                Console.WriteLine(" 3  - Возведение числа в степень (циклом)");
                Console.WriteLine(" 4  - Расстояние между двумя точками на плоскости");
                Console.WriteLine(" 5  - Упорядочивание двух чисел по убыванию");
                Console.WriteLine(" 6  - Перестановка цифр в двузначном числе");
                Console.WriteLine(" 7  - Поразрядная сумма двух двузначных чисел");
                Console.WriteLine(" 8  - Поэлементное умножение двух массивов");
                Console.WriteLine(" 9  - Объединение двух массивов");
                Console.WriteLine(" 10 - Расчет числа сочетаний C");
                Console.WriteLine(" 11 - Проверка числа на палиндром");
                Console.WriteLine(" 12 - Удаление всех пробелов из строки");
                Console.WriteLine(" 13 - Удаление заданного слова из строки");
                Console.WriteLine(" 14 - Реверс массива и его вывод");
                Console.WriteLine(" 0  - Выход из программы");
                Console.Write("\nВаш выбор: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("\nОшибка: введите число от 0 до 14.");
                    WaitForKey();
                    continue;
                }

                if (choice == 0) { isRunning = false; continue; }
                if (choice < 1 || choice > 14)
                {
                    Console.WriteLine("\nОшибка: задание должно быть от 1 до 14.");
                    WaitForKey();
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Выполнение задания {choice}\n");

                try
                {
                    switch (choice)
                    {
                        case 1: RunTask1(); break;
                        case 2: RunTask2(); break;
                        case 3: RunTask3(); break;
                        case 4: RunTask4(); break;
                        case 5: RunTask5(); break;
                        case 6: RunTask6(); break;
                        case 7: RunTask7(); break;
                        case 8: RunTask8(); break;
                        case 9: RunTask9(); break;
                        case 10: RunTask10(); break;
                        case 11: RunTask11(); break;
                        case 12: RunTask12(); break;
                        case 13: RunTask13(); break;
                        case 14: RunTask14(); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nПроизошла ошибка: {ex.Message}");
                }

                WaitForKey();
            }

            Console.WriteLine("\nПрограмма завершена");
        }
        static void RunTask1()
        {
            int[] numbers = { 5, 2, 9, 1, 7 };
            Console.Write("Массив: ");
            foreach (int n in numbers) Console.Write(n + " ");
            ArrMax(numbers);
        }
        static void ArrMax(int[] arr)
        {
            int max = arr[0], index = 0;
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) { max = arr[i]; index = i; }
            Console.WriteLine($"\nМаксимум: {max}, Индекс: {index}");
        }

        static void RunTask2()
        {
            Console.WriteLine("Введите три стороны треугольника:");
            double a = ReadDouble("Сторона a: ");
            double b = ReadDouble("Сторона b: ");
            double c = ReadDouble("Сторона c: ");
            Console.WriteLine($"Периметр треугольника: {Perimeter(a, b, c)}");
        }
        static double Perimeter(double x, double y, double z) => x + y + z;

        static void RunTask3()
        {
            int num = ReadInt("Введите число: ");
            int power = ReadInt("Введите степень: ");
            Console.WriteLine($"{num} в степени {power} = {GetPow(num, power)}");
        }
        static int GetPow(int number, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++) result *= number;
            return result;
        }

        static void RunTask4()
        {
            Console.WriteLine("Введите координаты первой точки:");
            double x1 = ReadDouble("x1 = ");
            double y1 = ReadDouble("y1 = ");
            Console.WriteLine("\nВведите координаты второй точки:");
            double x2 = ReadDouble("x2 = ");
            double y2 = ReadDouble("y2 = ");
            Console.WriteLine($"\nРасстояние между точками: {Distance(x1, y1, x2, y2):F2}");
        }
        static double Distance(double x1, double y1, double x2, double y2)
        {
            double dx = x2 - x1, dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        static void RunTask5()
        {
            int a = ReadInt("Введите первое число: ");
            int b = ReadInt("Введите второе число: ");
            Console.WriteLine($"До: a = {a}, b = {b}");
            MinMax(ref a, ref b);
            Console.WriteLine($"После: a = {a}, b = {b}");
        }
        static void MinMax(ref int x, ref int y)
        {
            if (x < y) { int temp = x; x = y; y = temp; }
        }

        static void RunTask6()
        {
            int num = ReadInt("Введите двузначное число: ");
            Console.WriteLine($"Исходное число: {num}");
            ChangeDigits(ref num);
            Console.WriteLine($"После перестановки: {num}");
        }
        static void ChangeDigits(ref int number)
        {
            int units = number % 10;
            int tens = number / 10;
            number = units * 10 + tens;
        }

        static void RunTask7()
        {
            int a = ReadInt("Введите первое двузначное число: ");
            int b = ReadInt("Введите второе двузначное число: ");
            Console.WriteLine($"Поразрядная сумма {a} и {b} = {BitwiseSum(a, b)}");
        }
        static int BitwiseSum(int x, int y)
        {
            int x1 = x / 10, x2 = x % 10;
            int y1 = y / 10, y2 = y % 10;
            return ((x1 + y1) % 10) * 10 + (x2 + y2) % 10;
        }

        static void RunTask8()
        {
            int[] A = ReadArray(3, "первого");
            int[] B = ReadArray(3, "второго");
            int[] C = ArrMul(A, B);
            Console.WriteLine("\nРезультат умножения:");
            PrintArray(C);
        }
        static int[] ArrMul(int[] a, int[] b)
        {
            int[] c = new int[a.Length];
            for (int i = 0; i < a.Length; i++) c[i] = a[i] * b[i];
            return c;
        }

        static void RunTask9()
        {
            int[] A = ReadArray(3, "первого");
            int[] B = ReadArray(3, "второго");
            int[] C = MakeArr(A, B);
            Console.WriteLine("\nОбъединённый массив:");
            PrintArray(C);
        }
        static int[] MakeArr(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++) c[i] = a[i];
            for (int i = 0; i < b.Length; i++) c[a.Length + i] = b[i];
            return c;
        }

        static void RunTask10()
        {
            int k = 5;
            int n1 = ReadInt("Введите количество кандидатов 1: ");
            int n2 = ReadInt("Введите количество кандидатов 2: ");
            int n3 = ReadInt("Введите количество кандидатов 3: ");
            Console.WriteLine($"\nКоманда из {k} человек:");
            Console.WriteLine($"C({n1}, {k}) = {Combination(n1, k)}");
            Console.WriteLine($"C({n2}, {k}) = {Combination(n2, k)}");
            Console.WriteLine($"C({n3}, {k}) = {Combination(n3, k)}");
        }
        static long Combination(int n, int k)
        {
            if (k == 0 || k == n) return 1;
            long result = 1;
            for (int i = 1; i <= k; i++) result = result * (n - k + i) / i;
            return result;
        }

        static void RunTask11()
        {
            int num = ReadInt("Введите число: ");
            Console.WriteLine(Palindrome(num) ? $"{num} - это палиндром" : $"{num} - это не палиндром");
        }
        static bool Palindrome(int n)
        {
            int original = n, reversed = 0;
            while (n > 0) { reversed = reversed * 10 + n % 10; n /= 10; }
            return original == reversed;
        }

        static void RunTask12()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Результат: {ClearSpaces(input)}");
        }
        static string ClearSpaces(string s)
        {
            string result = "";
            foreach (char c in s) if (c != ' ') result += c;
            return result;
        }

        static void RunTask13()
        {
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            Console.Write("Введите слово для удаления: ");
            string word = Console.ReadLine();
            Console.WriteLine($"Результат: {ClearWord(text, word)}");
        }
        static string ClearWord(string text, string word) => text.Replace(word, "");

        static void RunTask14()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.Write("Исходный массив: ");
            PrintArray(arr);
            ReverseArr(arr);
            Console.Write("Перевёрнутый массив: ");
            PrintArray(arr);
        }
        static void ReverseArr(int[] array)
        {
            int left = 0, right = array.Length - 1;
            while (left < right)
            {
                int temp = array[left];
                array[left++] = array[right];
                array[right--] = temp;
            }
        }
        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val)) return val;
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double val)) return val;
                Console.WriteLine("Ошибка: введите число.");
            }
        }

        static int[] ReadArray(int size, string label)
        {
            int[] arr = new int[size];
            Console.WriteLine($"Введите {size} числа для {label} массива:");
            for (int i = 0; i < size; i++) arr[i] = ReadInt($"[{i}] = ");
            return arr;
        }

        static void WaitForKey()
        {
            Console.WriteLine("\n\nНажмите Enter для возврата в главное меню...");
            Console.ReadLine();
        }
    }
}