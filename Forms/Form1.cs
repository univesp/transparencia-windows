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
    public partial class Form1 : Form
    {
        private StreamReader _planilhaMensal;

        public Form1()
        {
            InitializeComponent();
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
                        MessageBox.Show("Planilha mensal carregada");
                    } 
                    catch (IOException ex)
                    {
                        MessageBox.Show("Erro ao abrir a planilha; verifique se ela não está aberta em sua máquina.");
                    }
                }
            }
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            if (_planilhaMensal != null)
            {
                PortalService.ConverterParaTXT(_planilhaMensal.BaseStream);                           
            }
            else
            {
                MessageBox.Show("Planilha mensal NÃO CARREGADA");
            }
        }
    }
}
