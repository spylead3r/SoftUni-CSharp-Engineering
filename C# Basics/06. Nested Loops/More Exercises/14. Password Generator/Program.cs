﻿using System;

namespace _14._Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int symbol1 = 1; symbol1 <= n; symbol1++)
            {
                for (int symbol2 = 1; symbol2 <= n; symbol2++)
                {
                    for (int symbol3 = 'a'; symbol3 < 'a' + l; symbol3++)
                    {
                        for (int symbol4 = 'a'; symbol4 < 'a' + l; symbol4++)
                        {
                            for (int symbol5 = 1; symbol5 <= n; symbol5++)
                            {
                                char char1 = Convert.ToChar(symbol3);
                                char char2 = Convert.ToChar(symbol4);
                                if (symbol5 > symbol1 && symbol5 > symbol2)
                                {
                                    Console.Write($"{symbol1}{symbol2}{char1}{char2}{symbol5} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
