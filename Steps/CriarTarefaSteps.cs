using Automacao_AppMantisWeb.Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Automacao_AppMantisWeb.Steps
{
    public class CriarTarefaSteps : TestBase
    {
        #region Métodos Genéricos

        public static void SelecionarOpcaoCriarTarefa()
        {
            PausaImplicita(10);
            ClicarNoElemento(MenuPage.MenuCriarTarefa());
        }

        public static void PreencherDadosDoSistema(string plataforma, string so, string versao)
        {
            try
            {
                PausaImplicita(3);
                ClicarNoElemento(CriarTarefaPage.OpcoesDeSistema());
            }
            catch { PausaForcada(1); }
            Digitar(CriarTarefaPage.CampoPlataforma(), plataforma);
            Digitar(CriarTarefaPage.CampoSistemaOperacional(), so);
            Digitar(CriarTarefaPage.CampoVersaoSO(), versao);
        }

        public static void PreencherCampoPassosParaReproduzir()
        {
            for (int i = 1; i <= 7; i++)
            {
                Digitar(CriarTarefaPage.CampoPassos(), $"- Teste {i}");
                Digitar(CriarTarefaPage.CampoPassos(), Keys.Enter);
            }

        }

        public static void PreencherFormularioDaTarefa(string categoria, string resumo, string descricao)
        {
            SelecionarOpcaoPeloValor(CriarTarefaPage.CampoCategoria(), categoria);
            SelecionarOpcaoPeloValor(CriarTarefaPage.CampoFrequencia(), "10");
            SelecionarOpcaoPeloValor(CriarTarefaPage.CampoGravidade(), "10");
            SelecionarOpcaoPeloValor(CriarTarefaPage.CampoPrioridade(), "30");
            PreencherDadosDoSistema("Mobile", "Android", "18.0");
            Digitar(CriarTarefaPage.CampoResumo(), resumo);
            Digitar(CriarTarefaPage.CampoDescricao(), descricao);
            PreencherCampoPassosParaReproduzir();
            Digitar(CriarTarefaPage.CampoInformacoes(), "Sem informações");
            Digitar(CriarTarefaPage.CampoMarcadores(), "teste1");
        }

        public static void MarcarOpcaoContinuarRelatando()
        {
            PausaImplicita(10);
            ClicarNoElemento(CriarTarefaPage.CampoContinuarReport());
        }

        #endregion Métodos Genéricos

        public static void CriarTarefaCompletaUnicaComSucesso(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);
            SelecionarOpcaoCriarTarefa();
            PreencherFormularioDaTarefa("2", "Geração de Teste", "Teste");
            CarregarImagem(CriarTarefaPage.CampoEnviarArquivo());
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());

            DateTime data = DateTime.Now;
            string dataAtual = data.ToString("yyyy-MM-dd HH:mm");
            PausaImplicita(20);
            string dataTarefa = Driver.FindElement(CriarTarefaPage.DataAberturaTarefa()).Text;
            Assert.AreEqual(dataAtual, dataTarefa);
        }

        public static void CriarMaisDeUmaTarefaComSucesso(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);
            SelecionarOpcaoCriarTarefa();
            PreencherFormularioDaTarefa("2", "Geração de Teste", "Teste");

            CarregarImagem(CriarTarefaPage.CampoEnviarArquivo());

            ClicarNoElemento(CriarTarefaPage.CampoContinuarReport());
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());

            PausaImplicita(15);
            PreencherFormularioDaTarefa("2", "Geração de Teste Dois", "Teste Dois");

            ClicarNoElemento(CriarTarefaPage.CampoContinuarReport());
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());

            DateTime data = DateTime.Now;
            string dataAtual = data.ToString("yyyy-MM-dd HH:mm");
            PausaImplicita(20);
            string dataTarefa = Driver.FindElement(CriarTarefaPage.DataAberturaTarefa()).Text;
            Assert.AreEqual(dataAtual, dataTarefa);
        }

        public static void EnviarCampoCategoriaVazio(string usuario, string senha)
        {
            LoginSteps.RealizaLoginComSucesso(usuario, senha);
            SelecionarOpcaoCriarTarefa();
            PreencherFormularioDaTarefa("0", "Geração de Teste", "Teste");
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());
            Assert.IsTrue(ElementoVisivel(CriarTarefaPage.MensagemErroNaAplicacao()));
        }

    }
}
