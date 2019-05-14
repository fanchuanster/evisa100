using System.IO;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using System.Net;
using EVisa100.DataStructure;
using System.Collections.Generic;

namespace EVisa100.Automations
{
    class ThailandAutomation : Automation
    {
        protected override void Execute(Application application)
        {
            string url = "https://www.evisathailand.com/ft";

            driver.Navigate().GoToUrl(url);

            // Accept.
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath(@"//*[@id=""term_form""]/div/button[1]")).Click();

            var nationalityList = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"pd-nationality\"]")));
            nationalityList.SelectByText("Chinese", true);

            // point of entry
            //var entryPoint = new SelectElement(driver.FindElement(By.CssSelector(@"#pd-airport")));
            //entryPoint.SelectByText(application.EntryPoint, true);

            var salutation = application.Passport.data["sex"].ToString() == "M" ? "Mr" : "Ms";
            var salutationList = new SelectElement(driver.FindElement(By.CssSelector(@"#pd-salutation")));
            salutationList.SelectByText(salutation);

            var surnameInput = driver.FindElement(By.XPath(@"//*[@id=""passengerdetails-form""]/div[2]/ul[2]/li[2]/input"));
            surnameInput.SendKeys(application.Passport.SurName);

            var givennameInput = driver.FindElement(By.XPath(@"//*[@id=""passengerdetails-form""]/div[2]/ul[2]/li[4]/input"));
            givennameInput.SendKeys(application.Passport.GivenName);

            // male or female.
            var genderList = new SelectElement(driver.FindElement(By.XPath(@"//*[@id=""pd-gender""]")));
            var gender = (application.Passport.data["sex"].ToString() == "M") ? "Male" : "Female";
            genderList.SelectByText(gender);

            System.Threading.Thread.Sleep(1000);

            // birth date input click which to open the datepicker form.
            IWebElement birthdateInput = driver.FindElement(By.XPath(@"//*[@id=""js-datepicker-datebirth""]"));
            birthdateInput.Click();

            Utility.SelectTableCell(driver, @"body > div.datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top > div.datepicker-years > table > tbody > tr > td", "span", application.Passport.BirthDate.Year.ToString());
            Utility.SelectTableCell(driver, @"body > div.datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top > div.datepicker-months > table > tbody > tr > td", "span", Utility.TwelveMonths[application.Passport.BirthDate.Month]);
            Utility.SelectTableCell(driver, @"body > div.datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top > div.datepicker-days > table > tbody", "td", application.Passport.BirthDate.Day.ToString(), "day");

            var email = driver.FindElement(By.CssSelector(@"#passengerdetails-form > div.l-form-grid > ul:nth-child(2) > li:nth-child(7) > input[type=text]"));
            email.SendKeys(application.Passport.data["email"] as string);

            var phone = driver.FindElement(By.CssSelector(@"#pd-mobilenum"));
            phone.SendKeys(application.Passport.data["phone"] as string);

            var passport = driver.FindElement(By.CssSelector(@"#passengerdetails-form > div.l-form-grid > ul.l-form-grid__fivecol.l-form-grid__singlelayer > li:nth-child(1) > input[type=text]"));
            passport.SendKeys(application.Passport.passport_no);
        }
    }
}
