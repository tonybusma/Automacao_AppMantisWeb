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
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Seleciona a opção 'Criar Tarefa' no menu lateral
            SelecionarOpcaoCriarTarefa();

            // Preenche todo o formulário com as informações da tarefa
            PreencherFormularioDaTarefa("2", "Geração de Teste", "Teste");

            //  Insere a imagem de evidência
            CarregarImagem(CriarTarefaPage.CampoEnviarArquivo());

            // Clica no botão para criar a nova tarefa
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());

            // Pega a data e hora no momento da criação da tarefa e valida com a data e hora exibida nos detalhes da tarefa
            DateTime data = DateTime.Now;
            string dataAtual = data.ToString("yyyy-MM-dd HH:mm");
            PausaImplicita(20);
            string dataTarefa = Driver.FindElement(CriarTarefaPage.DataAberturaTarefa()).Text;
            Assert.AreEqual(dataAtual, dataTarefa);
        }

        public static void CriarMaisDeUmaTarefaComSucesso(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Seleciona a opção 'Criar Tarefa' no menu lateral
            SelecionarOpcaoCriarTarefa();

            // Preenche todo o formulário com as informações da tarefa
            PreencherFormularioDaTarefa("2", "Geração de Teste", "Teste");

            //  Insere a imagem de evidência
            CarregarImagem(CriarTarefaPage.CampoEnviarArquivo());

            // Clica para marcar o ckeckbox 'Continuar relatando'
            ClicarNoElemento(CriarTarefaPage.CampoContinuarReport());

            // Clica no botão para criar a nova tarefa
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());

            // Preenche todo o formulário com as informações da tarefa
            PausaImplicita(15);
            PreencherFormularioDaTarefa("2", "Geração de Teste Dois", "Teste Dois");

            // Clica para desmarcar o ckeckbox 'Continuar relatando'
            ClicarNoElemento(CriarTarefaPage.CampoContinuarReport());

            // Clica no botão para criar a nova tarefa
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());

            // Pega a data e hora no momento da criação da tarefa e valida com a data e hora exibida nos detalhes da tarefa
            DateTime data = DateTime.Now;
            string dataAtual = data.ToString("yyyy-MM-dd HH:mm");
            PausaImplicita(20);
            string dataTarefa = Driver.FindElement(CriarTarefaPage.DataAberturaTarefa()).Text;
            Assert.AreEqual(dataAtual, dataTarefa);
        }

        public static void EnviarCampoCategoriaVazio(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Seleciona a opção 'Criar Tarefa' no menu lateral
            SelecionarOpcaoCriarTarefa();

            // Preenche o formulário com as informações da tarefa, passando o valor '0' no campo 'Categoria'
            PreencherFormularioDaTarefa("0", "Geração de Teste", "Teste");

            // Clica no botão para criar a nova tarefa
            ClicarNoElemento(CriarTarefaPage.BotaoCriarNovaTarefa());

            // Valida exibição da mensagem de erro na aplicação
            Assert.IsTrue(ElementoVisivel(CriarTarefaPage.MensagemErroNaAplicacao()));
        }

    }
}
