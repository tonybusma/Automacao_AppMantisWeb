using OpenQA.Selenium;

namespace Automacao_AppMantisWeb.Page
{
    public static class VerTarefasPage
    {
        // Elementos da tela 'Ver Tarefas'
        public static By IdTarefa() { return By.XPath("//td[@class='column-id']//a"); }
        public static By IdEspecificoTarefa(string id) { return By.XPath($"//td[@class='column-id']//a[contains(text(), '{id}')]"); }
        public static By IdBug() { return By.XPath("//td[@class='bug-id']"); }
        public static By FiltroAtribuidoA() { return By.Id("handler_id_filter_target"); }
        public static By FiltroRelator() { return By.Id("reporter_id_filter_target"); }

        // Elementos da tela 'Ver Detalhes da Tarefa'
        public static By TituloVerDetalhesDaTarefa() { return By.XPath("//h4[contains(text(),'Ver Detalhes')]"); }
        public static By BotaoMonitorar() { return By.XPath("//input[@value='Monitorar']"); }
        public static By BotaoPararDeMonitorar() { return By.XPath("//input[@value='Parar de Monitorar']"); }
        public static By OpcaoMonitoradoPor() { return By.Id("user_monitor_filter_target"); }
    }
}
