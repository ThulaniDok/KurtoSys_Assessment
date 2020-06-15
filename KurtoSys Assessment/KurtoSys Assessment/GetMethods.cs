using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KurtoSys_Assessment
{
    public class GetMethods
    {
        public static string GetText(IWebDriver driver, string element, string elementType)
        {
            switch (elementType)
            {
                case "Id":
                    return driver.FindElement(By.Id(element)).GetAttribute("value");
                case "Name":
                    return driver.FindElement(By.Name(element)).GetAttribute("value");
                default:
                    return string.Empty;
            }
        }
        
        public static string GetTextFromDropDownList(IWebDriver driver, string element, string elementType)
        {
            switch (elementType)
            {
                case "Id":
                    return new SelectElement(driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault()
                        ?.Text;
                case "Name":
                    return new SelectElement(driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault()
                        ?.Text;
                default:
                    return string.Empty;
            }
        }
    }
}