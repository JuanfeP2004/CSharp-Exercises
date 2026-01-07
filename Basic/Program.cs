// See https://aka.ms/new-console-template for more information


try
{
    Console.WriteLine("Basic Problems");

    Console.WriteLine("Problem #1: Find the longest substring");
    string s = "pwwkew";
    int substring = LengthOfLongestSubstring(s);
    Console.WriteLine($"The longest substring is {substring} caracters long");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}


/*
Problem #1: Find the longest substring 
https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
Given a string s, find the length of the longest substring without 
duplicate characters.
*/

int LengthOfLongestSubstring(string s)
{
    if(s.Length < 0 || s.Length > 10000)
        throw new Exception("String is too long or has negative length");
    else if(s.Length == 0)
        return 0;

    int longest = 1;
    int current = 1;
    bool uniqueValue = true;
    List<char> values = new List<char>();

    //Travel around the string
    for (int i=0; i<s.Length; i++)
    {
        current = 1;
        uniqueValue = true;
        values.Clear();
        values.Add(s[i]);
        for(int j = i + 1; j < s.Length; j++)
        {            
            foreach(char k in values)
            {
                if (k == s[j])
                {
                    uniqueValue = false;
                    break;
                }
            }
            if (uniqueValue)
            {
                values.Add(s[j]);
                current++;
            }
            else
            {
                if(current > longest) longest = current;
                break;
            }

            if (j == s.Length - 1)
            {
                if(current > longest) longest = current;
                return longest;
            }
        }
    }

    return longest;
}
