using System;
using System.IO;
using System.Windows.Forms;
using TransparenciaWindows.Services;

namespace TransparenciaWindows
{
    public partial class frmAplicacao : Form
    {
        private StreamReader _planilhaMensal;
        private StreamReader _planilhaContabilidade;
        private FacadeService.TiposArquivo _tipoArquivoEscolhido;

        public frmAplicacao()
        {
            InitializeComponent();
            pnlArquivosDownload.Visible = false;
            webCabecalho.DocumentText = @"
<html>
<head><link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css' crossorigin='anonymous' /></head>
                <body>    
<div class='py-5 text-center'>
                <img class='d-block mx-auto mb-4' src='https://apps.univesp.br/transparencia/logo-univesp.png' alt='' width='72' height='72'>
                    <h2>Transparência</h2>
                    <p class='lead'>
                      Solução para conversão dos dados de transparência nos formatos esperados
                      pelos integradores dos órgãos de controle, como os da PRODESP(Decreto nº
                      52.624, de 15/01/08, ou Portal da Transparência) e da AUDESP(TCE-SP).
                    </p>
                  </div>
</body>
</html>
                ";
        }

        private void btnCarregarPlanilhaMensal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _planilhaMensal = new StreamReader(dialogo.FileName);
                        lblCaminhoPlanilhaMensal.Text = dialogo.FileName;
                        MessageBox.Show("Planilha mensal carregada com sucesso", 
                                        "Informação", 
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Erro ao carregar a planilha; verifique se ela não está aberta em seu computador", 
                                        "Erro",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnCarregarPlanilhaContabil_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _planilhaContabilidade = new StreamReader(dialogo.FileName);
                        lblCaminhoPlanilhaContabil.Text = dialogo.FileName;
                        MessageBox.Show("Planilha da contabilidade carregada com sucesso",
                                        "Informação", 
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Erro ao carregar a planilha; verifique se ela não está aberta em seu computador",
                                        "Erro", 
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            var opcaoEscolhida = cbxTipoArquivo.SelectedItem;
            if (opcaoEscolhida == null)
            {
                MessageBox.Show("Selecione o tipo de arquivo a ser gerado",
                                "Atenção",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                switch (opcaoEscolhida.ToString())
                {
                    case "TXT do Portal da Transparência":
                        _tipoArquivoEscolhido = FacadeService.TiposArquivo.TXTPortal;
                        break;
                    case "TXT do IAMSPE":
                        _tipoArquivoEscolhido = FacadeService.TiposArquivo.TXTIamspe;
                        break;
                    case "XML de Cadastro de Verbas Remuneratórias (AUDESP)":
                        _tipoArquivoEscolhido = FacadeService.TiposArquivo.XMLVerbasAUDESP;
                        break;
                    case "XML de Folha Ordinária (AUDESP)":
                        _tipoArquivoEscolhido = FacadeService.TiposArquivo.XMLFolhaAUDESP;
                        break;
                    case "XML de Pagamento da Folha Ordinária (AUDESP)":
                        _tipoArquivoEscolhido = FacadeService.TiposArquivo.XMLPagamentoAUDESP;
                        break;
                    case "XML de Resumo Mensal da Folha Ordinária (AUDESP)":
                        _tipoArquivoEscolhido = FacadeService.TiposArquivo.XMLResumoAUDESP;
                        break;
                    default:
                        break;
                }

                if (_planilhaMensal != null)
                {
                    FacadeService.Converter(_tipoArquivoEscolhido,
                                            _planilhaMensal.BaseStream,
                                            _planilhaContabilidade != null ? _planilhaContabilidade.BaseStream : null);
                    pnlArquivosDownload.Visible = true;
                }
                else
                {
                    MessageBox.Show("A planilha mensal deve ser carregada", 
                                    "Atenção",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            };
        }
        private void lnkReiniciarAplicacao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void lnkArquivoGerado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FacadeService.BaixarArquivoGerado(_tipoArquivoEscolhido);
        }

        private void lnkPlanilhaMesclada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FacadeService.BaixarPlanilhaMesclada();
        }
    }
}
