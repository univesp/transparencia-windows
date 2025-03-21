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

            List<SalarioContabil> salariosContabil = ObterSalariosContabil(planilhaMensal, planilhaContabilidade);
            List<ValorContabil> valoresContabil = ObterVencimentosDescontosContabil(planilhaContabilidade);

            using (var planilhaMesclada = new XLWorkbook())
            {
                var ds = planilhaMensal.AsDataSet();

                // Devem ser copiados integralmente, sem transformações:
                // Header
                CopiarAbaMensalParaMesclada(ds.Tables[0], planilhaMesclada.Worksheets.Add("Header"));
                // Detalhe - ENCARGOS SOCIAIS BEN
                CopiarAbaMensalParaMesclada(ds.Tables[1], planilhaMesclada.Worksheets.Add("Detalhe - ENCARGOS SOCIAIS BEN"));
                // Detalhe - Dados PESSOAIS  FUNCI
                FormatarDadosPessoaisParaMesclada(ds.Tables[2], valoresContabil, planilhaMesclada.Worksheets.Add("Detalhe - Dados PESSOAIS  FUNCI"));
                // Detalhe - Dados FINANCEIROS
                FormatarDadosFinanceirosParaMesclada(ds.Tables[3], salariosContabil, planilhaMesclada.Worksheets.Add("Detalhe - Dados FINANCEIROS"));
                // Detalhe - Tabela de CARGO  FUNÇ
                CopiarAbaMensalParaMesclada(ds.Tables[4], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de CARGO  FUNÇ"));
                // Detalhe - Tabela de VENCIMENTO
                CopiarAbaMensalParaMesclada(ds.Tables[5], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de VENCIMENTO"));
                // Detalhe - Tabela de FAIXA SALAR
                CopiarAbaMensalParaMesclada(ds.Tables[6], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de FAIXA SALAR"));
                // Detalhe - Tabela de UNIDADES AD
                CopiarAbaMensalParaMesclada(ds.Tables[7], planilhaMesclada.Worksheets.Add("Detalhe - Tabela de UNIDADES AD"));
                // Tabelas auxiliares
                CopiarAbaMensalParaMesclada(ds.Tables[8], planilhaMesclada.Worksheets.Add("Tabelas auxiliares"));

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

        private static void FormatarDadosPessoaisParaMesclada(DataTable abaPessoal,
                                                              List<ValorContabil> valoresContabil,
                                                              IXLWorksheet abaPlanMesclada)
        {
            for (int i = 0; i < abaPessoal.Rows.Count; i++)
            {
                DataRow registro = abaPessoal.Rows[i];

                ValorContabil valor = valoresContabil.Find(v => $"{v.Codigo}".Trim() == $"{registro[11]}".Trim());

                for (int j = 0; j < registro.ItemArray.Length; j++)
                {
                    if (valor != null && ((j >= 131 && j <= 133) || j == 160))
                    {
                        abaPlanMesclada.Cell(i + 1, 131).Value = valor.VencBruto.Replace(".", "").Replace(",", "").Trim();
                        abaPlanMesclada.Cell(i + 1, 132).Value = valor.Descontos.Replace(".", "").Replace(",", "").Trim();
                        abaPlanMesclada.Cell(i + 1, 133).Value = valor.SalLiquido.Replace(".", "").Replace(",", "").Trim();
                        abaPlanMesclada.Cell(i + 1, 160).Value = valor.SalLiquido.Replace(".", "").Replace(",", "").Trim();
                    }
                    else
                    {
                        abaPlanMesclada.Cell(i + 1, j + 1).Value = $"{registro[j]}".Trim();
                    }
                }
            }
        }

        private static void FormatarDadosFinanceirosParaMesclada(DataTable abaFinanceiro,
                                                                 List<SalarioContabil> salariosContabil,
                                                                 IXLWorksheet abaPlanMesclada)
        {
            for (int i = 0; i < abaFinanceiro.Rows.Count; i++)
            {
                DataRow registro = abaFinanceiro.Rows[i];

                // se a iteração atual é o cabeçalho, todas as colunas devem ser copiadas
                // senão, apenas as 10 primeiras colunas são fixas
                int numColunas = i == 0 ? (registro.ItemArray.Length - 1) : 10;

                // cópia das 10 primeiras colunas da planilha mensal para a mesclada
                for (int j = 0; j <= numColunas; j++)
                {
                    abaPlanMesclada.Cell(i + 1, j + 1).Value = $"{registro[j]}".Trim();
                }

                // se cabeçalho, os demais passos de atribuição dinâmica de verbas não devem continuar
                if (i == 0) { continue; }

                // as colunas variáveis devem ir da 11 até o fim da aba
                int indexColunasVariaveis = 11;
                SalarioContabil salario = salariosContabil.Find(s => $"{s.Codigo}".Trim() == $"{registro[1]}".Trim());
                if (salario == null) { continue; }

                for (int j = 0; j < salario.Verbas.Count; j++)
                {
                    Verba verba = salario.Verbas[j];

                    // os valores da planilha original não podem ter ponto ou vírgula
                    string valor = verba.Valor.Replace(".", "").Replace(",", "").Trim();
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 1).Value = salario.Codigo;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 2).Value = valor;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 3).Value = verba.Indicacao;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 4).Value = verba.DoMes;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 5).Value = verba.Fve;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 6).Value = verba.Audesp;
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 7).Value = "";
                    abaPlanMesclada.Cell(i + 1, indexColunasVariaveis + 8).Value = "";

                    // incremento para o grupo de 8 colunas de informação financeira por verba
                    indexColunasVariaveis += 8;
                }
            }
        }
    }
}
