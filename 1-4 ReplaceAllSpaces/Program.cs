using System;
using System.Text.RegularExpressions;

namespace _1_4_ReplaceAllSpaces
{
	///	Assumptions
	///		- Removing left tabs/spaces
	///		- Removing tabs

    class Program
    {
        static void Main(string[] args)
        {
        	Console.WriteLine(Replace("This is a string".ToCharArray()));
        	Console.WriteLine(Replace("  This is a string".ToCharArray()));
        	Console.WriteLine(Replace("This is a string  ".ToCharArray()));
        	Console.WriteLine(Replace("	This is a string".ToCharArray()));
        	Console.WriteLine(Replace("This is a string	".ToCharArray()));
        }

    	static char[] Replace(char[] s)
    	{
    		int size = 0;
    		bool isRemovable = true;

    		for (int i = s.Length - 1; i >= 0; i--)
    		{
    			if (s[i] == ' ' || s[i] == '\t')
    			{
    				if (isRemovable)
    				{
    					s[i] = '\0';
    				}
    				else 
    				{
    					size+=3;
    				}
    			}
    			else
    			{
    				isRemovable = false;
    				
    				size++;
    			}
    		}

    		char[] newString = new char[size + 1];
    		bool isIgnored = true;
    		int pos = 0;

    		for (int i = 0; i < s.Length - 1; i++)
    		{
    			if (s[i] == ' ' || s[i] == '\t')
    			{
    				if (isIgnored)
    				{
    					continue;
    				}
    				else
    				{
    					newString[pos++] = '%';
    					newString[pos++] = '2';
    					newString[pos++] = '0';
    				}
    			}
    			else
    			{
    				isIgnored = false;

    				newString[pos++] = s[i];
    			}
    		}

    		return newString;
    	}
    }
}
