using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    private static long counter = 0;
    /*
     * Complete the 'countInversions' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    public static long countInversions(List<int> arr)
    {
        counter = 0;
        printArray("Original Array", arr.ToArray());
        int[] array = Sort(arr.ToArray(), 0, arr.Count-1);
        printArray("Sorted Array", array);
        Console.WriteLine("Inverstion to sort: " + counter);
        return counter;
    }
    
    public static int[] Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {        
            int middle = left + (right - left)/2;
            Sort(arr, left, middle);
            Sort(arr, middle+1, right);
            Merge(arr, left, middle, right);
        } 
        return arr;
    }

    public static int[] Merge(int[] arr, int left, int middle, int right)
    {
        int[] tempLeft = new int[middle-left+1];
        int[] tempRight = new int[right-middle];
        
        for (int m=0; m<tempLeft.Length; m++)
        {
            tempLeft[m] = arr[left + m];
        }
        for (int n=0; n<tempRight.Length; n++)
        {
            tempRight[n] = arr[middle + n + 1];
        }
        
        int k = left;
        int i = 0;
        int j = 0;
        while (i < tempLeft.Length && j < tempRight.Length)
        {
            if (tempLeft[i] <= tempRight[j])
            {
                arr[k++] = tempLeft[i++];
            }
            else
            {
                arr[k++] = tempRight[j++];
                counter += tempLeft.Length - i;
            }
        }
        while (i < tempLeft.Length)
        {
            arr[k++] = tempLeft[i++];
        }
        while (j < tempRight.Length)
        {
            arr[k++] = tempRight[j++];
        }      
        return arr;
    }
    
    public static void printArray(string label, int[] array)
    {
        Console.Write($"{label}: [");
        for (int i=0; i<array.Length; i++)
        {
            Console.Write($"{array[i]}, ");
        }
        Console.WriteLine("]");
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        List<int> arr = new List<int> { 2, 1, 3, 1, 2 };
        long result = Result.countInversions(arr);

        arr = new List<int> { 9, 7, 5, 3, 1 };
        Result.countInversions(arr);

        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        // int t = Convert.ToInt32(Console.ReadLine().Trim());

        // for (int tItr = 0; tItr < t; tItr++)
        // {
        //     int n = Convert.ToInt32(Console.ReadLine().Trim());

        //     List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //     long result = Result.countInversions(arr);

        //     textWriter.WriteLine(result);
        // }

        // textWriter.Flush();
        // textWriter.Close();
    }
}
