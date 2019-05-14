using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVisa100
{
    static class Utility
    {
        public static List<string> TwelveMonths = new List<string> { "Jan", "Feb", "Mar", "Apr", "Aug", "Sep", "Oct", "Nov", "Dec" };
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

        public static void SelectTableCell(IWebDriver driver, string tableCSS, string cellTag, string expectedText, string expectedClass = "")
        {
            var datepickerForm = driver.FindElement(By.CssSelector(tableCSS));
            var cells = datepickerForm.FindElements(By.TagName(cellTag));

            foreach (var cell in cells)
            {
                if (cell.Text.ToLower().Contains(expectedText.ToLower()))
                {
                    if (string.IsNullOrEmpty(expectedClass) || expectedClass == cell.GetAttribute("class"))
                    {
                        cell.Click();
                        break;
                    }
                }
            }
        }
    }
}
