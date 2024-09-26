using OpenQA.Selenium;

namespace Automacao_AppMantisWeb.Page
{
    public static class LoginPage
    {
        public static By CampoNomeDeUsuario() { return By.Id("username"); }
        public static By CampoSenha() { return By.Id("password"); }
        public static By BotaoEntrar() { return By.XPath("//input[@value='Entrar']"); }
        public static By MensagemDadosIncorretos() { return By.XPath("//*[@class='alert alert-danger']"); }
    }
}
