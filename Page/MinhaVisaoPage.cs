using OpenQA.Selenium;

namespace Automacao_AppMantisWeb.Page
{
    public static class MinhaVisaoPage
    {
        public static By FiltroBugsId() { return By.Name("bug_id"); }
        public static By FiltroBugsRelatadosPorMim() { return By.XPath("//a[contains(text(),'Relatados por Mim')]"); }
        public static By FiltroBugsNaoAtribuidos() { return By.XPath("//a[contains(text(),'Não Atribuídos')]"); }
        public static By FiltroBugsResolvidos() { return By.XPath("//a[contains(text(),'Resolvidos')]"); }
        public static By FiltroBugsModificadosRecentemente() { return By.XPath("//a[contains(text(),'Modificados Recentemente')]"); }
        public static By FiltroBugsMonitoradosPorMim() { return By.XPath("//a[contains(text(),'Monitorados por Mim')]"); }
        public static By IdTarefaTelaPrincipal() { return By.XPath("//tr[@class='my-buglist-bug ']//a"); }
    }
}
