using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PageObjectModel
{
    public class HomePage
    {

        static IWebDriver driver = null;
        static IWebElement element = null;
        //(UIObject) Locators for Login/SignIn
        static By userName = By.Id("email");
        static By Password = By.Id("pass");
        static By LogIn = By.XPath("//input[@type='submit'][@value='Log In']");


        // (UIObject) Locators for to Register a New User on Facebook Application
        static By FirstName = By.Id("u_0_1");
        static By LastName = By.Id("u_0_3");
        static By Email = By.Id("u_0_5");
        static By ReEmail = By.Id("u_0_8");
        static By NewPassword = By.Id("u_0_a");
        static By Month = By.Id("month");
        static By Day = By.Id("day");
        static By Year = By.Id("year");
        static By GenderFemale = By.Id("u_0_d");
        static By GenderMale = By.Id("u_0_e");
        static By SignUp = By.Id("u_0_i");


        /// <summary>
        /// Constructor to initialize set the browser for Homepage
        /// </summary>
        /// <param name="driverr">Tell us on which Browser the application is going to open</param>
        public HomePage(IWebDriver driverr)
        {
            driver = driverr;
        }

        /// <summary>
        /// Set the Browser on which the application is to be Run/Test.
        /// </summary>
        /// <param name="BrowserName">Name of browser to be Set</param>
        /// <returns>Instance of newely set Browser</returns>
        public static IWebDriver setbrowser(String BrowserName)
        {
            driver = Browser.SetBrowserName(BrowserName);
            return driver;
        }

        /// <summary>
        /// Set the URL of an Application to be Test
        /// </summary>
        /// <param name="url">URL of Your Application under Test.</param>
        public static void SetURL(String url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Set the user Name to be Logged in.
        /// </summary>
        /// <param name="UserName">UserName to be Log-In</param>
        public static void setUserName(String UserName)
        {
            driver.FindElement(userName).SendKeys(UserName);
        }

        /// <summary>
        /// Set the Password, in the password field of facebook application.
        /// </summary>
        /// <param name="UserPassword">Password of user wants to Log-in.</param>
        public static void setUserPassword(String UserPassword)
        {
            driver.FindElement(Password).SendKeys(UserPassword);
        }

        /// <summary>
        /// Clcik on Login In Button.
        /// </summary>
        public static void ClickLogin()
        {
            driver.FindElement(LogIn).Click();
        }

        /// <summary>
        /// Click on Logged in Button after filling UserName and Password field.
        /// </summary>
        /// <param name="userName">User Name of User</param>
        /// <param name="Password">Password of User.</param>
        /// <returns>Return/Directed to the Next page after successful of Registering the User.</returns>
        public static AfterLogin ClickOnLogin(String userName, String Password)
        {
            setUserName(userName);
            setUserPassword(Password);
            ClickLogin();
            return new AfterLogin(driver);
        }

        /// <summary>
        /// Get the Title/Constant String from Home Page to Identify each page from each other.
        /// </summary>
        /// <returns></returns>
        public static String getTitle()
        {
            return driver.Title;
        }

        //II Test Part  
        // second part of Action in a HomePage is  Register a User 

        /// <summary>
        /// Set the New User name to be Register.
        /// </summary>
        /// <param name="firstName">Enter First name of User</param>
        public static void SetRegisterUserFirstName(String firstName)
        {
            driver.FindElement(FirstName).SendKeys(firstName);
        }

        /// <summary>
        /// Set the New User Last Name to be Register.
        /// </summary>
        /// <param name="lastName">last Name of New User</param>
        public static void SetRegisterUserLastName(String lastName)
        {
            driver.FindElement(LastName).SendKeys(lastName);
        }

        /// <summary>
        /// Set the Email of New user for Verification.
        /// </summary>
        /// <param name="eMail">Enter Email of New user for verification</param>
        public static void SetEmail(String eMail)
        {
            driver.FindElement(Email).SendKeys(eMail);
        }

        /// <summary>
        /// Re-Enter the mail
        /// </summary>
        /// <param name="reEmail">Re-Enter the mail of new user </param>
        public static void SetReEMail(String reEmail)
        {
            driver.FindElement(ReEmail).SendKeys(reEmail);
        }



        /// <summary>
        /// Set the Password for Facebook login for new user
        /// </summary>
        /// <param name="newPassword">Enter New password</param>
        public static void SetNewPassword(String newPassword)
        {
            driver.FindElement(NewPassword).SendKeys(newPassword);
        }

        /// <summary>
        /// Select the Month from Drop Down List.
        /// </summary>
        /// <param name="month">Enter your Birth Month  </param>
        public static void SelectMonth(String month)
        {
            SelectElement select = new SelectElement(driver.FindElement(Month));
            foreach (IWebElement item in select.Options)
            {
                if (item.Text.Contains(month))
                    item.Click();
            }
        }

        /// <summary>
        /// select  the year of Your Birth from Drop DownList.
        /// </summary>
        /// <param name="year">Enter Your year of Birth.</param>
        public static void SelectYear(String year)
        {
            SelectElement select = new SelectElement(driver.FindElement(Year));
            foreach (IWebElement item in select.Options)
            {
                if (item.Text.Contains(year))
                    item.Click();
            }
        }

        /// <summary>
        /// Select Birth day from drop DownList.
        /// </summary>
        /// <param name="day">Enter your Birthday.</param>
        public static void SelectDay(String day)
        {
            SelectElement select = new SelectElement(driver.FindElement(Day));
            foreach (IWebElement item in select.Options)
            {
                if (item.Text == day)
                    item.Click();
            }
        }

        /// <summary>
        /// select Your Gender
        /// </summary>
        /// <param name="gender">select Male / Female</param>
        public static void selectGender(String gender)
        {
            String genderr = gender.ToLower();
            element = driver.FindElement(GenderMale);
            if (element.Text.ToLower() == genderr)
            {
                element.Click();
            }
            else
            {
                element = driver.FindElement(GenderFemale);
                element.Click();
            }
            element = null;
        }

        /// <summary>
        /// Click on signUp Button
        /// </summary>
        public static void ClickSignUp()
        {
            driver.FindElement(SignUp).Click();
        }

        /// <summary>
        /// Register  the new User with His/Her details.
        /// </summary>
        /// <param name="firstName">Name of User.</param>
        /// <param name="lastname">Last Name Of User.</param>
        /// <param name="eMail">Existing Email of User.</param>
        /// <param name="reEmail">Re-Enter the Existing E-mail.</param>
        /// <param name="newPassword">Enter New Password to access facebook Application</param>
        /// <param name="month">month of Birth.</param>
        /// <param name="day">Birth Day</param>
        /// <param name="year">Birth Year</param>
        /// <param name="gender">male/Female</param>
        /// <returns>return or Redirect to register Page.</returns>
        public static Registerpage RegisterNewUser(string firstName, String lastname, String eMail, String reEmail, string newPassword, String month, string day, string year, String gender)
        {
            SetRegisterUserFirstName(firstName);
            SetRegisterUserLastName(lastname);
            SetEmail(eMail);
            SetReEMail(reEmail);
            SetNewPassword(newPassword);
            SelectMonth(month);
            SelectDay(day);
            SelectYear(year);
            selectGender(gender);
            ClickSignUp();
            System.Threading.Thread.Sleep(5000);
            return new Registerpage(driver);
        }


    }
}
