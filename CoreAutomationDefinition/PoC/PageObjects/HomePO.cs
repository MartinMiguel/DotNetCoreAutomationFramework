using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAutomationDefinition.PoC.PageObjects
{
    public class HomePO : DriverHelper
    {
        IWebElement LnkLogin => Driver.FindElement(By.Id("loginLink"));

        IWebElement LnkLogOff => Driver.FindElement(By.LinkText("Log off"));

        public void ClickLogin() => LnkLogin.Click();

        public bool IsLogOffExist() => LnkLogOff.Displayed;
    }
}
