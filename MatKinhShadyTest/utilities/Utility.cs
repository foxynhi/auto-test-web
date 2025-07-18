using MatKinhShadyTest.Base;
using OpenQA.Selenium;

namespace MatKinhShadyTest.Utilities
{
  public class Utility
  {
    public static IWebDriver driver;
    public static void SetUtilities()
    {
      driver = DriverManager.Driver;
    }
  }
}
