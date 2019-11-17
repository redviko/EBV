﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ThrippleCoding
{
    class Program
    {
        static string CopyIntsToString(string binary, int[] binaryInts)
        {
            binary = "";
            for (var i = 0; i < binaryInts.Length; i++)
            {
                binary += binaryInts[i].ToString();
            }

            return binary;
        }
        static void Main(string[] args)
        {
            List<string> bitsList = new List<string>();
            Console.WriteLine($"Введите десятичное число");
            string binary = Console.ReadLine();
            binary = Convert.ToString(int.Parse(binary), 2);
            Console.WriteLine($"Результат до кодирования: {binary}");
            for (var i = 0; i < binary.Length; i += 4)
            {
                binary = binary.Insert(i + 1, (binary[i].ToString() + binary[i] + binary[i]));
                bitsList.Add(binary[i].ToString());
            }

            Console.WriteLine($"Результат кодирования: {binary}");
            Int32[] wrongBitsInts = new int[2];
            Int32[] binaryInts=new int[binary.Length];
            for (var i = 0; i < binary.Length; i++)
            {
                binaryInts[i] = int.Parse(binary[i].ToString());
            }
            Console.WriteLine($"Допущена ошибка в одном бите - 1\r\nВ двух - 2");
            int n;
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine($"Введите бит в котором будет допущена ошибка\r\nВсего битов: {binary.Length}");
                    n = int.Parse(Console.ReadLine());
                    n--;
                    binaryInts[n] = (binaryInts[n]+ 1) % 2;
                    break;
                case 2:
                    Console.WriteLine($"Введите биты в которых будет допущена ошибка\r\nВсего битов: {binary.Length}");
                    for (int i = 0; i < 2; i++)
                    {
                        n = int.Parse(Console.ReadLine());
                        n--;
                        binaryInts[n] = (binaryInts[n]+ 1) % 2;
                    }
                    break;
                default:
                    Console.WriteLine($"Что-то пошло не так");
                    break;
            }

            binary = Program.CopyIntsToString(binary, binaryInts);
            Console.WriteLine($"Число после того, как внесли ошибки:{binary}");
            
            int evencount = 0;
            int count = 0;
            int temp = 0;
            bool flag = false;
            for (int i = 1; i < binaryInts.Length; i++)
            {
                if (count!=3)
                {
                    temp += binaryInts[i];
                    count++;
                }
                else
                {
                    count = 0;

                    if (temp >= 2 && !flag)
                    {
                        binaryInts[evencount] = 1;
                        flag = true;
                        temp = 0;
                    }
                    else if (temp<=1 &&!flag)
                    {
                        binaryInts[evencount] = 0;
                        flag = true;
                        temp = 0;
                    }
                    else if (temp >= 2)
                    {
                        evencount += 4;
                        binaryInts[evencount] = 1;
                        temp = 0;
                    }
                    else if (temp <= 1)
                    {
                        evencount += 4;
                        binaryInts[evencount] = 0;
                        temp = 0;
                    }
                }
            }

            binary = CopyIntsToString(binary, binaryInts);
           

            Console.WriteLine($"После вычисления и исправления ошибки: {binary}");
            count = 0;
            for (var i = 0; i < binary.Length-1; i++)
            {
                binary=binary.Remove(i+1, 3);
            }

            Console.WriteLine($"Декодированное в 2 системе: {binary}");
            Console.WriteLine($"Число в десятичной после декодировки и исправления ошибок: {Convert.ToInt32(binary, 2)}");
            Console.ReadKey(true);
        }
    }
}