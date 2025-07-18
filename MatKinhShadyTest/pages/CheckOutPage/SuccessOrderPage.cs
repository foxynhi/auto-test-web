using MatKinhShadyTest.Base;
using MatKinhShadyTest.Utilities;
using MatKinhShadyTest.Utilities.Report;
using OpenQA.Selenium;

namespace MatKinhShadyTest.Pages
{
  public class SuccessOrderPage : BasePage
  {
    private readonly By successMessage = By.XPath("//p[@class='text-bodyl_bold']");
    private readonly By orderNumber = By.TagName("pre");
    private readonly By orderTotal = By.XPath("//div[@class='w-full flex gap-1 items-center justify-between pb-[6px]']/div");
    private readonly By orderPending = By.XPath("//div[@class='w-full flex items-center justify-between pt-[6px]']/p[2]");
    private readonly By paymentMethod = By.XPath("//div[@class='pt-[6px] flex border-t-1 border-dashed flex-row gap-2 w-full items-center']/div/div/div/div");
    private readonly By shippingMethod = By.XPath("//div[@class='relative max-w-fit inline-flex items-center justify-between box-border whitespace-nowrap h-7 text-small text-default-foreground py-1 px-[10px] bg-[#FEF3C8] rounded-[10px]']//span");
    private readonly By shippingAddress = By.XPath("//p[@class='input-content--subdued break-words']");


    public bool IsOrderSuccessful()
    {
      try
      {
        WaitUtility.WaitForElementToBeVisible(successMessage);
        return Find(successMessage).Text.Contains("Đặt hàng thành công");
      }
      catch (NoSuchElementException)
      {
        ExtentReporting.LogFail("Success order page not loaded.");
        return false;
      }
    }
    public string GetOrderNumber()
    {
      try
      {
        return WaitUtility.WaitForElementToBeVisible(orderNumber).Text.Trim('#');
      }
      catch (NoSuchElementException)
      {
        ExtentReporting.LogFail("Order number not found.");
        return "";
      }
    }
    public string GetOrderTotal()
    {
      try { 
        return WaitUtility.WaitForElementToBeVisible(orderTotal).Text;
      }
      catch (NoSuchElementException)
      {
        ExtentReporting.LogFail("Order total payment not found.");
        return "";
      }
    }
    public string GetPaymentMethod()
    {
      try
      {
        return WaitUtility.WaitForElementToBeVisible(paymentMethod).Text;
      }
      catch (NoSuchElementException)
      {
        ExtentReporting.LogFail("Payment method not found.");
        return "";
      }
    }
    public string GetShippingMethod()
    {

      try
      {
        return WaitUtility.WaitForElementToBeVisible(shippingMethod).Text;
      }
      catch (NoSuchElementException)
      {
        ExtentReporting.LogFail("Shipping method not found.");
        return "";
      }
    }
    public string GetShippingAddress()
    {
      try
      {
        return WaitUtility.WaitForElementToBeVisible(shippingAddress).Text;
      }
      catch (NoSuchElementException)
      {
        ExtentReporting.LogFail("Shipping address not found.");
        return "";
      }
    }
  }
}

