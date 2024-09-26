using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Automacao_AppMantisWeb
{
    public class Utils
    {
        #region Variáveis

        public static IWebDriver Driver;

        public static string usuario = "Luis_Menezes";
        public static string senha = "ue%LSW7a-5G)7;])";

        #endregion Variáveis

        #region Métodos de Interação/Pausa

        public static bool ElementoVisivel(By elemento)
        {
            try
            {
                Assert.IsTrue(Driver.FindElement(elemento).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void PausaImplicita(int segundos)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(segundos);
        }

        public static void PausaForcada(int segundos)
        {
            int tempo = segundos * 1000;
            Thread.Sleep(tempo);
        }

        public static void ClicarNoElemento(By elemento, [Optional] string descricao)
        {
            try
            {
                if(descricao != null) { Console.WriteLine(descricao); }
                Driver.FindElement(elemento).Click();
            }
            catch
            {
                Console.WriteLine(Console.Error);
                Assert.Fail();
            }
        }

        public static void Digitar(By elemento, string texto)
        {
            Driver.FindElement(elemento).SendKeys(texto);
        }

        public static void SelecionarOpcaoPeloValor(By elemento, string valor)
        {
            var select = new SelectElement(Driver.FindElement(elemento));
            select.SelectByValue(valor);
        }

        public static void CarregarImagem(By elemento)
        {
            IWebElement element = Driver.FindElement(elemento);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("document.getElementsByName('max_file_size')[0].setAttribute('type', 'file');", element);
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\Bug.jpg");
            element.SendKeys(caminho);
        }

        #endregion Métodos de Interação/Pausa
    }
}
