using ClosedXML.Excel;
using System;
using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparenciaWindows.Services
{
    public class MesclagemService
    {
        public static void CriarPlanilhaMesclada(Stream dadosPlanilhaMensal)
        {
            string diretorioBaseSaida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");

            using (var workbook = new XLWorkbook())
            {
                

                using (var planilhaMensal = ExcelReaderFactory.CreateReader(dadosPlanilhaMensal))
                {

                    var ds = planilhaMensal.AsDataSet();

                    // Devem ser copiados integralmente, sem transformações:
                    // Header
                    CopiarAbaMensalParaMesclada(ds.Tables[0], workbook.Worksheets.Add("Header"));
                    // Detalhe - ENCARGOS SOCIAIS BEN
                    CopiarAbaMensalParaMesclada(ds.Tables[1], workbook.Worksheets.Add("Detalhe - ENCARGOS SOCIAIS BEN"));
                    // Detalhe - Tabela de CARGO  FUNÇ
                    CopiarAbaMensalParaMesclada(ds.Tables[4], workbook.Worksheets.Add("Detalhe - Tabela de CARGO  FUNÇ"));
                    // Detalhe - Tabela de VENCIMENTO
                    CopiarAbaMensalParaMesclada(ds.Tables[4], workbook.Worksheets.Add("Detalhe - Tabela de VENCIMENTO"));
                    // Detalhe - Tabela de FAIXA SALAR
                    CopiarAbaMensalParaMesclada(ds.Tables[5], workbook.Worksheets.Add("Detalhe - Tabela de FAIXA SALAR"));
                    // Detalhe - Tabela de UNIDADES AD
                    CopiarAbaMensalParaMesclada(ds.Tables[6], workbook.Worksheets.Add("Detalhe - Tabela de UNIDADES AD"));
                    // Tabelas auxiliares
                    CopiarAbaMensalParaMesclada(ds.Tables[7], workbook.Worksheets.Add("Tabelas auxiliares"));
                }

                workbook.SaveAs(Path.Combine(diretorioBaseSaida, "PlanilhaMesclada.xlsx"));
            }
        }

        private static void CopiarAbaMensalParaMesclada(DataTable abaPlanMensal, IXLWorksheet abaPlanMesclada)
        {
            for (int i = 0; i < abaPlanMensal.Rows.Count; i++)
            {
                DataRow registro = abaPlanMensal.Rows[i];
                for (int j = 0; j < registro.ItemArray.Length; j++)
                {                    
                    abaPlanMesclada.Cell(i + 1, j + 1).Value = $"{registro[j]}".Trim();
                }
            }
        }
    }
}
