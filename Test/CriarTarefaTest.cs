using Automacao_AppMantisWeb.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            CriarTarefaSteps.CriarTarefaCompletaUnicaComSucesso(usuario, senha);
        }

        [TestMethod]
        [TestCategory("CriarMaisDeUmaTarefaComSucesso")]
        public void ValidarCriacaoDeMaisDeUmaTarefaComSucesso()
        {
            CriarTarefaSteps.CriarMaisDeUmaTarefaComSucesso(usuario, senha);
        }

        [TestMethod]
        [TestCategory("CriarMaisDeUmaTarefaComSucesso")]
        public void ValidarObrigatoriedadeDoCampoCategoria()
        {
            CriarTarefaSteps.EnviarCampoCategoriaVazio(usuario, senha);
        }
    }
}
