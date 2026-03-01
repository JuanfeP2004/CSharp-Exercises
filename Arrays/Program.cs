// See https://aka.ms/new-console-template for more information

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

    Console.WriteLine("Problem #3");
    int[] example3 = [1,1];
    int result3 = MaxArea(example3);
    Console.WriteLine($"The max area of the heights is: {result3}");

    Console.WriteLine("Problem #4: Longest common prefix");
    string[] example4 = ["dog", "doggy", "doge"];
    string result4 = LongestCommonPrefix(example4);
    Console.WriteLine($"The longest prefix is {result4}");

    Console.WriteLine("Problem #5: 3 Sum");
    int[] example5 = [0,0,0];
    List<int[]> result5 = ThreeSum(example5);
    if(result5.Count == 0)
        Console.WriteLine("[]");
    foreach(int[] item in result5)
    {
        Console.Write("[");
        foreach(int x in item)
            Console.Write($"{x},");
        Console.Write("] ");
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

/*
    Problem #1: Two Sum 
    (https://leetcode.com/problems/two-sum/)
    Given an array of integers nums and an integer target, return indices of 
    the two numbers such that they add up to target.
    You may assume that each input would have exactly one solution, and you may 
    not use the same element twice.
    You can return the answer in any order.
*/
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

/*
    Problem #2: Median of two sorted Arrays 
    (https://leetcode.com/problems/median-of-two-sorted-arrays/)
    Given two sorted arrays nums1 and nums2 of size m and n respectively, 
    return the median of the two sorted arrays.
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

/*
    Problem #3: Max area of two heights
    (https://leetcode.com/problems/container-with-most-water/)
    You are given an integer array height of length n. There are n vertical 
    lines drawn such that the two endpoints of the ith line are (i, 0) and 
    (i, height[i]).
    Find two lines that together with the x-axis form a container, such that 
    the container contains the most water.
    Return the maximum amount of water a container can store.
    Notice that you may not slant the container.
*/
static int MaxArea(int[] heights)
{
    if(heights.Length < 2 || heights.Length > Math.Pow(10,5))
        throw new Exception("Heights array is too short or too long");
    foreach (int i in heights)
        if(i < 0 || i > Math.Pow(10,4))
            throw new Exception("An element of the heights array is too short or too long");

    int maxArea = 0;
    int area = 0;

    for (int i = 0; i < heights.Length; i++)
    {       
        for (int j = i+1; j < heights.Length; j++)
        {
            area = (j-i)*int.Min(heights[i], heights[j]);
            if(area >= maxArea)
                maxArea = area;
        }
    }

    return maxArea;
}

/*
    Problem #4: Find the longest common substring
    (https://leetcode.com/problems/longest-common-prefix/)
    Write a function to find the longest common prefix string amongst an array 
    of strings.
    If there is no common prefix, return an empty string "".
*/
static string LongestCommonPrefix(string[] strings)
{
    if(strings.Length < 1 || strings.Length > 200)
        throw new Exception("There are 0 strings or many strings");

    string prefix = "";
    int shortestString = int.MaxValue;

    for (int i = 0; i < strings.Length; i++)
    {
        if(strings[i].Length < shortestString)
            shortestString = strings[i].Length;
        else if (strings[i].Length < 0 || strings[i].Length > 200)
            throw new Exception("One of the strings is too short or too long");
    }

    char caracter = ' ';

    for (int i = 0; i < shortestString; i++)
    {
        for (int j = 0; j < strings.Length; j++)
        {
            if(j == 0)
                caracter = strings[0][i];
            else
                if(strings[j][i] != caracter)
                {
                    return prefix;
                }
        }
        prefix += strings[0][i];
    }
    return prefix;
}

/*
    Problem #5: 3 Sum
    (https://leetcode.com/problems/3sum/)
    Given an integer array nums, return all the triplets [nums[i], nums[j], 
    nums[k]] such that i != j, i != k, and j != k, 
    and nums[i] + nums[j] + nums[k] == 0.
    Notice that the solution set must not contain duplicate triplets.
*/
static List<int[]> ThreeSum(int[] numbers)
{
    if(numbers.Length < 3 || numbers.Length > 3000)
        throw new Exception("Numbers vector too short or too long");
    foreach(int item in numbers)
        if(item < Math.Pow(-10,5) || item > Math.Pow(10,5))
            throw new Exception("An item is too small or too big");

    List<int[]> triplets = new List<int[]>();
    for(int i = 0; i < numbers.Length - 2; i++)
    {
        for(int j = i+1; j < numbers.Length - 1; j++)
        {
            for(int k = j+1; k < numbers.Length; k++)
            {
                if(numbers[i] + numbers[j] + numbers[k] == 0){
                    
                    int min, max, mid;
                    if(triplets.Count == 0)
                    {
                        min = Math.Min(Math.Min(numbers[i], numbers[j]), numbers[k]);
                        max = Math.Max(Math.Max(numbers[i], numbers[j]), numbers[k]);
                        triplets.Add([min,-min-max,max]);
                        break;  
                    }
                    foreach(int[] item in triplets)
                    {
                        min = Math.Min(Math.Min(numbers[i], numbers[j]), numbers[k]);
                        max = Math.Max(Math.Max(numbers[i], numbers[j]), numbers[k]);
                        mid = -min -max;
                        if(item[0] == min && item[1] == mid &&
                        item[2] == max)
                            break;
                        triplets.Add([min,mid,max]);
                        break;
                    }                
                }
            }
        }
    }

    return triplets;
}