using System;
using System.Linq;

namespace _1_1_AllUniqueChars
{
    /// Assumptions
    ///		- ASCII chars only
    ///		- Case sensitive

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("12345".ToCharArray().HasUniqueChars());
            Console.WriteLine("12345".ToCharArray().HasUniqueChars2());
            Console.WriteLine("Has duplicates".ToCharArray().HasUniqueChars2());
            Console.WriteLine("Hh".ToCharArray().HasUniqueChars2());
        }
    }

    static class ExtensionMethods
    {
    	public static bool HasUniqueChars(this char[] s)
    	{
    		return s.Distinct().Count() == s.Length;
    	}

    	public static bool HasUniqueChars2(this char[] s)
    	{
    		bool[] uniqueChars = new bool[255];

    		for (int i = 0; i < s.Length; i++)
			{
				int ix = (int)s[i];

				if (uniqueChars[ix])
				{
					return false;
				}

				uniqueChars[ix] = true;
			}

    		return true;
    	}
    }
}
