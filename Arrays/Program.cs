// See https://aka.ms/new-console-template for more information

using System.Drawing;

try
{    
    Console.WriteLine("Arrays problems");

    Console.WriteLine("Problem #1");
    int[] numbers = [3,6];
    int tarjet = 9;
    int[] result = TwoSum(numbers, tarjet);
    foreach (int item in result) Console.Write($"{item} ");
    Console.Write("\n");

    Console.WriteLine("Problem #2");
    int[] sortedA = [1,2];
    int[] sortedB = [3,4];
    double median = FindMedianSortedArrays(sortedA, sortedB);
    Console.WriteLine($"The median of the merged Array is: {median}");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

/*Problem #1: Two Sum (https://leetcode.com/problems/two-sum/description/)
Given an array of integers nums and an integer target, return indices of 
the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.*/
static int[] TwoSum(int[] nums, int target)
{
    // Constraints
    if(nums.Length < 2 || nums.Length > 10000) 
        throw new Exception("Array too long or short");
    if(target < Math.Pow(-10, 9) || target > Math.Pow(10, 9))
        throw new Exception("Target too big or small");
    if(nums[0] < Math.Pow(-10, 9) || nums[0] > Math.Pow(10, 9))
        throw new Exception("There's a item too big or small");
    
    for (int i = 0; i < nums.Length - 1; i++)
    {
        if(nums[i] > target) continue;
        for (int j = i+1; j < nums.Length; j++)
        {
            if(nums[j] < Math.Pow(-10, 9) || nums[j] > Math.Pow(10, 9))
                throw new Exception("There's a item too big or small");
            if(nums[j] > target) continue;
            if(nums[i] + nums[j] == target) 
                return [nums.IndexOf(nums[i]), nums.IndexOf(nums[j])];
        }
    }

    throw new Exception("Couldn't find any pair");
}

/*Problem #2: Median of two sorted Arrays (https://leetcode.com/problems/median-of-two-sorted-arrays/)
Given two sorted arrays nums1 and nums2 of size m and n respectively, return 
the median of the two sorted arrays.
Solution in O(m+n)
*/
static double FindMedianSortedArrays(int[] numsA, int[] numsB)
{
    if(numsA.Length < 0 || numsA.Length > 1000)
        throw new Exception("Array A too long or too short");
    if(numsB.Length < 0 || numsB.Length > 1000)
        throw new Exception("Array B too long or too short");
    
    foreach(int i in numsA)
        if(i < -Math.Pow(10,6) || i > Math.Pow(10,6))
            throw new Exception("An element in A is too big or small");
    foreach(int i in numsB)
        if(i < -Math.Pow(10,6) || i > Math.Pow(10,6))
            throw new Exception("An element in B is too big or small");

    int[] sortedArray = new int[numsA.Length + numsB.Length];
    int pointerA = 0;
    int pointerB = 0;
    bool endA = false;
    bool endB = false;

    for(int i = 0; i < sortedArray.Length; i++)
    {
        if((numsA[pointerA] < numsB[pointerB] && !endA) || endB)
        {
            sortedArray[i] = numsA[pointerA];
            if(pointerA == numsA.Length -1) endA = true;
            else pointerA++;
        }
        else if (!endB)
        {
            sortedArray[i] = numsB[pointerB];
            if(pointerB == numsB.Length -1) endB = true;
            else pointerB++;
        }
    }

    int finalLength = sortedArray.Length;

    if(finalLength%2 == 0) {
        int positionA = finalLength/2 - 1;
        int positionB = finalLength/2;
        return (double)(sortedArray[positionA] + sortedArray[positionB]) / 2;
    }
    else
    {
        int position = finalLength/2;
        return sortedArray[position];
    }
}