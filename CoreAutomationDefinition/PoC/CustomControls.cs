using OpenQA.Selenium;

namespace CoreAutomationDefinition.PoC
{
    /// <summary>
    /// CustomControls class
    /// </summary>
    /// <seealso cref="CoreAutomationDefinition.PoC.DriverHelper" />
    public class CustomControls : DriverHelper
    {
        /// <summary>
        /// ComboBoxes the specified control name.
        /// </summary>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="value">The value.</param>
        public static void ComboBox(string controlName, string value)
        {
            IWebElement cmbControl = Driver.FindElement(By.XPath($"//input[@id='{controlName}-awed']"));
            cmbControl.Clear();
            cmbControl.SendKeys("Almond");

            Driver.FindElement(By.XPath($"//div[@id='{controlName}-dropmenu']//li[text()='{value}']")).Click();
        }
    }
}
