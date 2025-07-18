using MatKinhShadyTest.Base;
using MatKinhShadyTest.Pages;
using MatKinhShadyTest.Pages.AccountPage;
using MatKinhShadyTest.Utilities;
using MatKinhShadyTest.Utilities.Report;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace MatKinhShadyTest.Test
{
  [TestFixture]
  public class BaseTest
  {
    protected IWebDriver driver;
    protected BasePage basePage;
    protected HomePage homePage;
    protected string email = "Nguyen102500@gmail.com";
    protected string password = "PuQ8a6eg!ptG";
    protected static readonly List<string> products = new List<string>
    {
      "Rayban Eyewear - Sunglasses - 0RB4455F",
      "Tom Ford Eyewear - Sunglasses - TF1163K",
      "Molsion Eyewear - Sunglasses - MS3112"
    };
    protected void LogIn()
    {
      ExtentReporting.LogInfo("Starting LogIn test");
      
      var logInPage = homePage.GoToLogInPage();
      logInPage.LogIn(email, password);
      Assert.That(homePage.IsUserLoggedIn(email), Is.True);
    }

    [SetUp]
    public void SetUp()
    {
      ChromeOptions options = new ChromeOptions();
      options.AddArgument("--disable-notifications");
      options.AddUserProfilePreference("credentials_enable_service", false);
      options.AddUserProfilePreference("profile.password_manager_enabled", false);

      driver = new ChromeDriver(options);
      driver.Manage().Window.Maximize();
      DriverManager.SetDriver(driver);
      ExtentReporting.InitReport();
      ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
      Utility.SetUtilities();
      driver.Navigate().GoToUrl("https://matkinhshady.com/");

      basePage = new BasePage();
      homePage = new HomePage();
    }

    [TearDown]
    public void TearDown()
    {
      EndTest();
      ExtentReporting.FlushReport();
      driver.Quit();
    }

    private void EndTest()
    {
      var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
      var message = TestContext.CurrentContext.Result.Message;

      switch (testStatus)
      {
        case TestStatus.Passed:
          ExtentReporting.LogPass("Test passed");
          break;
        case TestStatus.Failed:
          ExtentReporting.LogFail($"Test failed: {message}");
          ExtentReporting.LogScreenShot("Screenshot is logged at", ScreenshotUtility.TakeScreenshotAsBase64());
          //ScreenshotUtility.TakeScreenshotToFile(TestContext.CurrentContext.Test.MethodName);
          break;
        case TestStatus.Skipped:
          ExtentReporting.LogInfo($"Test skipped: {message}");
          break;
        default:
          ExtentReporting.LogInfo("Test completed with unknown status");
          break;
      }
      ExtentReporting.LogInfo("Test ended");
    }
  }
}
