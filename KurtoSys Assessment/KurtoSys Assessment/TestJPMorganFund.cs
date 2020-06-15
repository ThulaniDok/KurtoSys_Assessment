using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace KurtoSys_Assessment
{
    class TestJpMorganFund
    {
        /// <summary>
        /// Representing the Chrome web driver
        /// </summary>
        IWebDriver driver = new ChromeDriver();

        /// <summary>
        ///     Setting up url to be tested
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl(" https://am.jpmorgan.com/gb/en/asset-management/gim/adv/home");
            Console.WriteLine("Open Browser and Navigate to test page.");
        }

        /// <summary>
        /// Verify Graph does exist for specific fund
        /// </summary>
        [Test]
        public void VerifyGraphExistForGrowthOfHypotheticalInvestment()
        {
            driver.FindElement(By.XPath("/html/body/div[10]/div/div/div/div/div[2]/div[4]/div[2]/div")).Click();
            Console.WriteLine("Accept the disclaimer.");

            var viewFund = driver.FindElement(By.XPath("/html/body/div[3]/div[4]/div/div[1]/div[3]/a"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            viewFund.Click();
            Console.WriteLine("View our future funds.");

            driver.FindElement(By.XPath("/html/body/div[3]/div[4]/div/div/div/div[1]/div[1]/div/div[1]/div/div[1]/div[2]/div[2]/span/div/span/a/span/span[1]")).Click();
            Console.WriteLine("Find out more about the JPM UK Dynamic Fund.");
            
            SetMethods.EnterText(driver, "searchbox", "GB0009698001", "Id");
            Console.WriteLine("Enter GB0009698001 in search box.");
                
            driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[1]/div[1]/div/div[1]/div/div/div/div[1]/div[2]/div/div[1]/div/div/div/div[2]/div/a/div")).Click();
            Console.WriteLine("Choose fund from drop down.");  
            
            var isin = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[1]/div[2]/div/div[3]/div/div[1]/div[2]/div/div/div[2]/div[2]/div/div/span[2]")).Text;
            Assert.IsTrue(isin.Contains("GB0009698001"));
            
            driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[1]/div[2]/div/div[2]/div[1]/div/ul/li[2]/a")).Click();
            Console.WriteLine("View our future funds.");

            var chart = GetMethods.GetText(driver, "PerformanceChart", "Id");
            Assert.IsTrue(chart.Contains("PerformanceChart"));
            Console.WriteLine("Verify graph exist.");
        }
        
        /// <summary>
        /// Closing test
        /// </summary>
        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}