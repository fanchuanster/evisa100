using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVisa100
{
    static class Utility
    {
        /// <summary>
        /// Un-quotes a quoted string
        /// </summary>
        /// <param name="InputTxt">Text string need to be escape with slashes</param>
        public static string StripSlashes(this string InputTxt)
        {
            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent

            string Result = InputTxt;

            try
            {
                Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");
            }
            catch (Exception Ex)
            {
                // handle any exception here
                Console.WriteLine(Ex.Message);
            }

            return Result;
        }
    }
}
