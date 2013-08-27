using System;

namespace _1_8_StringRotation
{
	/// Assumptions
	///		- Case sensitive

    class Program
    {
        static void Main(string[] args)
        {
        	Console.WriteLine("waterbottle".IsRotation("erbottlewat") == true);
        	Console.WriteLine("waterbottle".ToCharArray().IsRotation2("erbottlewat".ToCharArray()) == true);
        	Console.WriteLine("watrbottle".ToCharArray().IsRotation2("erbottlewat".ToCharArray()) == false);
        	Console.WriteLine("aterbottlew".ToCharArray().IsRotation2("erbottlewat".ToCharArray()) == true);
        	Console.WriteLine("abcabcabc".ToCharArray().IsRotation2("cabcabcab".ToCharArray()) == true);
        	Console.WriteLine("abacbcabc".ToCharArray().IsRotation2("cabcabcab".ToCharArray()) == false);
        }
    }

    static class ExtensionMethods
    {
    	public static bool IsRotation(this string s, string s2)
    	{
    		return (s + s).Contains(s2);
    	}

    	public static bool IsRotation2(this char[] s, char[] s2)
    	{
    		int length = s.Length;

    		if (length != s2.Length)
    		{
    			return false;
    		}

    		char[] d = new char[length * 2];

    		for (int i = 0; i < length; i++)
    		{
    			d[i] = d[i + length] = s[i]; 
    		}

    	    return d.IsSubString(s2);
    	}

        public static bool IsSubString(this char[] s, char[] s2)
        {
            string x = new String(s);
            string x2 = new String(s2);

            return x.Contains(x2);
        }
    }
}
