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
    public class SeleniumSurveyTest
    {
        [TestMethod]
        public void SurveyPageTest()
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
                var pictureText = chromeDriver.FindElement(By.LinkText("Survey"));
                pictureText.Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("h2")));
                var result = chromeDriver.FindElement(By.TagName("h2"));

                Assert.IsTrue(result.Text.Contains("Survey"));
                chromeDriver.Close();
            }
        }
    }
}