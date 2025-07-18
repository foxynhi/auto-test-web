using MatKinhShadyTest.Base;
using MatKinhShadyTest.Utilities;
using MatKinhShadyTest.Utilities.Report;
using OpenQA.Selenium;

namespace MatKinhShadyTest.Pages
{
  public class KinhMatNuPage : BasePage
  {
    private readonly By breadCrumb = By.XPath("//ol[@class='breadcrumb breadcrumb-arrows']/li[last()]/span");
    

    public bool IsOnKinhMatNuPage()
    {
      ExtentReporting.LogInfo("Checking if on Kinh Mat Nu page.");
      WaitUtility.WaitForElementToBeVisible(breadCrumb, 10);
      string breadCrumbText = Find(breadCrumb).Text;
      return breadCrumbText.ToLower().Contains("kính mát nữ");
    }
    public ProductPage GoToProductPage(string productName)
    {
      ExtentReporting.LogInfo($"Navigating to {productName} product page");
      By targetProduct = By.XPath("(//a[contains(@title,'" + productName + "')])[1]");
      JSUtility.ScrollTo(targetProduct);
      Click(targetProduct);
      return new ProductPage();
    }
  }
}
