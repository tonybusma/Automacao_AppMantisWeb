using OpenQA.Selenium;

namespace Automacao_AppMantisWeb.Page
{
    public static class MenuPage
    {
        public static By NomeDaContaDeUsuario() { return By.XPath("//span[@class='user-info']"); }
        public static By MenuCriarTarefa() { return By.XPath("//span[contains(text(), 'Criar Tarefa')]"); }
        public static By MenuVerTarefas() { return By.XPath("//span[contains(text(), 'Ver Tarefas')]"); }
        public static By MenuMinhaVisao() { return By.XPath("//span[contains(text(), 'Minha Visão')]"); }
    }
}
