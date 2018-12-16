using OpenQA.Selenium;


namespace PageObjectModel
{
    public class Registerpage
    {
        static IWebDriver RPdriver = null;
        

        // (UIObject) Register page Locators 
        /// <summary>
        /// After Register/signup button we are checking the next pages title to identify the register has done.
        /// </summary>
        static By Confirmregister = By.CssSelector("//h2:contains('Confirm Your Email Address')");


        /// <summary>
        /// Constructor to initialize the register page
        /// </summary>
        /// <param name="driver">open the register page in same browser.</param>
        public Registerpage(IWebDriver driver)
        {
            RPdriver = driver;
        }

        /// <summary>
        /// Get the title/ a string from register page to identify we are on register page. 
        /// </summary>
        /// <returns>Return the Text/constant string from Register Page </returns>
        public static string getTitle()
        {
            return RPdriver.FindElement(Confirmregister).Text;
        }
    }
}
