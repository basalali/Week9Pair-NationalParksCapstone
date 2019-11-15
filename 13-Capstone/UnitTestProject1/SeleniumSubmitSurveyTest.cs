using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample
{
    [TestClass]
    public class SeleniumSubmitSurveyTest
    {
        [TestMethod]
        public void SubmitSurveyPageTest()
        {
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {

                var url = "http://localhost:60349/";
                chromeDriver.Navigate().GoToUrl(url);
                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 1, 0));

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Survey")));
                var surveyLink = chromeDriver.FindElement(By.LinkText("Survey"));
                surveyLink.Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Submit")));
                var submitSurvey = chromeDriver.FindElement(By.PartialLinkText("Submit"));
                submitSurvey.Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("row")));
                var result = chromeDriver.FindElement(By.ClassName("row"));

                Assert.IsTrue(result.Text.Contains("Activity"));
                chromeDriver.Close();
            }
        }
    }
}