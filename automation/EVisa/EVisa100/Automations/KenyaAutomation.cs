using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using EVisa100.DataStructure;

namespace EVisa100.Automations
{
    class KenyaAutomation : IAutomation
    {
        void Execute(Application appliocation)
        {
            const string initPage = "https://accounts.ecitizen.go.ke/login";

            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                driver.Navigate().GoToUrl(initPage);

                driver.FindElement(By.Id("auth_username")).SendKeys("fanchuanster@gmail.com");

                var pwd = driver.FindElement(By.Id("auth_pwd"));
                pwd.SendKeys("passw0rd");
                pwd.Submit();
                
                IWebElement getServiceBtn = driver.FindElement(By.CssSelector("#bloglist > div:nth-child(2) > div > div.panel-heading > div.pull-right.text-left"));
                wait.Until(d => getServiceBtn.Displayed && getServiceBtn.Enabled);
                System.Threading.Thread.Sleep(2000);
                getServiceBtn.Click();

                driver.FindElement(By.LinkText("Make Applicaiton")).Click();

                // Expand kenya visa list.
                driver.FindElement(By.XPath(@"//*[@id=""accordion-test-2""]/div/div[1]/h4/a")).Click();

                driver.FindElement(By.LinkText("1. Apply for a Single Entry Visa")).Click();

                driver.FindElement(By.LinkText("Apply Now")).Click();

                var drpWhereApplicatio = new SelectElement(driver.FindElement(By.XPath(@"//*[@id=""element_2""]")));
                drpWhereApplicatio.SelectByText("China");

                var drpForWhom = new SelectElement(driver.FindElement(By.XPath(@"//*[@id=""element_54""]")));
                drpForWhom.SelectByText("Agent");

                var surnameInput = driver.FindElement(By.XPath(@"//*[@id=""element_4""]"));
                //surnameInput.SendKeys(application.Passport.SurName);
                surnameInput.SendKeys("Dong");

                var givennameInput = driver.FindElement(By.XPath(@"//*[@id=""element_5""]"));
                //givennameInput.SendKeys(application.Passport.GivenName);
                givennameInput.SendKeys("Wen");

                // male or female.
                var radios = driver.FindElements(By.XPath(@"//input[@type=""radio""]"));
                if (radios.Count == 2)
                {
                    radios[0].Click();
                }

                var mm = driver.FindElement(By.CssSelector(@"#element_8_1"));
                mm.SendKeys("01");

                var dd = driver.FindElement(By.CssSelector(@"#element_8_2"));
                dd.Clear();
                dd.SendKeys("25");

                var yyyy = driver.FindElement(By.CssSelector(@"#element_8_3"));
                yyyy.Clear();
                yyyy.SendKeys("1984");


                var birthplace = driver.FindElement(By.CssSelector(@"#element_9"));
                birthplace.SendKeys("HUBEI");

                var drpBirthCountry = new SelectElement(driver.FindElement(By.CssSelector(@"#element_13")));
                drpBirthCountry.SelectByText("China");

                var occupation = driver.FindElement(By.CssSelector(@"#element_11"));
                occupation.SendKeys("Software Engineer");

                var fatherName = driver.FindElement(By.CssSelector(@"#element_7"));
                fatherName.SendKeys("DONG, SHENFA");

                var motherName = driver.FindElement(By.CssSelector(@"#element_55"));
                motherName.SendKeys("CHEN, YUEYING");

                var continueBtn = driver.FindElement(By.CssSelector(@"#submit_primary"));
                continueBtn.Click();

                // #element_1 - nationality
                var drpNationality = new SelectElement(driver.FindElement(By.CssSelector(@"#element_1")));
                drpNationality.SelectByText("China", true);

                // #element_14 - residence
                var drpResidence = new SelectElement(driver.FindElement(By.CssSelector(@"#element_14")));
                drpResidence.SelectByText("China");


                // #element_15 - physical address in the residence country.
                var address = driver.FindElement(By.CssSelector(@"#element_15"));
                address.SendKeys("Room 101, Building 67, #399 Nanliu Rd");

                // #element_16 - phone number in residence country
                var phoneNumber = driver.FindElement(By.CssSelector(@"#element_16"));
                phoneNumber.SendKeys("13641841111");

                // #element_57 - city
                var city = driver.FindElement(By.CssSelector(@"#element_57"));
                city.SendKeys("SHANGHAI");
                // #element_17 - email
                var email = driver.FindElement(By.CssSelector(@"#element_17"));
                email.SendKeys("fanchuanster@163.com");

                // #submit_primary continue button
                continueBtn = driver.FindElement(By.CssSelector(@"#submit_primary"));
                continueBtn.Click();

                // #element_51 - passport number
                var passport = driver.FindElement(By.CssSelector(@"#element_51"));
                passport.SendKeys("E11111111");
                // #element_20 - place of issue
                var issuePlace = driver.FindElement(By.CssSelector(@"#element_20"));
                issuePlace.SendKeys("SHANGHAI");
                // issue time: #element_21_1 - mm; #element_21_2 - dd; #element_21_3 - yyyy
                var issueMM = driver.FindElement(By.CssSelector(@"#element_21_1"));
                issueMM.SendKeys("02");
                var issueDD = driver.FindElement(By.CssSelector(@"#element_21_2"));
                issueDD.SendKeys("07");
                var issueYYYY = driver.FindElement(By.CssSelector(@"#element_21_3"));
                issueYYYY.SendKeys("2014");
                // expiry date: ##element_22_1 - mm; ##element_22_2 - dd; #element_22_3 - yyyy
                var expiryMM = driver.FindElement(By.CssSelector(@"#element_22_1"));
                expiryMM.SendKeys("02");
                var expiryDD = driver.FindElement(By.CssSelector(@"#element_22_2"));
                expiryDD.SendKeys("06");
                var expiryYYYY = driver.FindElement(By.CssSelector(@"#element_22_3"));
                expiryYYYY.SendKeys("2024");
                // issued by - #element_23
                var issuedby = driver.FindElement(By.CssSelector(@"#element_23"));
                issuedby.SendKeys("MPS Exit & Entry Administration");

                // #submit_primary continue button
                continueBtn = driver.FindElement(By.CssSelector(@"#submit_primary"));
                continueBtn.Click();

                // reason travel - #element_65
                var reasontravel = new SelectElement(driver.FindElement(By.CssSelector(@"#element_65")));
                reasontravel.SelectByText("Tourism");
                // entry date: #element_27_1 - mm; #element_27_2 - dd; #element_27_3 - yyyy
                var entryMM = driver.FindElement(By.CssSelector(@"#element_27_1"));
                entryMM.SendKeys("01");
                var entryDD = driver.FindElement(By.CssSelector(@"#element_27_2"));
                entryDD.SendKeys("28");
                var entryYYYY = driver.FindElement(By.CssSelector(@"#element_27_3"));
                entryYYYY.SendKeys("2019");

                // departure data: #element_28_1 - mm; #element_28_2 - dd; #element_28_3 - yyyy
                var departureMM = driver.FindElement(By.CssSelector(@"#element_28_1"));
                departureMM.SendKeys("02");
                var departureDD = driver.FindElement(By.CssSelector(@"#element_28_2"));
                departureDD.SendKeys("11");
                var departureYYYY = driver.FindElement(By.CssSelector(@"#element_28_3"));
                departureYYYY.SendKeys("2019");
                // contact there #element_29 - address; #element_31 - email
                var contactAddress = driver.FindElement(By.CssSelector(@"#element_29"));
                contactAddress.SendKeys("None");
                var contactEmail = driver.FindElement(By.CssSelector(@"#element_31"));
                contactEmail.Clear();
                contactEmail.SendKeys("None@none.com");
                // #element_52 - arriving by
                var arrivingby = new SelectElement(driver.FindElement(By.CssSelector(@"#element_52")));
                arrivingby.SelectByText("Air");

                // point of entry - #element_46
                var entryPoint = new SelectElement(driver.FindElement(By.CssSelector(@"#element_46")));
                entryPoint.SelectByText("Jomo", true);

                // #submit_primary continue button
                continueBtn = driver.FindElement(By.CssSelector(@"#submit_primary"));
                continueBtn.Click();

                // visited other country in last 3 month - #element_25
                driver.FindElement(By.CssSelector(@"#element_25")).SendKeys("None");
                // previous visits to kenya - #element_33
                driver.FindElement(By.CssSelector(@"#element_33")).SendKeys("None");
                // will return yes or no - #element_35
                var willReturn = new SelectElement(driver.FindElement(By.CssSelector(@"#element_35")));
                willReturn.SelectByText("Yes");
                // ever denied by Kenya
                var deniedKy = new SelectElement(driver.FindElement(By.CssSelector(@"#element_36")));
                deniedKy.SelectByText("No");
                // ever denied by other - #element_40
                var deniedOther = new SelectElement(driver.FindElement(By.CssSelector(@"#element_40")));
                deniedOther.SelectByText("No");
                // convicted - #element_41
                var convicted = new SelectElement(driver.FindElement(By.CssSelector(@"#element_41")));
                convicted.SelectByText("No");

                // #submit_primary continue button
                continueBtn = driver.FindElement(By.CssSelector(@"#submit_primary"));
                continueBtn.Click();

                // passportUploadBtn - #element_43
                var passportUploadBtn = driver.FindElement(By.CssSelector(@"#element_43"));
                passportUploadBtn.SendKeys(@"C:\Users\donwen.CORPDOM\Pictures\Saved Pictures\IMG_20181204_195050.jpg");

                // additional - #element_42
                var additionalfile = driver.FindElement(By.CssSelector(@"#element_42"));
                additionalfile.SendKeys(@"C:\Users\donwen.CORPDOM\Pictures\Saved Pictures\IMG_20181204_195050.jpg");

                // photo - #element_44
                var photofile = driver.FindElement(By.CssSelector(@"#element_44"));
                photofile.SendKeys(@"C:\Users\donwen.CORPDOM\Pictures\Saved Pictures\IMG_20181204_195050.jpg");

                // agree truth - #element_50_1
                driver.FindElement(By.CssSelector(@"#element_50_1")).Click();

                // submit button - #submit_primary
                driver.FindElement(By.CssSelector(@"#submit_primary")).Click();
            }

        }

        bool IAutomation.Run(Application application)
        {
            try
            {
                Execute(application);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
