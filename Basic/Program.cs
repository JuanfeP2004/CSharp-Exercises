// See https://aka.ms/new-console-template for more information


try
{
    Console.WriteLine("Basic Problems");

    Console.WriteLine("Problem #1: Find the longest substring");
    string s = "pwwkew";
    int substring = LengthOfLongestSubstring(s);
    Console.WriteLine($"The longest substring is {substring} caracters long");

    Console.WriteLine("Problem #2: Find the longest palindromic substring");
    string t = "cbbd";
    string substring_2 = LongestPalindrome(t);
    Console.WriteLine($"The longest palindromic substring is {substring_2}");
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

/*
    Problem #2: Lenght of the longest palindromic string
    (https://leetcode.com/problems/longest-palindromic-substring/)
    Given a string s, return the longest palindromic substring in s.
*/
string LongestPalindrome(string s)
{
    if(s.Length < 1 || s.Length > 1000)
        throw new Exception("string is too long or too short");
    if(s.Length == 1)
        return s;

    string sub = "";
    string reverse = "";
    string return_s = Char.ToString(s[0]); 

    for (int i = 2; i <= s.Length; i++)
    {
        for(int j = 0; j < s.Length - i + 1; j++)
        {          
            sub = s.Substring(j, i);
            reverse = "";
            for(int k = sub.Length-1; k>=0; k--)
            {
                reverse += sub[k];
            }

            if (sub.Equals(reverse) && sub.Length > return_s.Length)
            {
                return_s = sub;
            }
        }
    }

    return return_s;
}
