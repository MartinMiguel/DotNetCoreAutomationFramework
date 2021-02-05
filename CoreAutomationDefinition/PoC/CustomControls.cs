using OpenQA.Selenium;

namespace CoreAutomationDefinition.PoC
{
    public class CustomControls : DriverHelper
    {
        public static void ComboBox(string controlName, string value)
        {
            IWebElement cmbControl = Driver.FindElement(By.XPath($"//input[@id='{controlName}-awed']"));
            cmbControl.Clear();
            cmbControl.SendKeys("Almond");

            Driver.FindElement(By.XPath($"//div[@id='{controlName}-dropmenu']//li[text()='{value}']")).Click();
        }
    }
}
