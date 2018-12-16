using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace PageObjectModel
{
    public class Browser
    {
        static IWebDriver driver = null;

        public static String BrowserName = null;
        //


        /// <summary>
        /// set the Browser in which Application should be opened.
        /// </summary>
        /// <param name="BName">Enter the Name of Browser</param>
        /// <returns>Newly created instance of Respective Browser</returns>
        public static IWebDriver SetBrowserName(String BName)
        {
            switch (BName)
            {
                case "firefox":
                    {
                        driver = new FirefoxDriver();
                        break;
                    }
                case "chrome":
                    {

                        driver = new ChromeDriver();
                        break;
                    }
                case "ie":
                    {
                        driver = new InternetExplorerDriver("G:\\Selenium\\LatestDriver\\IEDriverServer_Win32_2.46.0");
                        break;
                    }
                default:
                    {
                        driver = null;
                        break;
                    }
            }
            return driver;
        }

        /// <summary>
        /// Close the current Browser/Application
        /// </summary>
        public static void Close()
        {
            driver.Close();
        }
    }
}