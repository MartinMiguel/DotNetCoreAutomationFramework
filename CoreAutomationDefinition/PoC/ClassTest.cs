using CoreAutomationDefinition.PoC.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CoreAutomationDefinition.PoC
{
    public class ClassTest : DriverHelper
    {
        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Console.WriteLine("Setup");
        }

        //[Test]
        public void ExecuteTest1()
        {

            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");

            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");

            CustomControls.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Almond");

            Console.WriteLine("Execution");

            Assert.Pass();
        }

        [Test]
        public void LoginTest()
        {
            Driver.Navigate().GoToUrl("http://eaapp.somee.com/");

            HomePO homePO = new HomePO();
            LoginPO loginPO = new LoginPO();

            homePO.ClickLogin();
            loginPO.EnterUserNameAndPassword("admin", "password");
            loginPO.ClickLogin();
            Assert.That(homePO.IsLogOffExist(), Is.True, "Log off button did not displayed");
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
            Console.WriteLine("Teardown");
        }
    }
}
