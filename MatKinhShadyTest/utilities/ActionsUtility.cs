using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MatKinhShadyTest.Utilities
{
  public class ActionsUtility : Utility
  {
    private static Actions Act()
    {
      return new Actions(driver);
    }
    public static void MoveToElement(By element)
    {
      Act().MoveToElement(driver.FindElement(element)).Perform();
    }

    internal static void ScrollTo(By element)
    {
      Act().ScrollToElement(driver.FindElement(element)).Perform();
    }
  }
}
