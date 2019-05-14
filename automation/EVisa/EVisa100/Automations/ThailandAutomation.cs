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
            var entryPoint = new SelectElement(driver.FindElement(By.CssSelector(@"#pd-airport")));
            entryPoint.SelectByText(application.EntryPoint, true);

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

            // birth date input click which to open the datepicker form.
            IWebElement birthdateInput = driver.FindElement(By.XPath(@"//*[@id=""js-datepicker-datebirth""]"));
            birthdateInput.Click();

            Utility.SelectTableCell(driver, @"body > div.datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top > div.datepicker-years > table > tbody > tr > td", "span", application.Passport.BirthDate.Year.ToString());
            Utility.SelectTableCell(driver, @"body > div.datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top > div.datepicker-months > table > tbody > tr > td", "span", Utility.TwelveMonths[application.Passport.BirthDate.Month]);
            Utility.SelectTableCell(driver, @"body > div.datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-left.datepicker-orient-top > div.datepicker-days > table > tbody", "td", application.Passport.BirthDate.Day.ToString(), "day");
            
            var deniedOther = new SelectElement(driver.FindElement(By.CssSelector(@"#element_40")));
            deniedOther.SelectByText((application.data["ever_denied_by_others"] as bool?) == false ? "No" : "Yes");
            // convicted - #element_41
            var convicted = new SelectElement(driver.FindElement(By.CssSelector(@"#element_41")));
            convicted.SelectByText((application.data.ContainsKey("ever_convicted") && (application.data["ever_convicted"] as bool?) == true) ? "Yes" : "No");

            // #submit_primary continue button
            driver.FindElement(By.CssSelector(@"#submit_primary")).Click();

            // passportUploadBtn - #element_43
            var passportUploadBtn = driver.FindElement(By.CssSelector(@"#element_43"));

            var passportFile = Constants.OssHost + (application.Passport.data["passport_file"] as string);
            passportFile = passportFile.Replace("\\", "");
            var photoFile = (application.Passport.data["photo_file"] as string);
            photoFile = photoFile.Replace("\\", "");
            var idFrontFile = Constants.OssHost + (application.Passport.data["id_front_file"] as string);
            idFrontFile = idFrontFile.Replace("\\", "");
            var temp = Path.GetTempPath();
            using (var client = new WebClient())
            {
                client.DownloadFile(passportFile, temp + "passport.jpg");
                client.DownloadFile(photoFile, temp + "photo.jpg");
                client.DownloadFile(idFrontFile, temp + "idfront.jpg");
            }

            passportUploadBtn.SendKeys(temp + "passport.jpg");

            // additional - #element_42
            var additionalfile = driver.FindElement(By.CssSelector(@"#element_42"));
            additionalfile.SendKeys(temp + "idfront.jpg");

            // photo - #element_44
            var photofile = driver.FindElement(By.CssSelector(@"#element_44"));
            photofile.SendKeys(temp + "photo.jpg");

            // agree truth - #element_50_1
            driver.FindElement(By.CssSelector(@"#element_50_1")).Click();

            // submit button - #submit_primary
            driver.FindElement(By.CssSelector(@"#submit_primary")).Click();
            driver.FindElement(By.CssSelector(@"#review_submit")).Click();
        }
    }
}
