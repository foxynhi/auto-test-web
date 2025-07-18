using MatKinhShadyTest.Utilities.Report;
using NUnit.Framework;

namespace MatKinhShadyTest.Test.CartTest
{
  public class DeleteCartTest : BaseTest
  {

    [Test, Category("Orderd"), Order(4)]
    public void DeleteAllCartTest()
    {
      ExtentReporting.LogInfo("Starting DeleteAllCartTest test");
      LogIn();
      var cartPage = homePage.GoToCartPage();
      Assert.That(cartPage.IsOnCartPage, Is.True);

      bool deleteAllCartResult = cartPage.DeleteAllItemsFromCart();
      Assert.That(deleteAllCartResult, Is.True, "The items was not deleted from the cart.");

      ExtentReporting.LogInfo("All items deleted successfully from the cart.");
    }

    [Test, Category("Orderd"), Order(3)]
    public void DeleteCartItemTest()
    {
      ExtentReporting.LogInfo("Starting DeleteCartItemTest test");
      LogIn();
      var cartPage = homePage.GoToCartPage();
      Assert.That(cartPage.IsOnCartPage, Is.True);

      var initialCart = cartPage.GetCartItems();
      if (initialCart == null)
      {
        Assert.Fail("No items found in the cart. Skipping deletion.");
        return;
      }
      int initialCount = initialCart.Count;

      bool deleteCartResult = cartPage.DeleteItemFromCart(products[0]);
      if (!deleteCartResult)
      {
        Assert.Fail("The item was not deleted from the cart.");
        return;
      }
      var newCart = cartPage.GetCartItems();
      if (newCart == null && deleteCartResult)
      {
        ExtentReporting.LogInfo("Item deleted successfully from the cart. Cart is now empty");
        return;
      }
      Assert.That(newCart.Count, Is.EqualTo(initialCount - 1), "The item was not deleted from the cart.");

      ExtentReporting.LogInfo("Item deleted successfully from the cart.");
    }
  }
}
