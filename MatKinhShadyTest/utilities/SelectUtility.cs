using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MatKinhShadyTest.Utilities
{
  public class SelectUtility : Utility
  {
    private static SelectElement Select(IWebElement element)
    {
      return new SelectElement(element);
    }
    public static void SelectByText(By locator, string text)
    {
      Select(driver.FindElement(locator)).SelectByText(text);
    }
    public static void SelectByValue(By locator, string value)
    {
      Select(driver.FindElement(locator)).SelectByValue(value);
    }
  }
}
