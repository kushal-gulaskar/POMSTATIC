using NUnit.Framework;

namespace PageObjectModel
{
    [TestFixture]
    public class AfterloginTest
    {
        [Test]
        public void UpdateStatusOnFacebookTest()
        {
            HomePage.setbrowser("chrome"); //.setbrowser("firefox");            
            HomePage.SetURL("https://www.facebook.com");
            AfterLogin.UpdateStatusOnFacebook("avinash21143@yahoo.co.in", "avinash21143@rediffmail.com", "Hello Everyone....!!");
            Assert.AreEqual("Welcome to Facebook - Log In, Sign Up or Learn More", HomePage.getTitle());

        }

        [TearDown]
        public void tearDown()
        {
            Browser.Close();
        }
    }
}
