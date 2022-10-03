/////////////////////////////////
//
//Author: Caleb Blevins, blevinscb2@etsu.edu
//Course: CSCI-2210-001-Data Structures 
//Assignment: project 3
//Description: binary search and quicksort with jagged arrays

using Accord.Math.Optimization;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Project_3
{
    internal class Program
    {


        /// <summary>
        /// this method will basically add the min and max and divide by 2 to find the median then it will run through and compare the item we're looking for to the median through the use of a do while loop and a couple if elses it will compare until it is found
        /// </summary>
        /// <param name="bArray"></param>
        /// <param name="item"></param>
        /// <returns>the medianwhen found</returns>
        
        /// <summary>
        /// main method that will use a for loop to read in the contents of a file and store them into an array it will then convert the array to an int array and then will input the contents into the jagged array it will call on other methods to do quicksort and binaray
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Brian\\Downloads.csv");
            int[][] jaggedArray = new int[lines.Length][];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                string[] sArray = lines[i].Split(',');
                int[] iArray = Array.ConvertAll(sArray, int.Parse);
                jaggedArray[i] = iArray;
            }

            QuickSort.Sort(jaggedArray[1]);
            foreach (int[] I in jaggedArray)
            {
                foreach (int j in I)
                {
                    Console.WriteLine(j + "\n");
                }
            }
            BinarySearch.SearchBinary(jaggedArray[1], 256);

        }
    }






      



    public static class QuickSort
        {/// <summary>
        /// uses recursion to call the sorting method for subarrarys
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
            public static void Sort<T>(T[] array) where T : IComparable
            {
                Sort(array, 0, array.Length - 1);

            }
            /// <summary>
            /// helps specify what part of the array should be sorted
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="array"></param>
            /// <param name="lower"></param>
            /// <param name="upper"></param>
            /// <returns></returns>
            private static T[] Sort<T>(T[] array, int lower, int upper)
                where T : IComparable
            {
                if (lower < upper)
                {
                    int p = Partition(array, lower, upper);
                    Sort(array, lower, upper);
                    Sort(array, lower, p);
                    Sort(array, p + 1, upper);
                }
                return array;
            }/// <summary>
            /// it can pick random values to compare such as the lower and the middle and will compare and sort until sorted
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="array"></param>
            /// <param name="lower"></param>
            /// <param name="upper"></param>
            /// <returns></returns>
            private static int Partition<T>(T[] array, int lower, int upper)
                where T : IComparable
            {
                int i = lower;
                int j = upper ;
                T pivot = array[lower];
                do
                {
                    while (array[i].CompareTo(pivot) < 0) { i++; }
                    while (array[i].CompareTo(pivot) > 0) { j--; }
                    if (i >= j)
                    {
                        Swap(array, i, j);
                    }
                }
                while (i <= j);
                return j;

            }
            /// <summary>
            /// sets temp = first index and sexond index of the array
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="array"></param>
            /// <param name="first"></param>
            /// <param name="second"></param>
            private static void Swap<T>(T[] array, int first, int second)
            {
                T temp = array[first];
                array[first] = array[second];
                array[second] = temp;
            }

            }
    internal class BinarySearch
    {
        /// <summary>
        /// this method will basically add the min and max and divide by 2 to find the median then it will run through and compare the item we're looking for to the median through the use of a do while loop and a couple if elses it will compare until it is found
        /// </summary>
        /// <param name="bArray"></param>
        /// <param name="item"></param>
        /// <returns>the medianwhen found</returns>
        public static int SearchBinary(int[] bArray, int item)
        {
            int min = 0;
            int Q = bArray.Length;
            int max = Q - 1;
            do
            {
                int median = (min + max) / 2;
                if (item > bArray[median])
                {
                    min = median + 1;
                }
                else
                {
                    max = median - 1;
                }
                if (bArray[median] == item)
                {
                    return median;
                    Console.WriteLine("Your ietm was found");

                }
            }
            while (min < max);
            {
                return -1;

            }

        }
    }
        }


