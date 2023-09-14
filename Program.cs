using System;
using System.Collections.Generic;
using System.Text;
/*
Given a string path, which is an absolute path (starting with a slash '/') to a file or directory in a Unix-style file system,
convert it to the simplified canonical path.

In a Unix-style file system, a period '.' refers to the current directory, 
a double period '..'refers to the directory up a level, 
and any multiple consecutive slashes (i.e. '//') are treated as a single slash '/'. 
For this problem, any other format of periods such as '...' are treated as file/directory names.

The canonical path should have the following format:

The path starts with a single slash '/'.
Any two directories are separated by a single slash '/'.
The path does not end with a trailing '/'.
The path only contains the directories on the path from the root directory to the target file or directory (i.e., no period '.' or double period '..')
Return the simplified canonical path.
*/

namespace Canonical_Path
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Absolute path");

            string absolutePath = Console.ReadLine();

            convertAbsoluteToCanonical(absolutePath);
        }

        /*
* Split the path into parts using '/' as the delimiter.
Iterate through the parts and push the parts into a stack.
If the part is ".." then pop the stack.
If the part is "." or "" then do nothing.
If the part is anything else then push it into the stack.
Iterate through the stack and build the result string.
Return the result string.
         */
        public static string convertAbsoluteToCanonical(string absolutepath)
        {
            var stack = new Stack<string>();
            var parts = absolutepath.Split('/');

            foreach (var part in parts)
            {
                if(part == "..")
                {
                    if(stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if(part != "." && part != "")
                {
                    stack.Push(part);
                }
            }
            var result = new StringBuilder();
            while(stack.Count > 0)
            {
                result.Insert(0, stack.Pop());
                result.Insert(0, "/");
            }
            return result.Length == 0 ? "/" : result.ToString();
        }
    }
}
