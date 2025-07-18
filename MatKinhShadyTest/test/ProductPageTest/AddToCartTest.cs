using MatKinhShadyTest.Utilities.Report;
using NUnit.Framework;
using System.Collections.Generic;

namespace MatKinhShadyTest.Test.ProductPageTest
{
  [TestFixture, Category("Orderd")]
  public class AddToCartTest : BaseTest
  {
    private static IEnumerable<string> ProductData => products;

    [Test, TestCaseSource(nameof(ProductData)), Order(1)]
    public void BuyKinhMatNuTest(string product)
    {
      ExtentReporting.LogInfo("Starting BuyKinhMatNuTest test");
      LogIn();

      var kinhMatNuPage = homePage.GoToKinhMatNu();
      Assert.That(kinhMatNuPage.IsOnKinhMatNuPage(), Is.True);

      var productPage = kinhMatNuPage.GoToProductPage(product);
      productPage.IsOnProductPage(product);
      bool isAdded = productPage.AddToCart();
      if (!isAdded)
      {
        productPage.ClickCartButton();
      }
      productPage.VerifyProductAddedToCart(product);
    }
  }
}