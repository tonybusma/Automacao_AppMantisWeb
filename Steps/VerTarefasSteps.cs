using Automacao_AppMantisWeb.Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Automacao_AppMantisWeb.Steps
{
    public class VerTarefasSteps : TestBase
    {
        #region Métodos Genéricos

        public static void SelecionarOpcaoVerTarefas()
        {
            PausaImplicita(10);
            ClicarNoElemento(MenuPage.MenuVerTarefas());
        }

        public static void AdicionarAnotacao(string texto)
        {
            Digitar(VerTarefasPage.CampoAnotacao(), texto);
            ClicarNoElemento(VerTarefasPage.BotaoAdicionarAnotacao());
        }

        #endregion Métodos Genéricos

        public static void SelecionarEVisualizarTarefa(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            SelecionarOpcaoVerTarefas();

            PausaImplicita(10);
            string idTarefa = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
            ClicarNoElemento(VerTarefasPage.IdTarefa());

            PausaImplicita(15);
            string idBug = Driver.FindElement(VerTarefasPage.IdBug()).Text;
            Assert.IsTrue(ElementoVisivel(VerTarefasPage.TituloVerDetalhesDaTarefa()));
            Assert.AreEqual(idTarefa, idBug);
        }

        public static void BuscarTarefaPeloId(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            string id = Driver.FindElement(MinhaVisaoPage.IdTarefaTelaPrincipal()).Text;
            Digitar(MinhaVisaoPage.FiltroBugsId(), id);
            Digitar(MinhaVisaoPage.FiltroBugsId(), Keys.Enter);

            PausaImplicita(15);
            string idBug = Driver.FindElement(VerTarefasPage.IdBug()).Text;
            Assert.IsTrue(ElementoVisivel(VerTarefasPage.TituloVerDetalhesDaTarefa()));
            Assert.AreEqual(id, idBug);
        }

        public static void FiltrarTarefasNaoAtribuidas(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            ClicarNoElemento(MinhaVisaoPage.FiltroBugsNaoAtribuidos());

            PausaImplicita(10);
            string valorCampoAtribuidoA = Driver.FindElement(VerTarefasPage.FiltroAtribuidoA()).Text;
            Assert.AreEqual("nenhum", valorCampoAtribuidoA);
        }

        public static void FiltrarTarefasRelatadasPorMim(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            ClicarNoElemento(MinhaVisaoPage.FiltroBugsRelatadosPorMim());

            PausaImplicita(10);
            string valorCampoRelator = Driver.FindElement(VerTarefasPage.FiltroRelator()).Text;
            Assert.AreEqual("Luis_Menezes", valorCampoRelator);
        }

        public static void AtivarMonitoramentoDaTarefa(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            SelecionarOpcaoVerTarefas();

            PausaImplicita(10);
            string idTarefa = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
            ClicarNoElemento(VerTarefasPage.IdTarefa());

            try
            {
                PausaImplicita(10);
                ClicarNoElemento(VerTarefasPage.BotaoMonitorar());
            }
            catch
            {
                ClicarNoElemento(VerTarefasPage.BotaoPararDeMonitorar());
                PausaForcada(3);
                ClicarNoElemento(VerTarefasPage.BotaoMonitorar());
            }

            PausaForcada(3);
            ClicarNoElemento(MenuPage.MenuMinhaVisao());

            PausaImplicita(10);
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsMonitoradosPorMim());

            PausaImplicita(15);
            string idTarefaMonitorada = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
            string usuarioMonitor = Driver.FindElement(VerTarefasPage.OpcaoMonitoradoPor()).Text;
            Assert.AreEqual(idTarefa, idTarefaMonitorada);
            Assert.AreEqual("Luis_Menezes", usuarioMonitor);
        }

        public static void DesativarMonitoramentoDaTarefa(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            PausaImplicita(10);
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsMonitoradosPorMim());

            string idTarefa;
            try
            {
                PausaImplicita(10);
                idTarefa = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
                ClicarNoElemento(VerTarefasPage.IdTarefa());
            }
            catch
            {
                SelecionarOpcaoVerTarefas();
                PausaImplicita(10);
                ClicarNoElemento(VerTarefasPage.IdTarefa());
                PausaImplicita(10);
                ClicarNoElemento(VerTarefasPage.BotaoMonitorar());
                PausaForcada(2);
                ClicarNoElemento(MenuPage.MenuMinhaVisao());
                PausaImplicita(10);
                ClicarNoElemento(MinhaVisaoPage.FiltroBugsMonitoradosPorMim());
                PausaImplicita(10);
                idTarefa = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
                ClicarNoElemento(VerTarefasPage.IdTarefa());
            }

            PausaImplicita(10);
            ClicarNoElemento(VerTarefasPage.BotaoPararDeMonitorar());

            PausaForcada(2); ;
            ClicarNoElemento(MenuPage.MenuMinhaVisao());
            PausaImplicita(10);
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsMonitoradosPorMim());

            PausaImplicita(15);
            string usuarioMonitor = Driver.FindElement(VerTarefasPage.OpcaoMonitoradoPor()).Text;
            Assert.IsFalse(ElementoVisivel(VerTarefasPage.IdEspecificoTarefa(idTarefa)));
            Assert.AreEqual("Luis_Menezes", usuarioMonitor);
        }

        public static void AdicionarAnotacaoNaTarefa(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            SelecionarOpcaoVerTarefas();

            PausaImplicita(10);
            ClicarNoElemento(VerTarefasPage.IdTarefa());

            string anotacao = "Anotação Teste";
            AdicionarAnotacao(anotacao);

            PausaImplicita(15);
            Assert.IsTrue(ElementoVisivel(VerTarefasPage.Anotacao(anotacao)));
        }

        public static void RegistrarAcaoNoHistoricoDaTarefa(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            SelecionarOpcaoVerTarefas();

            PausaImplicita(10);
            ClicarNoElemento(VerTarefasPage.IdTarefa());

            string anotacao = "Anotação de registro no histórico";
            AdicionarAnotacao(anotacao);

            DateTime data = DateTime.Now;
            string dataAtual = data.ToString("yyyy-MM-dd HH:mm");
            PausaImplicita(15);
            Assert.IsTrue(ElementoVisivel(VerTarefasPage.Anotacao(dataAtual)));
        }
    }
}
