using ExcelDataReader;
using System;
using System.IO;
using System.Windows.Forms;

namespace TransparenciaWindows.Services
{
    public class FacadeService
    {
        private static readonly string _diretorioBaseSaida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");

        public enum TiposArquivo
        {
            TXTPortal,
            TXTIamspe,
            XMLVerbasAUDESP,
            XMLFolhaAUDESP,
            XMLPagamentoAUDESP,
            XMLResumoAUDESP
        }

        public static void Converter(TiposArquivo tipoArquivo, Stream dadosPlanilhaMensal, Stream dadosPlanilhaContabilidade)
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
                case TiposArquivo.TXTPortal:
                    PortalService.ConverterParaTXT(planilhaParaConversao);
                    break;
                case TiposArquivo.TXTIamspe:
                    IamspeService.ConverterParaTXT(planilhaParaConversao);
                    break;
                case TiposArquivo.XMLVerbasAUDESP:
                    AudespService.ConverterParaXMLVerbas(planilhaParaConversao);
                    break;
                case TiposArquivo.XMLFolhaAUDESP:
                    AudespService.ConverterParaXMLFolha(planilhaParaConversao);
                    break;
                case TiposArquivo.XMLPagamentoAUDESP:
                    AudespService.ConverterParaXMLPagamentoFolha(planilhaParaConversao);
                    break;
                case TiposArquivo.XMLResumoAUDESP:
                    AudespService.ConverterParaXMLResumo(planilhaParaConversao);
                    break;
                default:
                    break;
            }

            planilhaMensal.Dispose();
            if (planilhaContabilidade != null) { planilhaContabilidade.Dispose(); }
            planilhaParaConversao.Dispose();            
        }
    
        public static void BaixarArquivoGerado(TiposArquivo tipoArquivo)
        {
            string nomeArquivo = "";
            string filtroArquivo = "";

            switch (tipoArquivo)
            {
                case TiposArquivo.TXTPortal:
                    nomeArquivo = "portal.txt";
                    filtroArquivo = "Text Files(*.txt)| *.txt | All Files(*.*) | *.* ";
                    break;
                case TiposArquivo.TXTIamspe:
                    nomeArquivo = "iamspe.txt";
                    filtroArquivo = "Text Files(*.txt)| *.txt | All Files(*.*) | *.* ";
                    break;
                case TiposArquivo.XMLVerbasAUDESP:
                    nomeArquivo = "AUDESPVerbas.xml";
                    filtroArquivo = "XML - File | *.xml";
                    break;
                case TiposArquivo.XMLFolhaAUDESP:
                    nomeArquivo = "AUDESPFolhaOrdinaria.xml";
                    filtroArquivo = "XML - File | *.xml";
                    break;
                case TiposArquivo.XMLPagamentoAUDESP:
                    nomeArquivo = "AUDESPPagamentoFolha.xml";
                    filtroArquivo = "XML - File | *.xml";
                    break;
                case TiposArquivo.XMLResumoAUDESP:
                    nomeArquivo = "AUDESPResumoMensal.xml";
                    filtroArquivo = "XML - File | *.xml";
                    break;
                default:
                    break;
            }

            string caminhoArquivo = Path.Combine(_diretorioBaseSaida, nomeArquivo);
            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("Não há arquivo para ser baixado", 
                                "Atenção", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
                return;
            }

            
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = filtroArquivo;
                dialogo.Title = "Salvar Como";
                dialogo.FileName = Path.GetFileName(caminhoArquivo);

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(caminhoArquivo, dialogo.FileName, true);
                        MessageBox.Show("Arquivo baixado com sucesso",
                                        "Informação",
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro: {ex.Message}",
                                        "Erro", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static void BaixarPlanilhaMesclada()
        {
            string caminhoArquivo = Path.Combine(_diretorioBaseSaida, "PlanilhaMesclada.xlsx");
            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("Não há arquivo para ser baixado", 
                                "Atenção", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Excel |*.xlsx";
                dialogo.Title = "Salvar Como";
                dialogo.FileName = Path.GetFileName(caminhoArquivo);

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(caminhoArquivo, dialogo.FileName, true);
                        MessageBox.Show("Arquivo baixado com sucesso",
                                        "Informação", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro: {ex.Message}", 
                                        "Erro", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
