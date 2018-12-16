using NUnit.Framework;


namespace PageObjectModel.Test
{
    [TestFixture]
    public class HomePageTest
    {
        [SetUp]
        public void SetUpLoginTest()
        {
            HomePage.setbrowser("chrome");
            HomePage.SetURL("https://www.facebook.com/");
        }

        [Test]
        public void LoginTest()
        {

            HomePage.ClickOnLogin("avinash21143@yahoo.co.in", "avinash21143@rediffmail.com");
            Assert.AreEqual("Avinash", AfterLogin.getTitle());
            AfterLogin.LoggedOut();
            Assert.AreEqual("Welcome to Facebook - Log In, Sign Up or Learn More", HomePage.getTitle());
        }
        
        [Test]
        public void RegisterUserTest()
        {
            HomePage.RegisterNewUser("Avinashhh", "pandeyy", "pande.aavinash@gmail.com", "pande.aavinash@gmail.com", "aavinashpande@gmail.com", "Jun", "21", "1970", "male");
            Assert.AreEqual("Confirm Your Email Address", Registerpage.getTitle());
        }

        [TearDown]
        public void TearDownRegisterUserTest()
        {
            Browser.Close();
        }
    }
}
