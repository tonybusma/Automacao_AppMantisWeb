using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Automacao_AppMantisWeb
{
    public class TestBase : Utils
    {
        [TestInitialize]
        public void IniciarTeste()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://mantis-prova.base2.com.br");
            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void FinalizarTeste()
        {
            ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile("screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");

            Driver.Quit();
        }
    }
}
