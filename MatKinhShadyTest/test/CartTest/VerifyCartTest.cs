using MatKinhShadyTest.Utilities.Report;
using NUnit.Framework;

namespace MatKinhShadyTest.Test.CartTest
{
  public class VerifyCartTest : BaseTest
  {
    [Test, Category("Orderd"), Order(2)]
    public void VerifyCart()
    {
      ExtentReporting.LogInfo("Verify Cart items");
      LogIn();
      var cartPage = homePage.GoToCartPage();
      Assert.That(cartPage.IsOnCartPage, Is.True);

      var cartItems = cartPage.GetCartItems();
      if (cartItems == null)
      {
        ExtentReporting.LogInfo("No items found in the cart.");
        return;
      }
      cartItems.ForEach(item =>
      {
        Assert.That(products.Contains(item), Is.True, $"Item '{item}' is not in the expected product list.");
      });
    }
  }
}
