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

        [Test]
        public void ExecuteTest1()
        {

            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");

            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");

            CustomControls.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Almond");

            Console.WriteLine("Execution");

            Assert.Pass();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
            Console.WriteLine("Teardown");
        }
    }
}
