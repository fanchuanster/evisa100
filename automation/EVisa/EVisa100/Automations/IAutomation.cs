using EVisa100.DataStructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace EVisa100.Automations
{
    interface IAutomation
    {
        bool Run(Application application);
    }

    public abstract class Automation : IAutomation
    {
        public bool Run(Application application)
        {
            try
            {
                PreExecute();

                Execute(application);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        protected abstract void Execute(Application application);

        protected IWebDriver driver;
        virtual protected void PreExecute()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver("./", options, TimeSpan.FromMinutes(30));
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            }
        }
    }
}
