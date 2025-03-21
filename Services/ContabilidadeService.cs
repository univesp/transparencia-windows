using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparenciaWindows.Services
{
    public class ContabilidadeService
    {
        #region Constantes

        private const int ColCodigo = 10;
        private const int ColNome = 11;
        private const int ColCredito = 22;
        private const int ValCredito = 25;
        private const int ColDebito = 27;
        private const int ValDebito = 30;
        private const int ColVencBruto = 50;
        private const int ColDescontos = 51;
        private const int ColSalLiquido = 54;

        #endregion

        #region Classes auxiliares

        public class SalarioContabil
        {
            public SalarioContabil(string codigo, string nome, List<Verba> verbas)
            {
                Codigo = codigo;
                Nome = nome;
                Verbas = verbas;
            }

            public string Codigo { get; set; }
            public string Nome { get; set; }
            public List<Verba> Verbas { get; set; }        
        }

        public class ValorContabil
        {
            public ValorContabil(string codigo, string nome, string vencBruto, string descontos, string salLiquido) {
                Codigo = codigo;
                Nome = nome;
                VencBruto = vencBruto;
                Descontos = descontos;
                SalLiquido = salLiquido;            
            }

            public string Codigo { get; set; }
            public string Nome { get; set; }
            public string VencBruto { get; set; }
            public string Descontos { get; set; }
            public string SalLiquido { get; set; }
        }

        public class Verba
        {
            public Verba(string codigo, string valor, string indicacao, string doMes, string fve, string audesp)
            {
                Codigo = codigo;
                Valor = valor;
                Indicacao = indicacao;
                DoMes = doMes;
                Fve = fve;
                Audesp = audesp;
            }

            public string Codigo { get; set; }
            public string Valor { get; set; }
            public string Indicacao { get; set; }
            public string DoMes { get; set; }
            public string Fve { get; set; }
            public string Audesp { get; set; }
        }

        private class VencimentoDescontoMensal
        {
            public VencimentoDescontoMensal(string codigo, string fve, string audesp)
            {
                Codigo = codigo;               
                Fve = fve;
                Audesp = audesp;
            }

            public string Codigo { get; set; }         
            public string Fve { get; set; }
            public string Audesp { get; set; }
        }

        #endregion

        #region Método principal

        public static List<SalarioContabil> ObterSalariosContabil(IExcelDataReader planilhaMensal, IExcelDataReader planilhaContabil)
        {
            List<SalarioContabil> registrosFinanceiros = new List<SalarioContabil>();
                        
            var dsMensal = planilhaMensal.AsDataSet();
                            
            var dsContabil = planilhaContabil.AsDataSet();
            var aba = dsContabil.Tables[0];
                                
            string ultimoCodigo = "";
            List<VencimentoDescontoMensal> vencDescMensal = ObterVencimentosDescontosMensal(dsMensal.Tables[5]);

            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                // Ou o valor do crédito ou o do débito devem estar preenchidos
                if ($"{registro[ColCredito]}".Trim() == "" && $"{registro[ColDebito]}".Trim() == "")
                {
                    continue;
                }

                if (RemoverFinalPontoZero(ultimoCodigo.Trim()) != RemoverFinalPontoZero($"{registro[ColCodigo]}".Trim()))
                {
                    ultimoCodigo = RemoverFinalPontoZero($"{registro[ColCodigo]}".Trim());
                    registrosFinanceiros.Add(new SalarioContabil(ultimoCodigo, $"{registro[5]}".Trim(), new List<Verba>()));
                }

                AdicionarVencimentoDesconto(registrosFinanceiros, registro, vencDescMensal);
            }
            

            return registrosFinanceiros;
        }

        #endregion

        #region Métodos auxiliares

        public static List<ValorContabil> ObterVencimentosDescontosContabil(IExcelDataReader planilha)
        {
            List<ValorContabil> valores = new List<ValorContabil>();

            DataTable aba = planilha.AsDataSet().Tables[0];
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];
               
                if ($"{registro[ColVencBruto]}".Trim() == "" || ($"{registro[ColVencBruto]}".Trim() == "0"))
                {
                    continue;
                }

                string codigo = $"{registro[ColCodigo]}".Trim();
                string nome = $"{registro[ColNome]}".Trim();
                string vencBruto = PadronizarValor(RemoverFinalPontoZero($"{registro[ColVencBruto]}".Trim()));
                string descontos = PadronizarValor(RemoverFinalPontoZero($"{registro[ColDescontos]}".Trim()));
                string salLiquido = PadronizarValor(RemoverFinalPontoZero($"{registro[ColSalLiquido]}".Trim()));

                valores.Add(new ValorContabil(codigo, nome, vencBruto, descontos, salLiquido));
            }

            return valores;
        }

        private static List<VencimentoDescontoMensal> ObterVencimentosDescontosMensal(DataTable aba)
        {
            List<VencimentoDescontoMensal> vencDescMensal = new List<VencimentoDescontoMensal>();

            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];
                vencDescMensal.Add(new VencimentoDescontoMensal($"{registro[5]}".Trim(), $"{registro[8]}".Trim(), $"{registro[12]}".Trim()));
            }

            return vencDescMensal;
        }

        private static void AdicionarVencimentoDesconto(List<SalarioContabil> registrosFinanceiros,
                                                        DataRow registroContabil, 
                                                        List<VencimentoDescontoMensal> vencDescMensal)
        {
            if ($"{registroContabil[ColCredito]}".Trim() != "")
            {
                var obj = vencDescMensal.Find(vd => $"{vd.Codigo}".Trim() == $"{registroContabil[ColCredito]}".Trim());
                Verba verba = new Verba(
                    RemoverFinalPontoZero($"{registroContabil[ColCredito]}".Trim()),
                    RemoverFinalPontoZero($"{registroContabil[ValCredito]}".Trim()),
                    "C - Crédito ao funcionário",
                    "M - Do Mês",
                    obj.Fve,
                    obj.Audesp
                );
                registrosFinanceiros.Last().Verbas.Add(verba);

            }
            if ($"{registroContabil[ColDebito]}".Trim() != "")
            {
                var obj = vencDescMensal.Find(vd => $"{vd.Codigo}".Trim() == $"{registroContabil[ColDebito]}".Trim());
                Verba verba = new Verba(
                    RemoverFinalPontoZero($"{registroContabil[ColDebito]}".Trim()),
                    RemoverFinalPontoZero($"{registroContabil[ValDebito]}".Trim()),
                    "D - Débito",
                    "M - Do Mês",
                    obj.Fve,
                    obj.Audesp
                );
                registrosFinanceiros.Last().Verbas.Add(verba);
            }
        }

        private static string PadronizarValor(string valor)
        {
            var valorSeparado = valor.Split(',');
            if (valorSeparado == null || valorSeparado.Length == 0) { return valor; }
            if (valorSeparado.Length == 1) { return valor + ".00"; }
            if (valorSeparado[1].Length == 1) { return valor + "0"; }

            return valor;
        }

        private static string RemoverFinalPontoZero(string valor)
        {
            return valor.Replace(".0", "").Trim();
        }

        #endregion
    }
}
