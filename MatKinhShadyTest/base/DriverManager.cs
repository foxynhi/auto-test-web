using OpenQA.Selenium;

namespace MatKinhShadyTest.Base
{
  public class DriverManager
  {
    public static IWebDriver Driver;
    public static void SetDriver(IWebDriver driver)
    {
      Driver = driver;
    }
  }
}
