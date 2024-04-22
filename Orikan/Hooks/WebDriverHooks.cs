using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace OrikanUIAutomationTests.Hooks
{
    [Binding]
    class WebDriverHooks
    {
        private readonly IObjectContainer container;
        private readonly string browser;
        private IWebDriver driver;

        public WebDriverHooks(IObjectContainer container)
        {
            this.container = container;
            browser = "chrome";
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            switch (browser)
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();

                    chromeOptions.AddArgument("start-maximized");
                    driver = new ChromeDriver(chromeOptions);
                    driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(5));
                    container.RegisterInstanceAs<IWebDriver>(driver);
                    break;
            }
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }


    }
}

