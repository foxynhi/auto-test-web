using MatKinhShadyTest.Utilities.Report;
using NUnit.Framework;

namespace MatKinhShadyTest.Test.ProfileTest
{
  [TestFixture]
  public class AddAddressTest : BaseTest
  {

    private readonly string lastName = "Nguyen";
    private readonly string firstName = "Van A";
    private readonly string address = "321 An Thuong";
    private readonly string phoneNumber = "0123456789";

    [Test, Order(1)]
    public void AddAddress()
    {
      ExtentReporting.LogInfo("Starting Add Address test");
      LogIn();
      var addressPage = homePage.GoToLogInPage().GoToAddressPage();
      Assert.That(addressPage.IsOnAddressPage(), Is.True, "Not on Address Page");

      bool addAddressResult = addressPage.AddAdress(lastName, firstName, address, phoneNumber);
      if (!addAddressResult)
      {
        ExtentReporting.LogFail("Failed to add address");
      }
      ExtentReporting.LogInfo($"Add Address successfully with name '{lastName} {firstName}', address '{address}', phone number '{phoneNumber}'");
    }

    [Test, Order(2)]
    public void VerifyAddedAddress()
    {
      ExtentReporting.LogInfo("Starting Verify Added Address test");
      LogIn();
      var addressPage = homePage.GoToLogInPage().GoToAddressPage();
      Assert.That(addressPage.IsOnAddressPage(), Is.True, "Not on Address Page");

      ExtentReporting.LogInfo($"Verifying name match: {lastName} {firstName}");
      Assert.That(addressPage.GetFullName(address), Does.Contain(lastName), "Full name does not match");
      ExtentReporting.LogInfo($"Verifying added address match: {address}");
      Assert.That(addressPage.GetAddress(address), Does.Contain(address), "Address does not match");
      ExtentReporting.LogInfo($"Verifying phone number match: {phoneNumber}");
      Assert.That(addressPage.GetPhoneNumber(address), Does.Contain(phoneNumber), "Phone number does not match");

      ExtentReporting.LogInfo("Verify Added Address successfully");
    }
  }
}
