using Automacao_AppMantisWeb.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            VerTarefasSteps.SelecionarEVisualizarTarefa(usuario, senha);
        }

        [TestMethod]
        [TestCategory("BuscarTarefaPeloId")]
        public void ValidarConsultaDeTarefaPeloId()
        {
            VerTarefasSteps.BuscarTarefaPeloId(usuario, senha);
        }

        [TestMethod]
        [TestCategory("FiltrarTarefasNaoAtribuidas")]
        public void ValidarFiltroDeTarefasNaoAtribuidas()
        {
            VerTarefasSteps.FiltrarTarefasNaoAtribuidas(usuario, senha);
        }

        [TestMethod]
        [TestCategory("FiltrarTarefasRelatadasPorMim")]
        public void ValidarFiltroDeTarefasRelatadasPorMim()
        {
            VerTarefasSteps.FiltrarTarefasRelatadasPorMim(usuario, senha);
        }

        [TestMethod]
        [TestCategory("AtivarMonitoramentoDaTarefa")]
        public void ValidarAtivacaoDoMonitoramentoDaTarefa()
        {
            VerTarefasSteps.AtivarMonitoramentoDaTarefa(usuario, senha);
        }

        [TestMethod]
        [TestCategory("DesativarMonitoramentoDaTarefa")]
        public void ValidarDesativacaoDoMonitoramentoDaTarefa()
        {
            VerTarefasSteps.DesativarMonitoramentoDaTarefa(usuario, senha);
        }

    }
}
