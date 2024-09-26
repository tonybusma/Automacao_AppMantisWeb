using Automacao_AppMantisWeb.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("Quando: Ele preencher o nome do usuário válido");
            Console.WriteLine("E: Clicar em [Entrar]");
            Console.WriteLine("E: Inserir a senha correta");
            Console.WriteLine("E: Clicar novamente em [Entrar]");
            Console.WriteLine("Então: O sistema deverá permitir o acesso do usuário com sucesso");
            Console.WriteLine("");

            LoginSteps.RealizaLoginComSucesso(usuario, senha);
        }

        [TestMethod]
        [TestCategory("LoginSenhaInvalida")]
        public void ValidarLoginComSenhaInvalida()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("Quando: Ele preencher o nome do usuário válido");
            Console.WriteLine("E: Clicar em [Entrar]");
            Console.WriteLine("E: Inserir uma senha incorreta");
            Console.WriteLine("E: Clicar novamente em [Entrar]");
            Console.WriteLine("Então: O sistema deverá exibir uma mensagem informando que os dados estão incorretos");
            Console.WriteLine("");

            LoginSteps.TentativaDeLoginComSenhaInvalida(usuario, "senhaInvalida");
        }

        [TestMethod]
        [TestCategory("LoginUsuarioNulo")]
        public void ValidarLoginComNomeDeUsuarioNulo()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("Quando: Ele deixar vazio o nome do usuário");
            Console.WriteLine("E: Clicar em [Entrar]");
            Console.WriteLine("Então: O sistema deverá exibir uma mensagem informando que os dados estão incorretos");
            Console.WriteLine("");

            LoginSteps.TentativaDeLoginComUsuarioNulo(" ");
        }
    }
}
