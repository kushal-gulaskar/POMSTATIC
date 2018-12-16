using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel
{
    public class AfterLogin
    {
        static IWebDriver driver = null;
        static IWebElement element = null;
        //locators Used for Logged-out Action
        static By Logout = By.Id("pageLoginAnchor");
        static By Logoutfull = By.XPath("//input[@type='submit'][@value='Log Out']");
        //Locators Used for To Update status on facebook and Post it.
        static By UpdateStatusMessage = By.XPath("//div[@class='innerWrap']/textarea[@id='u_0_z']");
        static By PostButton = By.XPath("//div[@class='clearfix']/ul/li[2]/button");


        /// <summary>
        /// Constructor Initilize with browser driver. 
        /// </summary>
        /// <param name="driverr">driver of browser on which test is to be carried out</param>
        public AfterLogin(IWebDriver driverr)
        {
            driver = driverr;
        }

        /// <summary>
        /// Set the Browser in which application needs to be Test.
        /// </summary>
        /// <param name="BName">Browser Name</param>
        /// <returns>object of a specific Browser</returns>
        public static IWebDriver SetBrowser(string BName)
        {
            driver = HomePage.setbrowser(BName);
            return driver;
        }

        /// <summary>
        /// Logged out from Facebook application.
        /// </summary>
        /// <returns>Returns to the Home Page</returns>
        public static HomePage LoggedOut()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
            driver.FindElement(Logout).Click();
            driver.FindElement(Logoutfull).Click();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));

            return new HomePage(driver);
        }

        /// <summary>
        /// update the Status in your account by writting message in whats in your mind?
        /// </summary>
        /// <param name="message">Message you want to write</param>
        public static void UpdateStatus(String message)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(UpdateStatusMessage));
            driver.FindElement(UpdateStatusMessage).Click();
            driver.FindElement(UpdateStatusMessage).SendKeys(message);
        }

        /// <summary>
        /// Click on Post button to post the update status message.
        /// </summary>
        public static void ClickPostButton()
        {
            element = driver.FindElement(PostButton);
            Console.WriteLine(element.Text);
            Console.WriteLine(element.GetAttribute("type"));
            element.Click();
        }

        /// <summary>
        /// Get the Title of a page or Constant message from the page to identify the respective page.
        /// </summary>
        /// <returns>Message or title of a page</returns>
        public static string getTitle()
        {
            return driver.FindElement(By.XPath("//div//a//span[contains(text(),'Avinash')]")).Text.ToString();
        }

        /// <summary>
        /// Update the Status on Facebook profile. 
        /// </summary>
        /// <param name="userName">setUser Name to be login</param>
        /// <param name="password">Set Password to be used to login</param>
        /// <param name="updateStatusMessage">set the message to be update on status.</param>
        /// <returns></returns>
        public static HomePage UpdateStatusOnFacebook(String userName, String password, String updateStatusMessage)
        {
            HomePage.ClickOnLogin(userName, password);
            AfterLogin.UpdateStatus(updateStatusMessage);
            System.Threading.Thread.Sleep(5000);
            AfterLogin.ClickPostButton();
            AfterLogin.LoggedOut();
            return new HomePage(driver);
        }
    }
}
