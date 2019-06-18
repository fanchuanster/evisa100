using System.IO;
using OpenQA.Selenium;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using System.Net;
using EVisa100.DataStructure;
using System.Collections.Generic;
using System;
using OpenQA.Selenium.Interactions;
using EVisa100.Enums;

namespace EVisa100.Automations
{
    class PakistanAutomation : Automation
    {
        void SelectCell(string tableId, string cellText, string cellTag = "td")
        {
            var table = driver.FindElement(By.Id(tableId));
            var cells = table.FindElements(By.TagName(cellTag));

            foreach (var td in cells)
            {
                if (td.Enabled && td.Text.Equals(cellText, StringComparison.CurrentCultureIgnoreCase))
                {
                    td.Click();
                    break;
                }
            }
        }
        void Select(string listId, string itemText, string itemTag = "li")
        {
            driver.FindElement(By.Id(listId)).Click();
            System.Threading.Thread.Sleep(1000);
            var dropdown = driver.FindElement(By.Id($"{listId}_panel"));

            var options = dropdown.FindElements(By.TagName(itemTag));

            if (itemText.StartsWith("#"))
            {
                // whether by index, 0-based.
                var number = itemText.Remove(0, 1);
                int index = -1;
                if (Int32.TryParse(number, out index))
                {
                    // + 1 for Select is the first item.
                    options[index+1].Click();
                }
            }
            else
            {
                foreach (var option in options)
                {
                    if (option.Text.Equals(itemText, StringComparison.CurrentCultureIgnoreCase))
                    {
                        option.Click(); // click the desired option
                        break;
                    }
                }
            }            
        }
        void DropAndSearch(string dropFieldId, string searchText)
        {
            driver.FindElement(By.Id(dropFieldId)).Click();
            System.Threading.Thread.Sleep(1000);

            // appOptionForm:q1_panel
            var dropDiv = driver.FindElement(By.Id($"{dropFieldId}_panel"));

            var filterInput = dropDiv.FindElement(By.TagName(@"input"));
            filterInput.SendKeys(searchText);
            filterInput.SendKeys(OpenQA.Selenium.Keys.Return);
        }
        void SetDate(string fieldId, DateTime date)
        {
            // renewalForm:ArrivalDatePnl
            // renewalForm:leavingDate
            // ui-datepicker-div

            driver.FindElement(By.Id(fieldId)).Click();
            System.Threading.Thread.Sleep(1000);

            var pickerDiv = driver.FindElement(By.Id("ui-datepicker-div"));

            var year = new SelectElement(pickerDiv.FindElement(By.CssSelector(@"#ui-datepicker-div > div > div > select.ui-datepicker-year")));
            year.SelectByText(date.Year.ToString());

            var month = new SelectElement(pickerDiv.FindElement(By.CssSelector(@"#ui-datepicker-div > div > div > select.ui-datepicker-month")));
            month.SelectByValue((date.Month - 1).ToString());
            
            // ui-datepicker-calendar
            var calendar = pickerDiv.FindElement(By.ClassName(@"ui-datepicker-calendar"));
            var tds = calendar.FindElements(By.TagName("td"));
            foreach (var td in tds)
            {
                if (td.Enabled && td.Text.Equals(date.Day.ToString()))
                {
                    td.Click();
                    break;
                }
            }
        }
        protected override void Execute(DataStructure.Application application)
        {
            string url = "https://visa.nadra.gov.pk/tourist-visa/";

            driver.Navigate().GoToUrl(url);

            var pageLoader = driver.FindElement(By.CssSelector(@"body > div.smart-page-loader"));
            while (pageLoader.Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }

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
            System.Threading.Thread.Sleep(1000);
            var agreeCB = driver.FindElement(By.CssSelector(@"#sss\:checkboxId"));
            if (!agreeCB.Selected)
            {
                agreeCB.Click();
            }

            System.Threading.Thread.Sleep(5000);

            var acceptAndContinueBtn = driver.FindElement(By.CssSelector(@"#sss\:j_idt21"));
            acceptAndContinueBtn.Click();

            // Nationality
            DropAndSearch("appOptionForm:q1", "China");

            // 
            driver.FindElement(By.CssSelector(@"#appOptionForm\:submit-renewal")).Click();


            //////////////////////
            // application info
            //////
            Select("renewalForm:visaCat", "Tourist");
            System.Threading.Thread.Sleep(3000);
            Select("renewalForm:visaSubCat", $"#{application.data["visa_sub_cat"]}");
            System.Threading.Thread.Sleep(1000);
            Select("renewalForm:appType", "First Time Application");
            System.Threading.Thread.Sleep(1000);
            Select("renewalForm:visaType", "Single Entry");

            driver.FindElement(By.CssSelector(@"#renewalForm\:visitPurpose")).SendKeys("Tourism");

            //   
            Select("renewalForm:visaDuration", "3");
            Select("renewalForm:visaDurationType", "Month(s)");

            DropAndSearch("renewalForm:cntry", "China");
            System.Threading.Thread.Sleep(3000);
            Select("renewalForm:mission", "Shanghai");

            // No Gov project
            driver.FindElement(By.CssSelector(@"#renewalForm\:cpecP > tbody > tr > td:nth-child(3) > div")).Click();

            Select("renewalForm:entryPort", application.EntryPoint);
            Select("renewalForm:departurePort", application.EntryPoint);

            // renewalForm:travalDate
            // renewalForm:leavingDate
            // ui-datepicker-div
            SetDate("renewalForm:travalDate", application.entry_date);
            SetDate("renewalForm:leavingDate", application.departure_date);

            //////////////
            // passport

            // 
            driver.FindElement(By.CssSelector(@"#renewalForm\:passPassportNo")).SendKeys("E12233307");
            driver.FindElement(By.CssSelector(@"#renewalForm\:passIssueAuthority")).SendKeys(application.Passport.data["authority"] as string);

            Select("renewalForm:passportType", "Ordinary");
            DropAndSearch("renewalForm:passIssuingCountry", "China");

            // renewalForm:passIssueDate
            // renewalForm:passExpiryDate
            SetDate("renewalForm:passIssueDate", application.Passport.IssueDate);
            SetDate("renewalForm:passExpiryDate", application.Passport.ExpiryDate);

            // No other passports.
            SelectCell("renewalForm:j_idt206", "No");
            //driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt206 > tbody > tr > td:nth-child(3) > div")).Click();

            // Next
            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt2246")).Click();

            /////////////////
            // personal info

            // 
            driver.FindElement(By.CssSelector(@"#renewalForm\:surname")).SendKeys(application.Passport.SurName);
            driver.FindElement(By.CssSelector(@"#renewalForm\:givenName")).SendKeys(application.Passport.GivenName);

            SetDate("renewalForm:dobPI", application.Passport.BirthDate);
            driver.FindElement(By.CssSelector(@"#renewalForm\:idMark")).SendKeys(application.Passport.BirthPlace);

            var maritalStatus = (MaritalStatus)Int32.Parse(application.Passport.data["marital_status"].ToString());

            SelectCell("renewalForm:maritalStatus", maritalStatus.ToString());
            SelectCell("renewalForm:gender", (application.Passport.data["sex"].ToString() == "M" ? "Male" : "Female"));
            DropAndSearch("renewalForm:nationality", "China");
            
            driver.FindElement(By.CssSelector(@"#renewalForm\:email")).SendKeys(application.Passport.data["email"].ToString());
            DropAndSearch("renewalForm:mobileCountry", "China");
            driver.FindElement(By.CssSelector(@"#renewalForm\:mobile")).SendKeys(application.Passport.data["phone"] as string);

            driver.FindElement(By.CssSelector(@"#renewalForm\:nav-middle_content > table > tbody > tr:nth-child(1) > td:nth-child(4)")).Click();

            // #renewalForm\:fNam2
            driver.FindElement(By.CssSelector(@"#renewalForm\:fNam2")).SendKeys(application.Passport.FatherName);
            DropAndSearch("renewalForm:fnat", "China");

            // #renewalForm\:mNam2
            driver.FindElement(By.CssSelector(@"#renewalForm\:mNam2")).SendKeys(application.Passport.MotherName);
            DropAndSearch("renewalForm:mnat", "China");

            // Do you have a Spouse ?
            if (true)
            {
                driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt569 > div.ui-chkbox-box.ui-widget.ui-corner-all.ui-state-default")).Click();
                System.Threading.Thread.Sleep(1000);

                // #renewalForm\:sNam2
                driver.FindElement(By.CssSelector(@"#renewalForm\:sNam2")).SendKeys(application.Passport.SpouseName);
                // renewalForm:snat
                DropAndSearch("renewalForm:snat", "China");
                // renewalForm:sbCountry1
                DropAndSearch("renewalForm:sbCountry1", "China");

                SelectCell("renewalForm:sTrav", "No");
            }
            
            // save and continue
            driver.FindElement(By.CssSelector(@"#renewalForm\:nav-middle_content > table > tbody > tr:nth-child(1) > td:nth-child(4)")).Click();

            ////////////
            // finance

            // renewalForm:persCircumstance
            SelectCell("renewalForm:persCircumstance", "Unemployed");

            // save and continue.
            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt2254")).Click();

            // history
            SelectCell("renewalForm:j_idt959", "No");
            SelectCell("renewalForm:j_idt1024", "No");
            SelectCell("renewalForm:j_idt1088", "No");
            SelectCell("renewalForm:j_idt1170", "No");

            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt2254")).Click();

            // Do you intend to visit Azad Jammu and Kashmir during your stay in Pakistan?
            SelectCell("renewalForm:muzMir", "No");
            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt2254")).Click();

            /// documents
            //The following documents are mandatory for your Visa application.
            //1: Letter By Sponsor / Hotel – Letter By Operator(recog.By Dept.Of Tourist Services)
            //2: Passport
            //3: Photograph

            // download documents.
            var passportFile = Constants.OssHost + (application.Passport.data["passport_file"] as string);
            passportFile = passportFile.Replace("\\", "");
            var photoFile = (application.Passport.data["photo_file"] as string);
            photoFile = photoFile.Replace("\\", "");
            var hotelLetter = Constants.OssHost + (application.Passport.data["hotel_letter"] as string);
            hotelLetter = hotelLetter.Replace("\\", "");
            var temp = Path.GetTempPath();
            using (var client = new WebClient())
            {
                client.DownloadFile(passportFile, temp + "passport.jpg");
                client.DownloadFile(photoFile, temp + "photo.jpg");
                client.DownloadFile(hotelLetter, temp + "hotel_letter.jpg");
            }

            Select("renewalForm:docType", "Passport");
            // Choose and upload
            driver.FindElement(By.XPath(@"//*[@id=""renewalForm:uploadFileCom""]/div[1]/span")).Click();
            System.Threading.Thread.Sleep(2000);
            SendKeys.SendWait(temp + "passport.jpg");
            SendKeys.SendWait(@"{Enter}");
            driver.FindElement(By.XPath(@"//*[@id=""renewalForm:uploadFileCom""]/div[1]/button[1]")).Click();


            Select("renewalForm:docType", "Photograph");
            // Choose and upload
            driver.FindElement(By.XPath(@"//*[@id=""renewalForm:uploadFileCom""]/div[1]/span")).Click();
            System.Threading.Thread.Sleep(2000);
            SendKeys.SendWait(temp + "photo.jpg");
            SendKeys.SendWait(@"{Enter}");
            driver.FindElement(By.XPath(@"//*[@id=""renewalForm:uploadFileCom""]/div[1]/button[1]")).Click();

            
            Select("renewalForm:docType", "Letter By Sponsor/Hotel – Letter By Operator (recog. By Dept. Of Tourist Services)");
            // Choose and upload
            driver.FindElement(By.XPath(@"//*[@id=""renewalForm:uploadFileCom""]/div[1]/span")).Click();
            System.Threading.Thread.Sleep(2000);
            SendKeys.SendWait(temp + "hotel_letter.jpg");
            SendKeys.SendWait(@"{Enter}");
            driver.FindElement(By.XPath(@"//*[@id=""renewalForm:uploadFileCom""]/div[1]/button[1]")).Click();

            // save and continue.
            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt2254")).Click();

            // To the best of my knowledge and belief the information given in this application is correct.
            driver.FindElement(By.CssSelector(@"#renewalForm\:reviewDeclr > div.ui-chkbox-box.ui-widget.ui-corner-all.ui-state-default")).Click();

            driver.FindElement(By.CssSelector(@"#renewalForm\:j_idt2254")).Click();
        }
    }
}
