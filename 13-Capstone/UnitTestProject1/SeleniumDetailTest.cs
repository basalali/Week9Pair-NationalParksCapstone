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
    public class SeleniumDetailTest 
    {
        [TestMethod]
        public void DetailPageTest()
        {
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {

                var url = "http://localhost:60349/";
                chromeDriver.Navigate().GoToUrl(url);
                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 1, 0));

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("product-image")));
                var pictureText = chromeDriver.FindElement(By.ClassName("product-image"));
                pictureText.Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("p")));
                var result = chromeDriver.FindElement(By.TagName("p"));

                Assert.IsTrue(result.Text.Contains("Cleveland"));
                Assert.IsTrue(result.Text.Contains("urban"));
                chromeDriver.Close();
            }
        }
    }
}