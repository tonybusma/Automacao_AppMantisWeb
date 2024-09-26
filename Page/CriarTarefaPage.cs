using OpenQA.Selenium;

namespace Automacao_AppMantisWeb.Page
{
    public static class CriarTarefaPage
    {
        public static By CampoCategoria() { return By.Id("category_id"); }
        public static By CampoFrequencia() { return By.Id("reproducibility"); }
        public static By CampoGravidade() { return By.Id("severity"); }
        public static By CampoPrioridade() { return By.Id("priority"); }
        public static By OpcoesDeSistema() { return By.XPath("//*[@title='+']"); }
        public static By CampoPlataforma() { return By.Id("platform"); }
        public static By CampoSistemaOperacional() { return By.Id("os"); }
        public static By CampoVersaoSO() { return By.Id("os_build"); }
        public static By CampoResumo() { return By.Id("summary"); }
        public static By CampoDescricao() { return By.Id("description"); }
        public static By CampoPassos() { return By.Id("steps_to_reproduce"); }
        public static By CampoInformacoes() { return By.Id("additional_info"); }
        public static By CampoMarcadores() { return By.Id("tag_string"); }
        public static By CampoEnviarArquivo() { return By.XPath("//input[@name='max_file_size']"); }
        public static By CampoContinuarReport() { return By.XPath("//span[contains(text(), 'selecione para criar')]"); }
        public static By BotaoCriarNovaTarefa() { return By.XPath("//input[@value='Criar Nova Tarefa']"); }
        public static By DataAberturaTarefa() { return By.XPath("//td[@class='bug-date-submitted']"); }
        public static By MensagemErroNaAplicacao() { return By.XPath("//p[contains(text(), 'APPLICATION ERROR')]"); }

    }
}
