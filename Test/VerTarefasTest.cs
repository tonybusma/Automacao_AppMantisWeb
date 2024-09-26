using Automacao_AppMantisWeb.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Automacao_AppMantisWeb.Test
{
    [TestClass]
    [TestCategory("Visualizar Tarefas")]
    public class VerTarefasTest : TestBase
    {
        [TestMethod]
        [TestCategory("SelecionarEVisualizarTarefa")]
        public void ValidarVisualizacaoDeTarefaSelecionada()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar em [Ver tarefas] no menu lateral");
            Console.WriteLine("E: Clicar no ID para selecionar uma tarefa");
            Console.WriteLine("Então: O sistema deverá exibir com sucesso os detalhes da tarefa selecionada");
            Console.WriteLine("");

            VerTarefasSteps.SelecionarEVisualizarTarefa(usuario, senha);
        }

        [TestMethod]
        [TestCategory("BuscarTarefaPeloId")]
        public void ValidarConsultaDeTarefaPeloId()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele inserir o ID da tarefa no filtro no canto superior direito da tela");
            Console.WriteLine("E: Pressionar a tecla [Enter]");
            Console.WriteLine("Então: O sistema deverá exibir os detalhes da tarefa com o ID pesquisado");
            Console.WriteLine("");

            VerTarefasSteps.BuscarTarefaPeloId(usuario, senha);
        }

        [TestMethod]
        [TestCategory("FiltrarTarefasNaoAtribuidas")]
        public void ValidarFiltroDeTarefasNaoAtribuidas()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar no título [Não Atribuídas]");
            Console.WriteLine("Então: O sistema deverá exibir na tela as tarefa que não possuem atribuição");
            Console.WriteLine("");

            VerTarefasSteps.FiltrarTarefasNaoAtribuidas(usuario, senha);
        }

        [TestMethod]
        [TestCategory("FiltrarTarefasRelatadasPorMim")]
        public void ValidarFiltroDeTarefasRelatadasPorMim()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar no título [Relatadas por Mim]");
            Console.WriteLine("Então: O sistema deverá exibir na tela as tarefa que foram relatadas pelo usuário 'Luis_Menezes'");
            Console.WriteLine("");

            VerTarefasSteps.FiltrarTarefasRelatadasPorMim(usuario, senha);
        }

        [TestMethod]
        [TestCategory("AtivarMonitoramentoDaTarefa")]
        public void ValidarAtivacaoDoMonitoramentoDaTarefa()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar em [Ver tarefas] no menu lateral");
            Console.WriteLine("E: Clicar no ID para selecionar uma tarefa");
            Console.WriteLine("E: Clicar no botão [Monitorar]");
            Console.WriteLine("E: Clicar em [Minha Visão] no menu");
            Console.WriteLine("E: Clicar no título [Monitorados por Mim]");
            Console.WriteLine("Então: O sistema deverá exibir com sucesso a tarefa monitorada");
            Console.WriteLine("");

            VerTarefasSteps.AtivarMonitoramentoDaTarefa(usuario, senha);
        }

        [TestMethod]
        [TestCategory("DesativarMonitoramentoDaTarefa")]
        public void ValidarDesativacaoDoMonitoramentoDaTarefa()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar no título [Monitorados por Mim]");
            Console.WriteLine("E: Clicar no ID para selecionar uma tarefa");
            Console.WriteLine("E: Clicar no botão [Parar de Monitorar]");
            Console.WriteLine("E: Clicar em [Minha Visão] no menu");
            Console.WriteLine("E: Clicar novamente no título [Monitorados por Mim]");
            Console.WriteLine("Então: O sistema não deverá exibir mais a tarefa a qual era monitorada");
            Console.WriteLine("");

            VerTarefasSteps.DesativarMonitoramentoDaTarefa(usuario, senha);
        }

        [TestMethod]
        [TestCategory("AdicionarAnotacaoNaTarefa")]
        public void ValidarAdicaoDeAnotacaoNaTarefa()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar em [Ver tarefas] no menu lateral");
            Console.WriteLine("E: Clicar no ID para selecionar uma tarefa");
            Console.WriteLine("E: Digitar uma anotação");
            Console.WriteLine("E: Clicar em [Adicionar anotação]");
            Console.WriteLine("Então: O sistema deverá gravar com sucesso a anotação na tarefa selecionada");
            Console.WriteLine("");

            VerTarefasSteps.AdicionarAnotacaoNaTarefa(usuario, senha);
        }

        [TestMethod]
        [TestCategory("RegistrarAcaoNoHistoricoDaTarefa")]
        public void ValidarRegistroNoHistoricoDaTarefa()
        {
            Console.WriteLine("Dado: Que o usuário acessa o site do Mantis");
            Console.WriteLine("E: Efetua o login com sucesso");
            Console.WriteLine("Quando: Ele clicar em [Ver tarefas] no menu lateral");
            Console.WriteLine("E: Clicar no ID para selecionar uma tarefa");
            Console.WriteLine("E: Digitar uma anotação");
            Console.WriteLine("E: Clicar em [Adicionar anotação]");
            Console.WriteLine("Então: O sistema deverá salvar o registro da gravação da anotação no histórico da tarefa");
            Console.WriteLine("");

            VerTarefasSteps.RegistrarAcaoNoHistoricoDaTarefa(usuario, senha);
        }

    }
}
