using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransparenciaWindows.Services;

namespace TransparenciaWindows
{
    public partial class frmAplicacao : Form
    {
        private StreamReader _planilhaMensal;
        private StreamReader _planilhaContabilidade;

        public frmAplicacao()
        {
            InitializeComponent();
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
                        MessageBox.Show("Planilha mensal carregada");
                    } 
                    catch (IOException ex)
                    {
                        MessageBox.Show("Erro ao carregar a planilha; verifique se ela não está aberta em seu computador.");
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
                        MessageBox.Show("Planilha da contabilidade carregada");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Erro ao carregar a planilha; verifique se ela não está aberta em seu computador.");
                    }
                }
            }
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            var opcaoEscolhida = cbxTipoArquivo.SelectedItem;
            if (opcaoEscolhida == null)
            {
                MessageBox.Show("Selecione o tipo de arquivo a ser gerado");
            } else
            {
                if (_planilhaMensal != null)
                {
                    FacadeService.Converter(opcaoEscolhida.ToString(), _planilhaMensal);
                } else
                {
                    MessageBox.Show("Planilha mensal NÃO CARREGADA");
                }
            };
        }       
    }
}
