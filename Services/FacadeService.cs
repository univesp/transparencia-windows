using ExcelDataReader;
using System.IO;

namespace TransparenciaWindows.Services
{
    public class FacadeService
    {
        public static void Converter(string tipoArquivo, Stream dadosPlanilhaMensal, Stream dadosPlanilhaContabilidade)
        {
            using (var planilhaMensal = ExcelReaderFactory.CreateReader(dadosPlanilhaMensal))
            {
                using (var planilhaContabilidade = ExcelReaderFactory.CreateReader(dadosPlanilhaContabilidade))
                {
                    MesclagemService.CriarPlanilhaMesclada(planilhaMensal, planilhaContabilidade);

                    switch (tipoArquivo)
                    {
                        case "TXT do Portal da Transparência":
                            PortalService.ConverterParaTXT(planilhaMensal);
                            break;
                        case "TXT do IAMSPE":
                            IamspeService.ConverterParaTXT(planilhaMensal);
                            break;
                        case "XML de Cadastro de Verbas Remuneratórias (AUDESP)":
                            AudespService.ConverterParaXMLVerbas(planilhaMensal);
                            break;
                        case "XML de Folha Ordinária (AUDESP)":
                            AudespService.ConverterParaXMLFolha(planilhaMensal);
                            break;
                        case "XML de Pagamento da Folha Ordinária (AUDESP)":
                            AudespService.ConverterParaXMLPagamentoFolha(planilhaMensal);
                            break;
                        case "XML de Resumo Mensal da Folha Ordinária (AUDESP)":
                            AudespService.ConverterParaXMLResumo(planilhaMensal);
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }
    }
}
