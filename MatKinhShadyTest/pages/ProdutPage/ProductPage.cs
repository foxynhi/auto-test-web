using MatKinhShadyTest.Base;
using MatKinhShadyTest.Utilities;
using MatKinhShadyTest.Utilities.Report;
using OpenQA.Selenium;
using System;

namespace MatKinhShadyTest.Pages
{
  public class ProductPage : BasePage
  {
    private readonly By productName = By.XPath("//div[@class='product-title']/h1");
    private readonly By addToCartBtn = By.XPath("//a[contains(text(),'Thêm vào giỏ hàng')]");
    private readonly By cartBtn = By.XPath("//span[@id='site-cart-handle']");


    public bool IsOnProductPage(string expectedProductName)
    {
      ExtentReporting.LogInfo("Checking if on Product page.");
      string actualProductName = Find(productName).Text;
      return actualProductName.Equals(expectedProductName, StringComparison.OrdinalIgnoreCase);
    }
    public bool AddToCart()
    {
      ExtentReporting.LogInfo("Adding product to cart.");
      try
      {
        ActionsUtility.ScrollTo(addToCartBtn);
        Click(addToCartBtn);
        IAlert alert = WaitUtility.WaitForAlert();
        ExtentReporting.LogInfo($"Alert detected with message: {alert.Text}");
        SwitchUtility.Accept();
        return false;
      } catch (WebDriverTimeoutException)
      {
        ExtentReporting.LogInfo($"No alert detected, add to cart successfully.");
        return true;
      }
    }
    public bool VerifyProductAddedToCart(string expectedProductName)
    {
      ExtentReporting.LogInfo("Verifying product added to cart.");
      WaitUtility.WaitForElementToBeVisible(By.XPath("//p[contains(text(),'Giỏ hàng')]"));
      string quantity = Find(By.XPath("//table[@id='cart-view']//tr/td[2]/span[@class='pro-quantity-view']")).Text;
      string price = Find(By.XPath("//table[@id='cart-view']//tr/td[2]/span[@class='pro-price-view']")).Text;
      string name = Find(By.XPath("//table[@id='cart-view']//tr/td[2]/a")).Text;

      ExtentReporting.LogInfo($"{quantity} - {name} - {price} added to cart");
      return name.Equals(expectedProductName);
    }
    public void ClickCartButton()
    {
      ExtentReporting.LogInfo("Clicking on Cart button.");
      WaitUtility.WaitForElementToBeClickable(cartBtn);
      Click(cartBtn);
    }
  }
}
