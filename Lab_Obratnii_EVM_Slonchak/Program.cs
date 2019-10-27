using System;
using System.Collections.Generic;

namespace Lab_Obratnii_EVM_Slonchak
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Stack<double> stack = new Stack<double>();
            var list = new List<double>(); //Для хранения остатков от деления
            var sbytes0 = new double[7]; //Для записи 1-го числа в двоичной форме в 7 разрядной сетке
            var sbytes1 = new double[7]; //Для записи 2-го числа в двоичной форме в 7 разрядной сетке
            var sbytesfinal = new double[7]; //Для записи суммы 1-го и 2-го двоичных чисел в 7 разрядной сетке
            //var isoversized = true;
            var vihodzarazryad = true; //Флаг для выхода за разрядную сетку
            double dec0 = 0;
            double dec1 = 0;
            while (vihodzarazryad)
            {
                dec0 = int.Parse(Console.ReadLine()); //Ввод 1-го значения в 10 системе
                dec1 = int.Parse(Console.ReadLine()); //Ввод 2-го значения в 10 системе
                if (dec0 < 64 && dec0 > -65 && dec1 < 64 && dec1 > -65) vihodzarazryad = false;
            }

            var decfinal = dec0 + dec1; //Счёт значения в 10 системе
            double
                sbytestodecfinal =
                    0; //Переменная для получения результата в 10 системе путём перевода из 2 системы в 10
            var count0 = 0; //Переменная для хранения числа цифр принадлежащих 1 числу в 2 системе
            var count1 = 0; //Переменная для хранения числа цифр принадлежащих 2 числу в 2 системе
            var i = 0; //Переменная нужная для циклов
            var j = 0; //Same
            var isnegative0 = false; //Флаг знаковый для 1 числа
            var isnegative1 = false; //Флаг знаковый для 2 числа
            var razryad = false; //Флаг для переноса в старший разряд
            //var vihodzarazryad = false; //Флаг для выхода за разрядную сетку
            var isreversed = false; //Флаг для реверса массива с остатками от деления
            var iseven = false;
            var forfor = false; //Флаг для цикла сложения 2 чисел
            if (dec0 < 0)
            {
                dec0 = Math.Abs(dec0);
                isnegative0 = true;
                sbytes0[0] = 1;
            }
            else if (dec0 == -64)
            {
                dec0 = Math.Abs(dec0);
                isnegative0 = true;
                sbytes0[0] = 1;
            }

            if (dec1 < 0)
            {
                dec1 = Math.Abs(dec1);
                isnegative1 = true;
                sbytes1[0] = 1;
            }
            else if (dec1 == 64)
            {
                dec1 = Math.Abs(dec1);
                isnegative1 = true;
                sbytes1[0] = 1;
            }

            //for (; Math.Truncate(parsed) > 0; parsed /= 15) decimtemp.Add(parsed % 15);
            for (i = 0; //Процесс перевода 1-го числа в двоичное, путём записывание остатков от деления в List
                Math.Truncate(dec0) > 0;
                dec0 /= 2)
            {
                //stack.Push(Math.Truncate(dec0) % 2);
                list.Add(Math.Truncate(dec0) % 2);
                i++;
            }

            count0 = i; //Счётчик для того,чтобы знать сколько цифр принадлежит 1 числе в двоичном коде
            var temp = list.Count;
            for (i = 0; //Процесс перевода 2-го числа в двоичное, путём записывания остатков от деления в List
                Math.Truncate(dec1) > 0;
                dec1 /= 2)
            {
                list.Add(Math.Truncate(dec1) % 2);
                i++;
            }

            count1 = i; //Счётчик для того,чтобы знать сколько цифр принадлежит 2 числу в двоичном коде.

            //list.Reverse();
            if (!isnegative0
            ) //Запись двоичного кода первого числа в массив, с проверкой было ли оно изначально отрицательным.
            {
                isreversed = true;
                list.Reverse();
                j = list.Count - 1;
                for (i = sbytes0.Length - 1; i >= 0; i--)
                    if (count0 != 0)
                    {
                        sbytes0[i] = list[j--];
                        count0--;
                    }
                    else
                    {
                        sbytes0[i] = 0;
                    }

                //list.Clear();
            }
            else
            {
                for (i = sbytes0.Length - 1; i >= 0; i--)
                    if (count0 != 0)
                    {
                        sbytes0[i] = (list[j] + 1) % 2;
                        j++;
                        count0--;
                    }
                    else
                    {
                        sbytes0[i] = 1;
                    }
            }

            if (count0 > 0) vihodzarazryad = true;
            if (!isnegative1
            ) //запись двоичного кода 2-го числа в массив, с проверкой было ли оно изначально отрицательным или нет.
            {
                if (!isreversed)
                {
                    list.Reverse();
                    j = count1 - 1;
                }

                j = count1 - 1;
                for (i = sbytes1.Length - 1; i >= 0; i--)
                    if (count1 != 0)
                    {
                        sbytes1[i] = list[j--];
                        count1--;
                    }
                    else
                    {
                        sbytes1[i] = 0;
                    }
            }
            else
            {
                if (count1%2!=0)
                {
                    j = count1 - 1;
                }
                else
                {
                    j = count1;
                }
                for (i = sbytes1.Length - 1; i >= 0; i--)
                    if (count1 != 0)
                    {
                        sbytes1[i] = (list[j++] + 1) % 2;
                        count1--;
                    }
                    else
                    {
                        sbytes1[i] = 1;
                    }
            }

            if (count1 > 0) vihodzarazryad = true;
            temp = 0;
            //count0 = Int32.Parse(sbytesfinal[0].ToString());
            for (i = sbytesfinal.Length - 1; //Сложение двоичных чисел с обратным кодом.
                i >= 0;
                i--)
            {
                if (i == 0 && sbytes0[0] == 0 && sbytes1[0] == 0 && temp == 1) vihodzarazryad = true;
                if (sbytes0[i] == 1 && sbytes1[i] == 1 && forfor == false && temp == 0)
                {
                    sbytesfinal[i] = (sbytes0[i] + sbytes1[i]) % 2;
                    razryad = true;
                    temp = 1;
                    forfor = true;
                }
                else if (temp == 1 && !forfor)
                {
                    forfor = true;
                    sbytesfinal[i] = (sbytes0[i] + sbytes1[i]) % 2;
                    if (sbytes0[i] == 1 && sbytes1[i] == 1) temp++;
                    if (sbytesfinal[i] == 0)
                    {
                        sbytesfinal[i] = 1;
                        temp--;
                    }
                    else
                    {
                        sbytesfinal[i] = 0;
                        temp = 1;
                    }
                }
                else if (!forfor)
                {
                    sbytesfinal[i] = (sbytes0[i] + sbytes1[i]) % 2;
                }

                forfor = false;
            }

            if (temp > 0 /*||count0!=sbytesfinal[0]*/) //Циклический перенос в случае выхода за разрядную сетку
            {
                vihodzarazryad = true;
                for (i = sbytesfinal.Length - 1; i >= 0; i--)
                {
                    if (temp == 0) break;
                    if (sbytesfinal[i] == 0)
                    {
                        sbytesfinal[i] = 1;
                        temp--;
                    }
                    else
                    {
                        sbytesfinal[i] = 0;
                    }

                    //sbytesfinal[i] = (sbytesfinal[i] + 1)%2;
                }
            }

            //count0 = 0;
            count1 = 0;
            foreach (var d in sbytesfinal)
                if (d == 1)
                    count1++;
            if (count1 % 2 == 0) iseven = false;
            else iseven = true;
            Console.Write("Обратный код:");
            foreach (var @double in sbytesfinal) //Вывод получившегося обратного кода
                Console.Write(@double);
            temp = sbytesfinal.Length - 1;
            if (sbytesfinal[0] == 0)
            {
                for (i = 0; i < sbytesfinal.Length; i++) sbytestodecfinal += sbytesfinal[i] * Math.Pow(2, temp--);
            } //Перевод из 2 в 10 с проверкой на знак
            else
            {
                for (i = sbytesfinal.Length - 1; i >= 0; i--) sbytesfinal[i] = (sbytesfinal[i] + 1) % 2;
                for (i = 0; i < sbytesfinal.Length; i++) sbytestodecfinal += sbytesfinal[i] * Math.Pow(2, temp--);
            }

            Console.WriteLine("\nИз обратного кода в 10 систему счисления:" + " " + sbytestodecfinal);
            Console.WriteLine("Результат сложения в 10 изначально" + " " + decfinal);
            if (iseven) Console.WriteLine("Результат двоичной чётности:Чётное");
            else Console.WriteLine("Результат двоичной чётности:Нечётное");
            if (sbytesfinal[0] == 0) Console.WriteLine("Результат по знаковому биту положительный");
            else Console.WriteLine("Результат по знаковому биту отрицательный");
            if (razryad) Console.WriteLine("Есть переносы в старший разряд");
            else Console.WriteLine("Переносов нет");
            if (vihodzarazryad) Console.WriteLine("Есть выход за разрядную сетку");
            else Console.WriteLine("Выхода за разрядную сетку нет");
            //if (vihodzarazryad) Console.WriteLine("Не хватает размера разрядной сетки для записи числа");
            //else Console.WriteLine("Для записи хватает разрядной сетки, не учитывая знаковый бит");
            Console.ReadKey(true);
        }
    }
}