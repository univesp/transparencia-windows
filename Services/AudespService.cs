using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransparenciaWindows.Services
{
    public class AudespService
    {
        public static void ConverterParaXMLFolha(Stream dadosPlanilha)
        {
            MessageBox.Show("Convertendo para XML - Folha ordinária");
        }

        public static void ConverterParaXMLPagamentoFolha(Stream dadosPlanilha)
        {
            MessageBox.Show("Convertendo para XML - Pagamento Folha");
        }

        public static void ConverterParaXMLResumo(Stream dadosPlanilha)
        {
            MessageBox.Show("Convertendo para XML - Resumo mensal");
        }

        public static void ConverterParaXMLVerbas(Stream dadosPlanilha)
        {
            MessageBox.Show("Convertendo para XML - Verbas");
        }
    }
}
