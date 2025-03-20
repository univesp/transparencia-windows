using ClosedXML.Excel;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using static TransparenciaWindows.Services.ContabilidadeService;

namespace TransparenciaWindows.Services
{
    public class MesclagemService
    {
        public static void CriarPlanilhaMesclada(IExcelDataReader planilhaMensal, IExcelDataReader planilhaContabilidade)
        {
            string diretorioBaseSaida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");

            List<RegistroFinanceiro> salariosContabil = ContabilidadeService.ObterSalariosContabil(planilhaMensal, planilhaContabilidade);

            using (var planilhaMesclada = new XLWorkbook())
            {                
                var ds = planilhaMensal.AsDataSet();

                // Devem ser copiados integralmente, sem transformações:
                // Header
                CopiarAbaMensalParaMesclada(ds.Tables[0], planilhaMesclada.Worksheets.Add("Header"));
                // Detalhe - ENCARGOS SOCIAIS BEN
                CopiarAbaMensalParaMesclada(ds.Tables[1], planilhaMesclada.Worksheets.Add("Detalhe - ENCARGOS SOCIAIS BEN"));
                // Detalhe - Dados FINANCEIROS
                FormatarDadosFinanceirosParaMesclada(ds.Tables[3], salariosContabil, planilhaMesclada.Worksheets.Add("Detalhe - Dados FINANCEIROS"));
                // Detalhe - Tabela de CARGO  FUNÇ
                CopiarAbaMensalParaMesclada(ds.Tables[4], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de CARGO  FUNÇ"));
                // Detalhe - Tabela de VENCIMENTO
                CopiarAbaMensalParaMesclada(ds.Tables[4], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de VENCIMENTO"));
                // Detalhe - Tabela de FAIXA SALAR
                CopiarAbaMensalParaMesclada(ds.Tables[5], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de FAIXA SALAR"));
                // Detalhe - Tabela de UNIDADES AD
                CopiarAbaMensalParaMesclada(ds.Tables[6], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de UNIDADES AD"));
                // Tabelas auxiliares
                CopiarAbaMensalParaMesclada(ds.Tables[7], planilhaMesclada.Worksheets.Add("Tabelas auxiliares"));
  
                planilhaMesclada.SaveAs(Path.Combine(diretorioBaseSaida, "PlanilhaMesclada.xlsx"));
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

        private static void FormatarDadosFinanceirosParaMesclada(DataTable abaFinanceiro, 
                                                                 List<RegistroFinanceiro> salariosContabil, 
                                                                 IXLWorksheet abaPlanMesclada)
        {
            for (int i = 0; i < abaFinanceiro.Rows.Count; i++)
            {
                string[] colunas;

                DataRow registro = abaFinanceiro.Rows[i];

                // cópia das 10 primeiras colunas da planilha mensal para a mesclada
                for (int j = 0; j <= 10; j++)
                {
                    abaPlanMesclada.Cell(i + 1, j + 1).Value = $"{registro[j]}".Trim();
                }

                // as colunas variáveis devem ir da 11 até o fim da aba
                int indexColunasVariaveis = 11;
                RegistroFinanceiro salario = salariosContabil.Find(s => $"{s.Codigo}".Trim() == $"{registro[1]}".Trim());
                for (int j = 0; j < salario.Verbas.Count; j++)
                {
                    Verba verba = salario.Verbas[j];

                    // os valores da planilha original não podem ter ponto ou vírgula
                    string valor = verba.Valor.Replace(".", "").Replace(",", "").Trim();
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis).Value = salario.Codigo;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 1).Value = valor;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 2).Value = verba.Indicacao;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 3).Value = verba.DoMes;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 4).Value = verba.Fve;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 5).Value = verba.Audesp;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 6).Value = "";
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 7).Value = "";               

                    // incremento para o grupo de 8 colunas de informação financeira por verba
                    indexColunasVariaveis += 8;
                }              
            }
        }
    }
}
