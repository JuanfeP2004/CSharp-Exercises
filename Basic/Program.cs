// See https://aka.ms/new-console-template for more information


using System.ComponentModel;

try
{
    Console.WriteLine("Basic Problems");

    Console.WriteLine("Problem #1: Find the longest substring");
    string example1 = "pwwkew";
    int substring = LengthOfLongestSubstring(example1);
    Console.WriteLine($"The longest substring is {substring} caracters long");

    Console.WriteLine("Problem #2: Find the longest palindromic substring");
    string example2 = "cbbd";
    string substring_2 = LongestPalindrome(example2);
    Console.WriteLine($"The longest palindromic substring is {substring_2}");

    Console.WriteLine("Problem #3: Zigzag conversion");
    string example3 = "PAYPAL";
    string result3 = ZigzagConvert(example3, 3);
    Console.WriteLine($"The zigzag string is read: {result3}");

    Console.WriteLine("Problem #4: Integer reversion");
    int example4 = 124;
    int result4 = ReverseInteger(example4);
    Console.WriteLine($"The reverse is: {result4}");

    Console.WriteLine("Problem #5: Atoi");
    string example5 = "   +45b6";
    int result5 = MyAtoi(example5);
    Console.WriteLine($"The integer is: {result5}");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}


/*
    Problem #1: Find the longest substring 
    (https://leetcode.com/problems/longest-substring-without-repeating-characters/description/)
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

/*
    Problem #3: Zigzag conversion
    (https://leetcode.com/problems/zigzag-conversion/description/)
*/
string ZigzagConvert(string s, int numRows) {
    
    if(s.Length < 1 || s.Length > 1000)
        throw new Exception("String is too long or too short");
    if(numRows < 1 || numRows > 1000)
        throw new Exception("Number of rows is too long or too short");
    if(numRows > s.Length)
        throw new Exception("Number of rows is greater than the string");

    string[] rows = new string[numRows];
    int row = 0;

    if(numRows == 1)
        return s;
    else if(numRows == 2)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if(i%2 != 0)
                rows[1] += s[i];
            else
                rows[0] += s[i]; 
        }
    }
    else
    {

        for(int i = 0; i < s.Length; i++)
        {
            row = i % (2*numRows - 2);

            if(row < numRows)
            {
                rows[row] += s[i];
            }
            else
            {
                row = 2*numRows - (i % (numRows + (numRows - 2))) - 2;
                for(int j = 0; j < rows.Length; j++)
                {
                    if (j == row)
                    {
                        rows[row] += s[i];
                    }
                    else
                    {
                        rows[j] += " ";
                    }
                }
            }
        }
    }

    string zigzagString = "";

    foreach(string t in rows)
    {
        foreach(char c in t)
        {
            if(c != ' ')
                zigzagString += c;
        }
    }

    return zigzagString;
}

/*
    Problem #4: Reverse integer
    (https://leetcode.com/problems/reverse-integer/)
    Given a signed 32-bit integer x, return x with its digits reversed. 
    If reversing x causes the value to go outside the signed 32-bit integer 
    range [-231, 231 - 1], then return 0
*/
int ReverseInteger(int x)
{
    string integer = x.ToString();

    bool firstDigit = false;
    bool negative = false;
    string result = "";

    if(x < 0)
    {
        negative = true;
        integer = integer.Split('-')[1];
    }

    for(int i = integer.Length - 1; i >= 0; i--)
    {
        if(integer[i] == '0' && !firstDigit)
            continue;
        else
        {
            if(!firstDigit) firstDigit = true;
            result += integer[i];
        }       
    }

    if (negative)
        return int.Parse($"-{result}");
    else
        return int.Parse(result);
}

/*
    Problem #5: Atoi
    (https://leetcode.com/problems/string-to-integer-atoi/)
    Implement the myAtoi(string s) function, which converts a string to a 
    32-bit signed integer.
*/
int MyAtoi(string s)
{
    if(s.Length < 1 || s.Length > 1000)
        throw new Exception("The string is too short or too long");

    bool firstDigit = false;
    bool negative = false;
    bool leadingZero = false;
    int digits = 0;
    int offset = 0;

    for (int i = 0; i < s.Length; i++)
    {
        //WhiteSpace
        if(s[i] == ' ')
            offset++;
        //No integer
        else if(!firstDigit && s[i] != '-' && s[i] != '+' && (s[i] < 48 || s[i] > 57))
            return 0;
        //Negative
        else if(!firstDigit && s[i] == '-' && !leadingZero) {
            negative = true;
            offset++;
        }
        //Positive
        else if (!firstDigit && s[i] == '+' && !leadingZero)
            offset++;
        //Letter before first digit
        else if((s[i] < 48 || s[i] > 57) && !firstDigit)
            return 0;
        //Finds a letter
        else if (s[i] < 48 || s[i] > 57)
            break;
        //Leading 0
        else if(s[i] == '0' && !firstDigit) {
            leadingZero = true;
            offset++;
        }
        //First digit
        else if(s[i] >= 49 && s[i] <= 57 && !firstDigit)
        {
            firstDigit = true;
            digits++;
        }
        //Increment
        else if(s[i] >= 48 && s[i] <= 57)
            digits++;  
    }

    int integer = 0;
    for (int i = 0; i < digits; i++)
    {
        integer += (s[offset + i]-48) * (int)Math.Pow(10, digits - i - 1);
    }
    //The language controls the overflow :) 

    if(negative)
        return -integer;
    else
        return integer;
}