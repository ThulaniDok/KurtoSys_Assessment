using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace KurtoSys_Assessment
{
    public class SetMethods
    {
        /// <summary>
        /// 
        /// </summary>
        public static void EnterText(IWebDriver driver, string element, string value, string elementType)
        {
            switch (elementType)
            {
                case "Id":
                    driver.FindElement(By.Id(element)).SendKeys(value);
                    break;
                case "Name":
                    driver.FindElement(By.Name(element)).SendKeys(value);
                    break;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static void Click(IWebDriver driver, string element, string elementType)
        {
            switch (elementType)
            {
                case "Id":
                    driver.FindElement(By.Id(element)).Click();
                    break;
                case "Name":
                    driver.FindElement(By.Name(element)).Click();
                    break;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementType)
        {
            switch (elementType)
            {
                case "Id":
                    new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
                    break;
                case "Name":
                    new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
                    break;
            }
        }
        
    }
}