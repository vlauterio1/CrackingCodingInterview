using System;
using System.Collections.Generic;
using System.Text;

namespace _1_5_StringCompression
{
    class Program
    {
    	/// Assumptions
    	///		- ASCII chars only
    	///		- Case sentitive
    	///		- Supporting long strings

        static void Main(string[] args)
        {
        	Console.WriteLine(("abbcccdddd".Compress() == "a1b2c3d4") == true);
        	Console.WriteLine(("a".Compress() == "a") == true);
        	Console.WriteLine(("aabb".Compress() == "a2b2") == true);
        	Console.WriteLine(("abbbcccbbccccccccddddaabcd".Compress() == "a1b3c3b2c8d4a2b1c1d1") == true);
            Console.WriteLine(("aA".Compress() == "aA") == true);
        }
    }

    static class ExtensionMethods
    {
    	public static string Compress(this string  s)
    	{
            IDictionary<int, int> duplicates = new SortedDictionary<int, int>();
    		int pos = -1;

    		for (int i = 0; i < s.Length; i++)
    		{
    			if (pos == -1 || s[pos] != s[i])
    			{
                    duplicates.Add(i, 1);

    				pos = i;
    			}
    			else
    			{
    				duplicates[pos]++;
    			}
    		}

    		StringBuilder sb = new StringBuilder();

    		foreach (KeyValuePair<int, int> d in duplicates)
    		{
    			sb.Append(s[d.Key] + d.Value.ToString());
    		}

    		string s2 = sb.ToString();

    		return s.Length < s2.Length ? s : s2;
    	}
    }
}
