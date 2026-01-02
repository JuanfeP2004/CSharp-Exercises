// See https://aka.ms/new-console-template for more information

try
{    
    Console.WriteLine("Arrays problems");

    Console.WriteLine("Problem #1");
    int[] numbers = [3,6];
    int tarjet = 9;
    int[] result = TwoSum(numbers, tarjet);
    foreach (int item in result) Console.Write($"{item} ");
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

