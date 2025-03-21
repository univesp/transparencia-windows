using ExcelDataReader;
using System;
using System.IO;
using System.Windows.Forms;

namespace TransparenciaWindows.Services
{
    public class FacadeService
    {
        public static void Converter(string tipoArquivo, Stream dadosPlanilhaMensal, Stream dadosPlanilhaContabilidade)
        {
            IExcelDataReader planilhaParaConversao;
            IExcelDataReader planilhaContabilidade = null;

            var planilhaMensal = ExcelReaderFactory.CreateReader(dadosPlanilhaMensal);

            if (dadosPlanilhaContabilidade != null)
            {
                planilhaContabilidade = ExcelReaderFactory.CreateReader(dadosPlanilhaContabilidade);
                
                MesclagemService.CriarPlanilhaMesclada(planilhaMensal, planilhaContabilidade);

                var streamPlanilhaMesclada = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs\PlanilhaMesclada.xlsx"));
                planilhaParaConversao = ExcelReaderFactory.CreateReader(streamPlanilhaMesclada.BaseStream);                
            }
            else
            {
                planilhaParaConversao = planilhaMensal;
            }

            

            switch (tipoArquivo)
            {
                case "TXT do Portal da Transparência":
                    PortalService.ConverterParaTXT(planilhaParaConversao);
                    break;
                case "TXT do IAMSPE":
                    IamspeService.ConverterParaTXT(planilhaParaConversao);
                    break;
                case "XML de Cadastro de Verbas Remuneratórias (AUDESP)":
                    AudespService.ConverterParaXMLVerbas(planilhaParaConversao);
                    break;
                case "XML de Folha Ordinária (AUDESP)":
                    AudespService.ConverterParaXMLFolha(planilhaParaConversao);
                    break;
                case "XML de Pagamento da Folha Ordinária (AUDESP)":
                    AudespService.ConverterParaXMLPagamentoFolha(planilhaParaConversao);
                    break;
                case "XML de Resumo Mensal da Folha Ordinária (AUDESP)":
                    AudespService.ConverterParaXMLResumo(planilhaParaConversao);
                    break;
                default:
                    break;
            }

            planilhaMensal.Dispose();
            if (planilhaContabilidade != null) { planilhaContabilidade.Dispose(); }
            planilhaParaConversao.Dispose();            
        }
    }
}
