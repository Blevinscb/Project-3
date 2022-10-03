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
            string filepath = "C:\\Users\\Brian\\Downloads";                 //creates the filepath 
            StreamReader sr = new StreamReader(filepath);                    //creates the stremreader used to read in the material
            int[][] jaggedArray = new int[20][];                              //creates the jagged array 
            for (int i = 0; i < 20; i++)                                //for loop to read in elements in the string array
            {
                
                string[] sArray = sr.ReadLine().Split(',');                                  //will split the lines
                int[] iArray = new int[sArray.Length];                 //converts the strings to ints
                int count = 0;                                         // sets count = 0
                foreach(string line in sArray)                         // will loop through all the contents of the array
                {
                    iArray[count] = Int32.Parse(line);                
                    count++;                                           //increments the count
                }
                jaggedArray[i] = iArray;
            }

            Console.WriteLine(String.Join(",", jaggedArray[0]));       //sets the basis for the jagged array
            Console.WriteLine("This is the time for quick sort");     
            for(int i = 0; i < 20; i++)                                //for loop to execute the quicksort method until all the items are sorted
            {
                QuickSort.ArrayS(jaggedArray[i], 0, jaggedArray[i].Length - 1);
                Console.Write(String.Join(",", jaggedArray[i]));
            }
            Console.WriteLine("Binary Search");
            for (int i = 0; i < 20; i++)                             //for loop for the binary search to occur
            {
                Console.WriteLine(BinarySearch.SearchBinary(jaggedArray[i], 256));
            }

           

        }
    }
  
    public static class QuickSort
    {/// <summary>
    /// will basically go through and sort the numbers using quicksort(quicksort will compare one item to another and swap them accordingly to the right position 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>the int array</returns>
        public static int[] ArrayS(int[] a, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = a[left];
            while(i<=j)           //while loop that will conmtinue as long as the smaller integer is the number on the right
            {
                while (a[i] < pivot)
                {
                    i++;
                }
                while (a[j] > pivot)
                {
                    j--;
                }
                if(i<=j)
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;        
                    i++;                   //increments the left
                    j--;                   //decrements the right
                }
            }
            if (left < j)           //if statement that will execute if the left number is smaller than the right number
                ArrayS(a, left, j);
            if (i < right)         //if statement that will execute if the left is smaller than the right
                ArrayS(a, i, right);
            return a;

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
            int min = 0;                            //sets min = 0
            int Q = bArray.Length;                  // sets q = the length of the int array
            int max = Q - 1;                        //sets the max = length -1
            while (min <= max)                      //while loop that will continue until the value is found
            {
                int median = (min + max) / 2;    //creates the median
                if (bArray[median] == item)      //returns the median incremented if statement is true
                {
                    return ++median;
                }
                else if (item < bArray[median])   //sets a new max by subtracting one from the median
                {
                    max = median - 1;
                }
                else                             //sets the minimum = median + 1
                {
                    min = median + 1;
                }

               

            }
            return -1;
        }
    }
}


