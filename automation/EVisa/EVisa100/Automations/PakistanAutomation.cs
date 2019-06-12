using System.IO;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using System.Net;
using EVisa100.DataStructure;
using System.Collections.Generic;
using System;
using OpenQA.Selenium.Interactions;

namespace EVisa100.Automations
{
    class PakistanAutomation : Automation
    {
        void Select(string listId, string itemText, string itemTag = "li")
        {
            driver.FindElement(By.Id(listId)).Click();
            var dropdown = driver.FindElement(By.Id($"{listId}_panel"));

            var options = dropdown.FindElements(By.TagName(itemTag));
            foreach (var option in options)
            {
                if (option.Text.Equals(itemText, StringComparison.CurrentCultureIgnoreCase))
                {
                    option.Click(); // click the desired option
                    break;
                }
            }
        }
        void SetDate(string fieldId, DateTime date)
        {
            // renewalForm:ArrivalDatePnl
            // renewalForm:leavingDate
            // ui-datepicker-div

            driver.FindElement(By.Id(fieldId)).Click();
            var picker = driver.FindElement(By.Id("ui-datepicker-div"));

            var month = new SelectElement(picker.FindElement(By.CssSelector(@"#ui-datepicker-div > div > div > select.ui-datepicker-month")));
            month.SelectByValue((date.Month - 1).ToString());

            // 
            var year = new SelectElement(picker.FindElement(By.CssSelector(@"#ui-datepicker-div > div > div > select.ui-datepicker-year")));
            year.SelectByText(date.Year.ToString());
        }
        protected override void Execute(Application application)
        {
            string url = "https://visa.nadra.gov.pk/tourist-visa/";

            driver.Navigate().GoToUrl(url);

            System.Threading.Thread.Sleep(28000);

            var applyButton = driver.FindElement(By.CssSelector(@"#content > section.section.full-width-bg.gray-bg > div > div > div > div > div > div > div:nth-child(1) > div.wpb_column.vc_column_container.vc_col-sm-2 > div > div > div"));
            applyButton.Click();

            // Login.
            var tologinButton = driver.FindElement(By.XPath(@"//*[@id=""j_idt12""]/div/div/a[2]"));
            tologinButton.Click();
            driver.FindElement(By.CssSelector(@"#login\:usrnam")).SendKeys("fanchuanster@gmail.com");
            driver.FindElement(By.CssSelector(@"#login\:pass")).SendKeys("Passw0^d");

            var currentUrl = driver.Url;
            var nextUrl = currentUrl;
            while (nextUrl == currentUrl)
            {
                Console.WriteLine("Input Captcha...");
                var captcha = Console.ReadLine();
                driver.FindElement(By.CssSelector(@"#login\:captchaCodeTextBox")).SendKeys(captcha);
                var loginButton = driver.FindElement(By.CssSelector(@"#login\:submit-login"));
                loginButton.Click();

                nextUrl = driver.Url;
            }

            var agreeCB = driver.FindElement(By.CssSelector(@"#sss\:checkboxId"));
            if (!agreeCB.Selected)
            {
                agreeCB.Click();
            }

            System.Threading.Thread.Sleep(5000);

            var acceptAndContinueBtn = driver.FindElement(By.CssSelector(@"#sss\:j_idt21"));
            acceptAndContinueBtn.Click();

            // Nationality
            driver.FindElement(By.CssSelector(@"#appOptionForm\:q1_label")).Click();
            var filterInput = driver.FindElement(By.CssSelector(@"#appOptionForm\:q1_filter"));
            filterInput.SendKeys("China");
            filterInput.SendKeys(Keys.Return);

            // 
            driver.FindElement(By.CssSelector(@"#appOptionForm\:submit-renewal")).Click();


            //////////////////////
            // application info
            //////
            Select("renewalForm:visaCat", "Tourist");
            Select("renewalForm:visaSubCat", "Individual (less Than 3 Months)");
            Select("renewalForm:appType", "First Time Application");
            Select("renewalForm:visaType", "Single Entry");
            Select("renewalForm:visaCat", "Tourist");

            driver.FindElement(By.CssSelector(@"#renewalForm\:visitPurpose")).SendKeys("Tourism");

            //   
            Select("renewalForm:visaDuration", "1");
            Select("renewalForm:visaDurationType", "Month(s)");

            Select("renewalForm:cntry", "China", "td");

            // renewalForm:
            Select("renewalForm:mission", "Shanghai");

            // No Gov project
            driver.FindElement(By.CssSelector(@"#renewalForm\:cpecP > tbody > tr > td:nth-child(3) > div")).Click();

            Select("renewalForm:entryPort", "Islamabad Airport");
            Select("renewalForm:departurePort", "Islamabad Airport");

            // renewalForm:travalDate
            // renewalForm:leavingDate
            // ui-datepicker-div
            SetDate("renewalForm:travalDate", new DateTime(2019, 10, 12));
            SetDate("renewalForm:leavingDate", new DateTime(2019, 10, 19));



            //////////////
            // passport

            // 
            driver.FindElement(By.CssSelector(@"#renewalForm\:passPassportNo")).SendKeys("E12233309");
            driver.FindElement(By.CssSelector(@"#renewalForm\:passIssueAuthority")).SendKeys("MPS");

            Select("renewalForm:passportType", "Ordinary");
            Select("renewalForm:passIssuingCountry", "China", "td");

            // renewalForm:passIssueDate
            // renewalForm:passExpiryDate
            SetDate("renewalForm:passIssueDate", new DateTime(2009, 10, 19));
            SetDate("renewalForm:passExpiryDate", new DateTime(2029, 10, 19));

            // No other passports.
            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt206 > tbody > tr > td:nth-child(3) > div")).Click();

            // Next
            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt2246")).Click();
        }
    }
}
