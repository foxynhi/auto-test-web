using MatKinhShadyTest.Utilities.Report;
using NUnit.Framework;

namespace MatKinhShadyTest.Test.CheckOutTest
{
  public class CheckOutTest : BaseTest
  {
    private readonly string address = "123 Lí Thường Kiệt";
    private readonly string phoneNumber = "0987654321";

    [Test, Category("Orderd"), Order(4)]
    public void CheckOutCartTest()
    {
      ExtentReporting.LogInfo("Starting CheckOutCartTest test");
      LogIn();
      var cartPage = homePage.GoToCartPage();
      Assert.That(cartPage.IsOnCartPage, Is.True);
      if (cartPage.GetCartItems() == null)
      {
        ExtentReporting.LogInfo("No items found in the cart. Skipping checkout.");
        return;
      }

      var checkOutPage = cartPage.GoToCheckOut();
      Assert.That(checkOutPage.IsOnCheckOutPage, Is.True);

      

      var successOrderPage = checkOutPage.CheckOutCart(phoneNumber, address);
      ExtentReporting.LogInfo("Order number: " + successOrderPage.GetOrderNumber());
      ExtentReporting.LogInfo("Total payment: " + successOrderPage.GetOrderTotal());
      ExtentReporting.LogInfo("Payment method: " + successOrderPage.GetPaymentMethod());
      ExtentReporting.LogInfo("Shipping method: " + successOrderPage.GetShippingMethod());
      ExtentReporting.LogInfo("Shipping address: " + successOrderPage.GetShippingAddress());

      ExtentReporting.LogInfo("CheckOutCartTest completed successfully.");

    }
  }
}
