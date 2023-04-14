﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSVP_lab04_FordBellman
{
    internal class Program
    {

        static void FordBellman(int[,] graph, int start)
        {
            int n = graph.GetLength(0);
            int[] distances = new int[n];

            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue; // устанавливаем начальное расстояние до всех вершин как бесконечность
            }

            distances[start] = 0; // начальное расстояние до стартовой вершины равно 0

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        int edgeDistance = graph[j, k];

                        if (edgeDistance > 0 && distances[j] + edgeDistance < distances[k])
                        {
                            distances[k] = distances[j] + edgeDistance;
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Кратчайшее расстояние от вершины {0} до вершины {1} равно {2}", start, i, distances[i]);
            }
        }
        static void Main(string[] args)
        {
            int[,] graph = {
            { 0, 6, 0, 1, 0 },
            { 6, 0, 5, 2, 2 },
            { 0, 5, 0, 0, 5 },
            { 1, 2, 0, 0, 1 },
            { 0, 2, 5, 1, 0 },
        };

            FordBellman(graph, 0); // вызов алгоритма Форда-Беллмана для графа и вершины 0
            Console.ReadKey();

        }
    }
}
