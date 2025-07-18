# Automation Test Project – MatKinhShady.com

## Project Overview
- **Purpose**: Automate end-to-end testing of the Mắt Kính Shady e-commerce platform.
- **Website under test**: https://matkinhshady.com/​
- **Technologies**:
  - **Language**: C#
  - **Test Framework**: NUnit
  - **Browser Automation**: Selenium WebDriver
  - **Reporting**: ExtentReports
  - **Build Tool**: Visual Studio
- **Presentation slide**: https://fptsoftware362-my.sharepoint.com/:p:/g/personal/nhindk1_fpt_com/EYI2t9TjbUdKoGGK7KT9XE8BZh7xNof7pdS1x9ttA9X_ng?e=Ko40Lj
- **Test video record**: https://fptsoftware362-my.sharepoint.com/:f:/g/personal/nhindk1_fpt_com/Eq4yZQa_4lhGqslnHS9HowABSlGgDnYh-7k72ZJSReG8mg?e=ksKDDW

## Features Tested

- **User Login**  
  Simulates user login with valid credentials.

- **Add to Cart**  
  Adds one or more products to the shopping cart with product name.

- **Verify Cart Items**  
  Asserts that selected items are correctly added and displayed in the cart.

- **Delete Cart Items**  
  Removes items from the cart and verifies the cart is updated.

- **Checkout**  
  Simulates completing a purchase flow (excluding actual payment).

- **Add Address to User Profile**  
  Adds a new shipping address to the user’s profile.

## Installation and Setup
### Step 1: Clone this repo:
   ```bash
   git clone https://github.com/foxynhi/mat-kinh-shady-auto-test
  ```
### Step 2: Install Dependencies
1. Open the project in Visual Studio
2. Restore NuGet packages

### Step 3: Run the Tests
1. Open Test Explorer (Test > Test Explorer).
2. Build the solution (Build > Build Solution).
3. Select and run tests
