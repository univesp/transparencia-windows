using System.IO;

namespace TransparenciaWindows.Services
{
    public class FacadeService
    {
        public static void Converter(string tipoArquivo, StreamReader planilhaMensal)
        {
            switch (tipoArquivo)
            {
                case "TXT do Portal da Transparência":
                    PortalService.ConverterParaTXT(planilhaMensal.BaseStream);
                    break;
                case "TXT do IAMSPE":
                    IamspeService.ConverterParaTXT(planilhaMensal.BaseStream);
                    break;
                case "XML de Cadastro de Verbas Remuneratórias (AUDESP)":
                    AudespService.ConverterParaXMLVerbas(planilhaMensal.BaseStream);
                    break;
                case "XML de Folha Ordinária (AUDESP)":
                    AudespService.ConverterParaXMLFolha(planilhaMensal.BaseStream);
                    break;
                case "XML de Pagamento da Folha Ordinária (AUDESP)":
                    AudespService.ConverterParaXMLPagamentoFolha(planilhaMensal.BaseStream);
                    break;
                case "XML de Resumo Mensal da Folha Ordinária (AUDESP)":
                    AudespService.ConverterParaXMLResumo(planilhaMensal.BaseStream);
                    break;
                default:
                    break;
            }
        }
    }
}
