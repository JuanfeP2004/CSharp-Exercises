// See https://aka.ms/new-console-template for more information


try
{    
    Console.WriteLine("Data Structures Problems");

    Console.WriteLine("Problem #1");
    LinkedList<int> firstNumber = new LinkedList<int>([2]);
    LinkedList<int> secondNumber = new LinkedList<int>([2,4]);

    LinkedList<int> result = AddTwoNumbers(firstNumber, secondNumber);
    foreach (int digit in result) Console.Write($"{digit}");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

/*Problem #1: Sum of two numbers https://leetcode.com/problems/two-sum/description/
You are given two non-empty linked lists representing two non-negative 
integers. The digits are stored in reverse order, and each of their nodes 
contains a single digit. Add the two numbers and return the sum as a linked 
list.
You may assume the two numbers do not contain any leading zero, except the 
number 0 itself.*/
LinkedList<int> AddTwoNumbers(LinkedList<int> a, LinkedList<int> b)
{
    if(a.Count < 1 || a.Count > 100)
        throw new Exception("A list is very long or empty");
    if(b.Count < 1 || b.Count > 100)
        throw new Exception("B list is very long or empty");
    
    foreach (int i in a)
        if (i < 0 || i > 9)
            throw new Exception("Node invalid in A");
    foreach (int i in b)
        if (i < 0 || i > 9)
            throw new Exception("Node invalid in B");

    int lengthA = a.Count -1;
    int lengthB = b.Count -1;
    int numberA = 0;
    int numberB = 0;

    foreach(int digi in a)
    {
        numberA += (int)(digi * Math.Pow(10, lengthA));
        lengthA--;
    }
    foreach(int digi in b)
    {
        numberB += (int)(digi * Math.Pow(10, lengthB));
        lengthB--;
    }

    int numberResult = numberA + numberB;
    LinkedList<int> result = new LinkedList<int>([]);
    int digit = 0;

    while(numberResult > 0)
    {
        digit = numberResult % 10;
        numberResult /= 10;
        result.AddFirst(digit);
    }

    return result;
}