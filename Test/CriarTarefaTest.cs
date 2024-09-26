using Automacao_AppMantisWeb.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automacao_AppMantisWeb.Test
{
    [TestClass]
    [TestCategory("Criar Tarefa")]
    public class CriarTarefaTest : TestBase
    {
        [TestMethod]
        [TestCategory("CriarUmaTarefaComSucesso")]
        public void ValidarCriacaoDeUmaTarefaComSucesso()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar em [Criar Tarefa] no menu lateral");
            Console.WriteLine("E: Preencher corretamente o formulário da tarefa");
            Console.WriteLine("E: Clicar no botão [Criar nova tarefa]");
            Console.WriteLine("Então: O sistema deverá criar uma nova tarefa com sucesso");
            Console.WriteLine("");

            CriarTarefaSteps.CriarTarefaCompletaUnicaComSucesso(usuario, senha);
        }

        [TestMethod]
        [TestCategory("CriarMaisDeUmaTarefaComSucesso")]
        public void ValidarCriacaoDeMaisDeUmaTarefaComSucesso()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar em [Criar Tarefa] no menu lateral");
            Console.WriteLine("E: Preencher corretamente o formulário da tarefa");
            Console.WriteLine("E: Marcar o checkbox [Continuar Relatando]");
            Console.WriteLine("E: Clicar no botão [Criar nova tarefa]");
            Console.WriteLine("E: Preencher outro formulário de uma nova tarefa");
            Console.WriteLine("E: Desmarcar o checkbox [Continuar Relatando]");
            Console.WriteLine("E: Clicar no botão [Criar nova tarefa]");
            Console.WriteLine("Então: O sistema deverá criar as novas tarefas com sucesso");
            Console.WriteLine("");

            CriarTarefaSteps.CriarMaisDeUmaTarefaComSucesso(usuario, senha);
        }

        [TestMethod]
        [TestCategory("CampoCategoriaObrigatorio")]
        public void ValidarObrigatoriedadeDoCampoCategoria()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar em [Criar Tarefa] no menu lateral");
            Console.WriteLine("E: Preencher corretamente o formulário da tarefa, deixando vazio o campo 'Categoria'");
            Console.WriteLine("E: Clicar no botão [Criar nova tarefa]");
            Console.WriteLine("Então: O sistema deverá exibir uma mensagem de erro na aplicação");
            Console.WriteLine("E: Não deverá gerar uma nova tarefa");
            Console.WriteLine("");

            CriarTarefaSteps.EnviarCampoCategoriaVazio(usuario, senha);
        }
    }
}
