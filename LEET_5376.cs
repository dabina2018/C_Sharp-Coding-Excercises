﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEET5376
{
    public class Program
    {
        public static void Main()
        {
            int[] nums = {10,2,5};
            IList<int> result = Solution.MinSubsequence(nums);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution
    {
        public static IList<int> MinSubsequence(int[] nums)
        {
            int len = nums.Length;
            IList<int> subSeq = new List<int>();

            if(len == 1)
            {
                 subSeq.Add(nums[0]);
            }
            else
            {
                int[] sortArr = Sort(nums);
                int bPointer = findPointer(sortArr, len);

                for (int p = len - 1; p >= bPointer; p--)
                {
                    subSeq.Add(sortArr[p]);
                }
            }
            
            return subSeq;
        }
        //Sort the Array least to greatest
        static int[] Sort(int[] nums)
        {
            int[] sortArr = new int[nums.Length];
            IList<int> subSeq = new List<int>();
            int len = nums.Length;

            for (int i = 0; i <= len - 1; i++)
            {
                int lowNum = nums[i];
                for (int j = i; j < len; j++)
                {
                    int tmp;
                    if (lowNum > nums[j])
                    {
                        lowNum = nums[j];
                        tmp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = tmp;
                    }
                }
                sortArr[i] = lowNum;
            }
            /*foreach (var item in sortArr)
            {
                System.Console.WriteLine(item);
            }*/
            return sortArr;
        }

        //find the front Pointer for cut off point
        static int findPointer(int[] sortArr, int len)
        {
            int bPointer = len - 1;
            int fPointer = 0;

            int sumF = sortArr[fPointer];
            int sumB = sortArr[bPointer];

            for (int k = 0; k < (bPointer-1); k++)
            {
                if (sumF > sumB)
                {
                    /*if(fPointer >= bPointer)
                    {
                        sumF = sumF - sortArr[fPointer];
                        fPointer--;
                    }*/
                    bPointer--;
                    sumB = sumB + sortArr[bPointer];
                }
                else
                {
                    fPointer++;
                    sumF = sumF + sortArr[fPointer];
                }
            }
            /*Console.WriteLine(sumB );
            Console.WriteLine(sumF);
            Console.WriteLine(bPointer);
            Console.WriteLine(fPointer);*/
            return bPointer;
        }
    }
}


