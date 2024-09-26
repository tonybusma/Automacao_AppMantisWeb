using Automacao_AppMantisWeb.Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automacao_AppMantisWeb.Steps
{
    public class LoginSteps : TestBase
    {
        #region Métodos Genéricos

        public static void PreencherUsuarioEClicarEmEntrar(string usuario)
        {
            Digitar(LoginPage.CampoNomeDeUsuario(), usuario);
            ClicarNoElemento(LoginPage.BotaoEntrar());
        }

        public static void PreencherSenhaEClicarEmEntrar(string senha)
        {
            Digitar(LoginPage.CampoSenha(), senha);
            ClicarNoElemento(LoginPage.BotaoEntrar());
        }

        #endregion Métodos Genéricos

        public static void RealizaLoginComSucesso(string usuario, string senha)
        {
            PreencherUsuarioEClicarEmEntrar(usuario);
            PreencherSenhaEClicarEmEntrar(senha);
            PausaImplicita(15);
            Assert.IsTrue(ElementoVisivel(MenuPage.NomeDaContaDeUsuario()));
        }

        public static void TentativaDeLoginComSenhaInvalida(string usuario, string senha)
        {
            PreencherUsuarioEClicarEmEntrar(usuario);
            PreencherSenhaEClicarEmEntrar(senha);
            PausaImplicita(10);
            Assert.IsTrue(ElementoVisivel(LoginPage.MensagemDadosIncorretos()));
        }

        public static void TentativaDeLoginComUsuarioNulo(string usuario)
        {
            PreencherUsuarioEClicarEmEntrar(usuario);
            PausaImplicita(10);
            Assert.IsTrue(ElementoVisivel(LoginPage.MensagemDadosIncorretos()));
        }
    }
}
