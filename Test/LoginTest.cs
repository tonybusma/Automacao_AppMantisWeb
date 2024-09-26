using Automacao_AppMantisWeb.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automacao_AppMantisWeb.Test
{
    [TestClass]
    [TestCategory("Login")]
    public class LoginTest : TestBase
    {
        [TestMethod]
        [TestCategory("LoginComSucesso")]
        public void ValidarLoginComSucesso()
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);
        }

        [TestMethod]
        [TestCategory("LoginSenhaInvalida")]
        public void ValidarLoginComSenhaInvalida()
        {
            LoginSteps.TentativaDeLoginComSenhaInvalida(usuario, "senhaInvalida");
        }

        [TestMethod]
        [TestCategory("LoginUsuarioNulo")]
        public void ValidarLoginComNomeDeUsuarioNulo()
        {
            LoginSteps.TentativaDeLoginComUsuarioNulo(" ");
        }
    }
}
