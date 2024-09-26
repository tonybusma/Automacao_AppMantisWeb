using Automacao_AppMantisWeb.Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

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

        #endregion Métodos Genéricos

        public static void SelecionarEVisualizarTarefa(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Seleciona a opção 'Ver Tarefas' no menu lateral
            SelecionarOpcaoVerTarefas();

            // Armazena na variável o número do ID da tarefa e clica nela para visualizar
            PausaImplicita(10);
            string idTarefa = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
            ClicarNoElemento(VerTarefasPage.IdTarefa());

            // Valida o título da tela de detalhes da tarefa e o ID
            PausaImplicita(15);
            string idBug = Driver.FindElement(VerTarefasPage.IdBug()).Text;
            Assert.IsTrue(ElementoVisivel(VerTarefasPage.TituloVerDetalhesDaTarefa()));
            Assert.AreEqual(idTarefa, idBug);
        }

        public static void BuscarTarefaPeloId(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Pegar o número do ID de uma tarefa, inserir no campo do filtro e pesquisar
            string id = Driver.FindElement(MinhaVisaoPage.IdTarefaTelaPrincipal()).Text;
            Digitar(MinhaVisaoPage.FiltroBugsId(), id);
            Digitar(MinhaVisaoPage.FiltroBugsId(), Keys.Enter);

            // Valida o título da tela de detalhes da tarefa e o ID
            PausaImplicita(15);
            string idBug = Driver.FindElement(VerTarefasPage.IdBug()).Text;
            Assert.IsTrue(ElementoVisivel(VerTarefasPage.TituloVerDetalhesDaTarefa()));
            Assert.AreEqual(id, idBug);
        }

        public static void FiltrarTarefasNaoAtribuidas(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Seleciona a opção 'Não Atribuídos' na tela principal
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsNaoAtribuidos());

            // Valida se o valor do campo 'Atribuído A' é igual a 'nenhum'
            PausaImplicita(10);
            string valorCampoAtribuidoA = Driver.FindElement(VerTarefasPage.FiltroAtribuidoA()).Text;
            Assert.AreEqual("nenhum", valorCampoAtribuidoA);
        }

        public static void FiltrarTarefasRelatadasPorMim(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Seleciona a opção 'Relatados por Mim' na tela principal
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsRelatadosPorMim());

            // Valida se o valor do campo 'Relator' é igual a 'Luis_Menezes'
            PausaImplicita(10);
            string valorCampoRelator = Driver.FindElement(VerTarefasPage.FiltroRelator()).Text;
            Assert.AreEqual("Luis_Menezes", valorCampoRelator);
        }

        public static void AtivarMonitoramentoDaTarefa(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Seleciona a opção 'Ver Tarefas' no menu lateral
            SelecionarOpcaoVerTarefas();

            // Armazena na variável o número do ID da tarefa e clica nela para visualizar
            PausaImplicita(10);
            string idTarefa = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
            ClicarNoElemento(VerTarefasPage.IdTarefa());

            // Clica no botão 'Monitorar'. Caso já esteja ativado, desativa pra poder clicar novamente
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

            // Clica na opção 'Minha Visão' do menu lateral
            PausaForcada(3);
            ClicarNoElemento(MenuPage.MenuMinhaVisao());

            // Clica na opção 'Minha Visão' do menu lateral
            PausaImplicita(10);
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsMonitoradosPorMim());

            // Valida o filtro de tarefas monitoradas pelo ID e o nome do monitor
            PausaImplicita(15);
            string idTarefaMonitorada = Driver.FindElement(VerTarefasPage.IdTarefa()).Text;
            string usuarioMonitor = Driver.FindElement(VerTarefasPage.OpcaoMonitoradoPor()).Text;            
            Assert.AreEqual(idTarefa, idTarefaMonitorada);
            Assert.AreEqual("Luis_Menezes", usuarioMonitor);
        }

        public static void DesativarMonitoramentoDaTarefa(string usuario, string senha)
        {
            // Efetua login com sucesso
            LoginSteps.RealizaLoginComSucesso(usuario, senha);

            // Clica na opção 'Monitorados por Mim' 
            PausaImplicita(10);
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsMonitoradosPorMim());

            // Seleciona uma tarefa monitorada. Caso não tenha uma, realiza o fluxo de atiação do monitoramento da tarefa
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

            // Clica na opção 'Parar de Monitorar' 
            PausaImplicita(10);
            ClicarNoElemento(VerTarefasPage.BotaoPararDeMonitorar());

            // Clica na opção 'Minha Visão' do menu lateral e clica na opção 'Monitorados por Mim'
            PausaForcada(2); ;
            ClicarNoElemento(MenuPage.MenuMinhaVisao());
            PausaImplicita(10);
            ClicarNoElemento(MinhaVisaoPage.FiltroBugsMonitoradosPorMim());

            // Valida o filtro de tarefas monitoradas pelo nome do monitor e a ausência da tarefa não mais monitorada
            PausaImplicita(15);
            string usuarioMonitor = Driver.FindElement(VerTarefasPage.OpcaoMonitoradoPor()).Text;
            Assert.IsFalse(ElementoVisivel(VerTarefasPage.IdEspecificoTarefa(idTarefa)));
            Assert.AreEqual("Luis_Menezes", usuarioMonitor);
        }
    }
}
