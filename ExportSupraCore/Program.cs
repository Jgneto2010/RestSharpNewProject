using ExportSupraCore.Services;
using System;
using System.IO;

namespace ExportSupraCore
{
    class Program
    {

        private static string _urlBase = "http://supra.dnit.gov.br/cgcont/dadosgerais/cgplan/";

        static void Main(string[] args)
        {
            ServiceRecuperarContrato();
            ServiceRecuperarLocalizacao();
            ServiceAvancoFisico();
            ServiceCronogramaFísico();
            ServiceCronogramaFinanceiro();
            ServiceAvancoFinanceiro();
            ServiceMedicao();
            ServiceEmpenho();
            ServiceIdfin();
            ServiceAditivo();
            Console.ReadKey();
        }

        public static void ServiceRecuperarContrato()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_contratos_ws");
            GerarArquivo(rest.Content, "RecuperarContrato");
        }

        public static void ServiceRecuperarLocalizacao()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_localizacao_ws");
            GerarArquivo(rest.Content, "RecuperarLocalizacao");
        }
        public static void ServiceAvancoFisico()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_cronograma_fisico_ws");
            GerarArquivo(rest.Content, "AvancoFisico");
        }
        public static void ServiceCronogramaFísico()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_cronograma_fisico_ws");
            GerarArquivo(rest.Content, "CronogramaFisico");
        }
        public static void ServiceCronogramaFinanceiro()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_cronograma_financeiro_ws");
            GerarArquivo(rest.Content, "CronogramaFinanceiro");
        }
        public static void ServiceAvancoFinanceiro()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_avanco_financeiro_ws");
            GerarArquivo(rest.Content, "AvancoFinanceiro");
        }
        public static void ServiceMedicao()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_medicao_ws");
            GerarArquivo(rest.Content, "Medição");
        }
        public static void ServiceEmpenho()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_empenho_ws");
            GerarArquivo(rest.Content, "Empenho");
        }
        public static void ServiceIdfin()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_idfin_ws");
            GerarArquivo(rest.Content, "Idfin");
        }
        public static void ServiceAditivo()
        {
            var rest = ConfigurationService.Configuration($"{_urlBase}recupera_aditivo_ws");
            GerarArquivo(rest.Content, "Aditivo");
        }

        public static void GerarArquivo(string jsonContent, string fileName)
        {
            var lines = ConverterJsonCsv.JsonToCSV(jsonContent);
            File.WriteAllLines($@"C:\Teste/{fileName}.csv", lines);
        }
    }
}

