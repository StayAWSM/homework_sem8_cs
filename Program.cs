//----------------Используемые методы----------------
Random rnd = new Random();
double[,] FillArray() //Метод создания, наполнения и печати двумерного массива
{
    Console.WriteLine("Введите размер массива (m*n): ");
    var (m, n) = (Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
    Console.WriteLine("Создание двумерного массива...");
    Console.WriteLine();
    double[,] array = new double[m, n];
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++) //метод наполнения двумерного массива
    {
        Console.Write("[ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(1, 10);
            Console.Write(array[i, j] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
    Console.WriteLine();
    return array;
}

int[,] Multiplication(int[,] matrix1, int[,] matrix2) //Метод перемножения матриц
{
    if (matrix1.GetLength(1) != matrix2.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
    int[,] res = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int k = 0; k < matrix2.GetLength(0); k++)
            {
                res[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return res;
}

void Print(int[,] array) //Метод печати матриц
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

void Print3D(int[,,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int depth = matrix.GetLength(2);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < depth; k++)
            {
                Console.Write($"{matrix[i, j, k]} ({i},{j},{k}) \t");
            }
            Console.WriteLine();
        }
    }
}
//----------------Решаемые задачи--------------------
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void task1()
{
    Console.Clear();
    Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит");
    Console.WriteLine("по убыванию элементы каждой строки двумерного массива.");
    double[,] array = FillArray();

    Console.WriteLine("Сортировка массива");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int maxVal = j;
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, k] > array[i, maxVal]) maxVal = k;
            }
            double tempVal = array[i, j];
            array[i, j] = array[i, maxVal];
            array[i, maxVal] = tempVal;
            Console.Write(array[i, j] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
    Console.ReadKey();
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void task2()
{
    Console.Clear();
    Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
    Console.Write("Введите размер массива N: ");
    int arrSize = Convert.ToInt32(Console.ReadLine()); //Создаем массив, указывая вручную размер, и заполняем случайными значениями
    //Массив будет квадратным, т.к. в примере указан с равными "сторонами", а двумерный массив по умолчанию прямоугольный.
    //Раз указали дополнительно, что двумерный массив - прямоугольный, то скорее всего имели ввиду "квадратный".
    int[,] array = new int[arrSize, arrSize];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(1, 10);
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine("]");
    }
    Console.WriteLine();

    int[] sumArray = new int[arrSize]; //Считаем суммы строк
    for (int i = 0; i < sumArray.Length; i++)
    {
        int sumRow = 0;
        Console.Write("[ ");
        for (int j = 0; j < array.GetLength(0); j++)
        {
            sumRow += array[i, j];
        }
        sumArray[i] = sumRow;
        Console.Write($"Сумма {i + 1} строки равна {sumRow} ");
        Console.WriteLine("]");
    }

    int minVal = 0; //Сравниваем и выводим минимальное из всех строк через циклы
    for (int i = 1; i < sumArray.Length; i++)
    {
        if (sumArray[i] < sumArray[minVal]) minVal = i;
    }
    Console.WriteLine($"Строка номер {minVal + 1}");
    Console.ReadKey();
}

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

void task3()
{
    Console.Clear();
    Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
    Console.WriteLine("Введите размерность матрицы А: ");
    int[,] matrix1 = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            matrix1[i, j] = rnd.Next(1, 10);
        }
    }

    Console.WriteLine("Введите размерность матрицы B: ");
    int[,] matrix2 = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
    for (int i = 0; i < matrix2.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            matrix2[i, j] = rnd.Next(1, 10);
        }
    }

    Console.WriteLine("\nМатрица A:");
    Print(matrix1);
    Console.WriteLine("\nМатрица B:");
    Print(matrix2);
    Console.WriteLine("\nМатрица C = A * B:");
    int[,] matrixRes = Multiplication(matrix1, matrix2);
    Print(matrixRes);
    Console.ReadKey();
}

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void task4()
{
    static IEnumerable<int> UniqueRandomNumbers(int from, int to) //Генерация случайных неповторяемых чисел
    {
        Random rand = new();
        int[] values = Enumerable.Range(from, to).ToArray();
        int i = values.Length;
        while (i > 0)
        {
            int j = rand.Next(i--);
            yield return values[j];

            (values[i], values[j]) = (values[j], values[i]);
        }
    }

    int[,,] matrix = new int[2, 2, 2]; //Заполнение случайными числами массива
    IEnumerator<int> iterator = UniqueRandomNumbers(10, 99).GetEnumerator();
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                if (!iterator.MoveNext())
                {
                    Console.WriteLine("Уникальных чисел больше нет!");
                    return;
                }

                matrix[i, j, k] = iterator.Current;
            }

    Print3D(matrix);
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void task5()
{
    Console.Clear();
    Console.WriteLine("Упс, не получилось решить!");
    Console.ReadKey();
}

//----------------Выполнение программы----------------
void Main()
{
    Console.Clear();
    Console.WriteLine("**************************************** \n Выберите задачу, которую хотите решить:\n\t1 - Задача 54 \n\t2 - Задача 56 \n\t3 - Задача 58 \n\t4 - Задача 60 \n\t5 - Задача 62 \n\t6 - Выход");
    int num = Convert.ToInt32(Console.ReadLine());
    switch (num)
    {
        case 1:
            task1();
            Main();
            break;
        case 2:
            task2();
            Main();
            break;
        case 3:
            task3();
            Main();
            break;
        case 4:
            task4();
            Main();
            break;
        case 5:
            task5();
            Main();
            break;
        case 6:
            Console.WriteLine("Пока!");
            Console.ReadKey();
            break;
    }
}
Main();