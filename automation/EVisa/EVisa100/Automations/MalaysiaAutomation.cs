using System.IO;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using System.Net;
using EVisa100.DataStructure;
using System;

namespace EVisa100.Automations
{
    class MalaysiaAutomation : Automation
    {
        protected override void Execute(Application application)
        {
            string url = "https://www.windowmalaysia.my/evisa/evisa.jsp?alreadyCheckLang=1&lang=zh";

            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.CssSelector("#main-direction > div > div.ev-opt-2")).Click();

            driver.FindElement(By.CssSelector("#txtEmail")).SendKeys("fanchuanster@gmail.com");
            driver.FindElement(By.CssSelector("#txtPassword")).SendKeys("passw0rd");


            do
            {
                Console.WriteLine("Input Captcha...");
                var captcha = Console.ReadLine();
                driver.FindElement(By.CssSelector(@"#answer")).SendKeys(captcha);
                driver.FindElement(By.CssSelector("#btnSubmit")).Click();
            } while (driver.Url.Contains("wrongcaptcha"));

            
        }
    }
}
