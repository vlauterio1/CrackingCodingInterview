using System;
using System.Collections.Generic;

namespace _1_3_StringPermutation
{
	/// Assumptions
	///		- Blank spaces are significatives 
	/// 	- It's case sensitive
	/// 	- No MaxLength

    class Program
    {
        static void Main(string[] args)
        {
        	Console.WriteLine("Dog".IsPermutation("goD"));
        	Console.WriteLine("Dog".IsPermutation(" goD"));
        	Console.WriteLine("Dog".IsPermutation("goD "));
        	Console.WriteLine("Dog".IsPermutation("go D"));
        	Console.WriteLine("Dog".IsPermutation("god"));
        	Console.WriteLine("Dog".IsPermutation("dog"));
        }
    }

    static class ExtensionMethods
    {
    	public static bool IsPermutation(this string s, string s2)
    	{
    		if (s.Length != s2.Length)
    		{
    			return false;
    		}

    		IDictionary<char, int> uniqueChars = new Dictionary<char, int>();

    		for (int i = 0; i < s.Length; i++)
    		{
    			uniqueChars[s[i]] = uniqueChars.ContainsKey(s[i]) ? uniqueChars[s[i]]++ : 1;
    		}

    		for (int i = 0; i < s2.Length; i++)
    		{
    			if (!uniqueChars.ContainsKey(s2[i]))
    			{
    				return false;
    			}

    			if (--uniqueChars[s2[i]] < 0)
    			{
    				return false;
    			}
    		}

    		return true;
    	}
    }
}
