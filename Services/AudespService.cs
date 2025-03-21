using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace TransparenciaWindows.Services
{
    public class AudespService
    {
        #region Constantes

        // Constantes identificadoras da Univesp
        private const string Municipio = "7107";
        private const string Entidade = "11219";
       
        #endregion

        #region Classes auxiliares

        private class Lancamento {

            public Lancamento(int codigo, string valor, string natureza, string tipo, string tipoVerba)
            {
                Codigo = codigo;
                Valor = valor;
                Natureza = natureza;
                Tipo = tipo;
                TipoVerba = tipoVerba;
            }

            public int Codigo { get; set; }
            public string Valor { get; set; }
            public string Natureza { get; set; }
            public string Tipo { get; set; }
            public string TipoVerba { get; set; }
        }

        private class Financeiro
        {
            public Financeiro(string codigoPessoa, List<Lancamento> lancamentos)
            {
                CodigoPessoa = codigoPessoa;
                Lancamentos = lancamentos;
            }

            public string CodigoPessoa { get; set; }
            public List<Lancamento> Lancamentos { get; set; }
        }

        #endregion

        #region XML Folha

        public static void ConverterParaXMLFolha(IExcelDataReader planilha)
        {
            MessageBox.Show("Convertendo para XML - Folha ordinária. Aguarde!", 
                            "Informação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            string diretorioBaseTemplates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Templates\AUDESP");
            string diretorioBaseSaida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");

          
            // Leitura dos arquivos de template da AUDESP
            string templateFolha = File.ReadAllText(Path.Combine(diretorioBaseTemplates, "FolhaOrdinaria.txt"));
            string templateAgente = File.ReadAllText(Path.Combine(diretorioBaseTemplates, "Fragmentos", "AgentePublico.txt"));
            string templateVerbas = File.ReadAllText(Path.Combine(diretorioBaseTemplates, "Fragmentos", "Verbas.txt"));

            List<Financeiro> listaFinanceiro = new List<Financeiro>();

            var ds = planilha.AsDataSet();
            var abaFinanceiro = ds.Tables[3];
            for (int i = 1; i < abaFinanceiro.Rows.Count; i++)
            {
                DataRow registroFinanceiro = abaFinanceiro.Rows[i];

                string codigoPessoa = $"{registroFinanceiro[9]}".Trim();

                List<Lancamento> lancamentos = new List<Lancamento>();

                int index = 11;
                for (int j = 0; j <= 30; j++)
                {
                    // Código da verba
                    int.TryParse($"{registroFinanceiro[index]}", out int codigo);
                    if (codigo == 0) { break; }

                    // Valor
                    float.TryParse($"{registroFinanceiro[index+1]}", out float tryValor);
                    var valor = $"{tryValor / 100}".Trim().Replace(',','.');

                    /* Espécie
                        AUDESP: 1 - Desconto,2 - Vencimento
                        Portal: D - Débito, C - Crédito ao funcionário
                        R - Redutor Salarial / Reposição (não utilizado),
                        S - Reposição de Desconto (não utilizado)*/
                    var tipo = $"{registroFinanceiro[index+2]}".Split('-')[0].Trim();
                    tipo = tipo == "C" ? "2" : "1";


                    /* Natureza
                    AUDESP: 1 - Atrasado, 2 - Normal
                    Portal: M - Do Mês, A - Atrasado*/
                    var natureza = $"{registroFinanceiro[index+3]}".Split('-')[0].Trim();
                    natureza = natureza == "A" ? "1" : "2";

                    // Código do tipo da verba
                    var tipoVerba = $"{registroFinanceiro[index+5]}".Split('-')[0].Trim();

                    index += 8; // incremento de 8 para pular para o próximo bloco de lançamentos

                    lancamentos.Add(new Lancamento(codigo, valor, natureza, tipo, tipoVerba));
                }

                listaFinanceiro.Add(new Financeiro(codigoPessoa, lancamentos));
            }

            string itens = "";
            var abaPessoal = ds.Tables[2];
            for (int i = 1; i < abaPessoal.Rows.Count; i++)
            {
                DataRow registroPessoal = abaPessoal.Rows[i];

                // pula a linha se o campo "AUDESP - considerar" (coluna FG) estiver com o valor "2 - NÃO"
                if ($"{registroPessoal[162]}".Split('-')[0].Trim() == "2")
                {
                    continue;
                }

                var financeiroPessoa = listaFinanceiro.Find(elem => $"{elem.CodigoPessoa}" == $"{registroPessoal[9]}");

                string remuneracao = "";

                for (int j = 0; j < financeiroPessoa.Lancamentos.Count; j++)
                {
                    Lancamento lancamento = financeiroPessoa.Lancamentos[j];
                    remuneracao += templateVerbas
                                    .Replace("[MUNICIPIO]", Municipio)
                                    .Replace("[ENTIDADE]", Entidade)
                                    .Replace("[CODIGO_VERBA]", $"{lancamento.Codigo}")
                                    .Replace("[VALOR]", lancamento.Valor)
                                    .Replace("[NATUREZA]", lancamento.Natureza)
                                    .Replace("[ESPECIE]", lancamento.Tipo)
                                    .Replace("[CODIGO_TIPO_VERBA]", lancamento.TipoVerba);
                }

                float.TryParse($"{registroPessoal[131]}", out float remuneracaoBruta);
                float.TryParse($"{registroPessoal[132]}", out float descontos);
                float.TryParse($"{registroPessoal[133]}", out float remuneracaoLiquida);

                itens += templateAgente
                            .Replace("[CPF]", MontarCPF(registroPessoal))
                            .Replace("[NOME]", $"{registroPessoal[13]}".Trim())
                            .Replace("[MUNICIPIO]", $"{registroPessoal[146]}".Trim())
                            .Replace("[ENTIDADE]", $"{registroPessoal[147]}".Trim())
                            .Replace("[CARGO_POLITICO]", $"{registroPessoal[148]}".Split('-')[0].Trim())
                            .Replace("[FUNCAO_GOVERNO]", $"{registroPessoal[149]}".Trim())
                            .Replace("[ESTAGIARIO]", $"{registroPessoal[150]}".Split('-')[0].Trim())
                            .Replace("[CODIGO_CARGO]", $"{registroPessoal[45]}".Trim())
                            .Replace("[SITUACAO]", $"{registroPessoal[151]}".Split('-')[0].Trim())
                            .Replace("[REGIME_JURIDICO]", $"{registroPessoal[152]}".Split('-')[0].Trim())
                            .Replace("[AUTORIZACAO_TETO]", $"{registroPessoal[153]}".Split('-')[0].Trim())
                            .Replace("[REMUNERACAO_BRUTA]", DeFloatParaTexto(remuneracaoBruta))
                            .Replace("[DESCONTOS]", DeFloatParaTexto(descontos))
                            .Replace("[REMUNERACAO_LIQUIDA]", DeFloatParaTexto(remuneracaoLiquida))
                            .Replace("[VERBAS]", remuneracao);                        

            }


            var abaCabecalho = ds.Tables[0];
            DataRow registroCabecalho = abaCabecalho.Rows[1];

            string templateFinal = templateFolha
                                    .Replace("[VERBAS_REMUNERATORIAS]", itens)
                                    .Replace("[MUNICIPIO]", $"{registroCabecalho[18]}".Trim())
                                    .Replace("[ENTIDADE]", $"{registroCabecalho[19]}".Trim())
                                    .Replace("[ANO_EXERCICIO]", $"{registroCabecalho[20]}".Trim())
                                    .Replace("[MES_EXERCICIO]", $"{registroCabecalho[21]}".Trim())
                                    .Replace("[DATA_CRIACAO]", DateTime.Now.ToString("yyyy-MM-dd"))
                                    .Replace("[IDENTIFICACAO_AGENTE]", itens);


            using (StreamWriter saida = new StreamWriter(Path.Combine(diretorioBaseSaida, "AUDESPFolhaOrdinaria.xml")))
            {
                saida.Write(templateFinal);
                MessageBox.Show("Arquivo gerado com sucesso",
                                "Informação", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
                      
        }

        private static string DeFloatParaTexto(float celula)
        {
            return (celula / 100).ToString("0.00").Replace(',','.');
        }

        private static string MontarCPF(DataRow registro)
        {
            return ($"{registro[24]}".Trim() + $"{registro[25]}".Trim()).PadRight(11, '0');
        }

        #endregion

        #region XML Pagamento Folha

        public static void ConverterParaXMLPagamentoFolha(IExcelDataReader planilha)
        {
            MessageBox.Show("Convertendo para XML - Pagamento Folha",
                            "Informação", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            string diretorioBaseTemplates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Templates\AUDESP");
            string diretorioBaseSaida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");

           
            // Leitura dos arquivos de template da AUDESP
            string templatePagamentoFolha = File.ReadAllText(Path.Combine(diretorioBaseTemplates, "PagamentoFolha.txt"));
            string templateAgente = File.ReadAllText(Path.Combine(diretorioBaseTemplates, "Fragmentos", "AgenteFolha.txt"));

            string agentes = "";

            var ds = planilha.AsDataSet();
            var abaPessoal = ds.Tables[2];
            for (int i = 1; i < abaPessoal.Rows.Count; i++)
            {
                DataRow registroPessoal = abaPessoal.Rows[i];

                // pula a linha se o campo "AUDESP - considerar" (coluna FG) estiver com o valor "2 - NÃO"
                if ($"{registroPessoal[162]}".Split('-')[0].Trim() == "2")
                {
                    continue;
                }

                float.TryParse($"{registroPessoal[160]}", out float pagoCC);
                float.TryParse($"{registroPessoal[161]}", out float pagoOutros);

                agentes += templateAgente
                            .Replace("[CPF]", MontarCPF(registroPessoal))
                            .Replace("[CODIGO_CARGO]", $"{registroPessoal[45]}".Trim())
                            .Replace("[FORMA_PAGAMENTO]", $"{registroPessoal[156]}".Split('-')[0].Trim())
                            .Replace("[NUMERO_BANCO]", $"{registroPessoal[157]}".Trim())
                            .Replace("[AGENCIA]", $"{registroPessoal[158]}".Trim())
                            .Replace("[CONTA_CORRENTE]", $"{registroPessoal[159]}".Trim())
                            .Replace("[PAGO_CC]", DeFloatParaTexto(pagoCC))
                            .Replace("[PAGO_OUTROS]", DeFloatParaTexto(pagoOutros))
                            .Replace("[MUNICIPIO]", Municipio)
                            .Replace("[ENTIDADE]", Entidade);
            }

            var abaCabecalho = ds.Tables[0];
            DataRow registroCabecalho = abaCabecalho.Rows[1];

            string templateFinal = templatePagamentoFolha
                                    .Replace("[MUNICIPIO]", Municipio)
                                    .Replace("[ENTIDADE]", Entidade)
                                    .Replace("[ANO_EXERCICIO]", $"{registroCabecalho[20]}".Trim())
                                    .Replace("[MES_EXERCICIO]", $"{registroCabecalho[21]}".Trim())
                                    .Replace("[DATA_CRIACAO]", DateTime.Now.ToString("yyyy-MM-dd"))
                                    .Replace("[ANO_PAGAMENTO]", $"{registroCabecalho[20]}".Trim())
                                    .Replace("[MES_PAGAMENTO]", $"{registroCabecalho[21]}".Trim())
                                    .Replace("[IDENTIFICACAO_AGENTES]", agentes);

            using (StreamWriter saida = new StreamWriter(Path.Combine(diretorioBaseSaida, "AUDESPPagamentoFolha.xml")))
            {
                saida.Write(templateFinal);
                MessageBox.Show("Arquivo gerado com sucesso",
                                "Informação", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            
        }

        #endregion

        #region XML Resumo Mensal

        public static void ConverterParaXMLResumo(IExcelDataReader planilha)
        {
            MessageBox.Show("Convertendo para XML - Resumo mensal",
                            "Informação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // Leitura dos arquivos de template da AUDESP
            string diretorioBaseTemplates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Templates\AUDESP");
            string diretorioBaseSaida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");

           
            // Leitura dos arquivos de template da AUDESP
            string templateResumo = File.ReadAllText(Path.Combine(diretorioBaseTemplates, "ResumoMensal.txt"));

            string agentes = "";

            var ds = planilha.AsDataSet();

            var abaCabecalho = ds.Tables[0];
            DataRow registroCabecalho = abaCabecalho.Rows[1];

            var abaEncargos = ds.Tables[1];
            DataRow registroEncargos = abaEncargos.Rows[1];

            float.TryParse($"{registroEncargos[68]}", out float fgts);
            float.TryParse($"{registroEncargos[69]}", out float geralAgPolitico);
            float.TryParse($"{registroEncargos[70]}", out float proprioAgPolitico);
            float.TryParse($"{registroEncargos[71]}", out float geralAgNaoPolitico);
            float.TryParse($"{registroEncargos[72]}", out float proprioAgNaoPolitico);

            string templateFinal = templateResumo
                                    .Replace("[MUNICIPIO]", $"{registroEncargos[66]}".Trim())
                                    .Replace("[COD_MUNICIPIO]", $"{registroEncargos[66]}".Trim())
                                    .Replace("[ENTIDADE]", $"{registroEncargos[67]}".Trim())
                                    .Replace("[COD_ENTIDADE]", $"{registroEncargos[67]}".Trim())
                                    .Replace("[FGTS]", DeFloatParaTexto(fgts))
                                    .Replace("[GERAL_AG_POLITICO]", DeFloatParaTexto(geralAgPolitico))
                                    .Replace("[PROPRIO_AG_POLITICO]", DeFloatParaTexto(proprioAgPolitico))
                                    .Replace("[GERAL_AG_NAO_POLITICO]", DeFloatParaTexto(geralAgNaoPolitico))
                                    .Replace("[PROPRIO_AG_NAO_POLITICO]", DeFloatParaTexto(proprioAgNaoPolitico))
                                    .Replace("[DATA_CRIACAO]", DateTime.Now.ToString("yyyy-MM-dd"))
                                    .Replace("[ANO_EXERCICIO]", $"{registroCabecalho[20]}".Trim())
                                    .Replace("[MES_EXERCICIO]", $"{registroCabecalho[21]}".Trim());
            
            using (StreamWriter saida = new StreamWriter(Path.Combine(diretorioBaseSaida, "AUDESPResumoMensal.xml")))
            {
                saida.Write(templateFinal);
                MessageBox.Show("Arquivo gerado com sucesso", 
                                "Informação",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            
        }

        #endregion

        #region XML Verbas

        public static void ConverterParaXMLVerbas(IExcelDataReader planilha)
        {
            MessageBox.Show("Convertendo para XML - Verbas", 
                            "Informação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            string diretorioBaseTemplates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Templates\AUDESP");
            string diretorioBaseSaida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");                     
          
            // Leitura dos arquivos de template da AUDESP
            string templateVerbas = File.ReadAllText(Path.Combine(diretorioBaseTemplates, "VerbasRemuneratorias.txt"));

            string itens = "";

            var ds = planilha.AsDataSet();
            var abaVencimentos = ds.Tables[5];
            for (int i = 1; i < abaVencimentos.Rows.Count; i++)
            {
                DataRow registroVencimentos = abaVencimentos.Rows[i];

                string entraCalculoTeto = $"{registroVencimentos[11]}".Split('-')[0].Trim();

                itens += "\t<cvr:VerbasRemuneratorias>\n";
                itens += "\t<cvr:Codigo>" + $"{registroVencimentos[5]}".Trim() + "</cvr:Codigo>\n";
                itens += "\t<cvr:Nome>" + $"{ registroVencimentos[6]}".Trim() + "</cvr:Nome>\n";
                itens += "\t<cvr:EntraNoCalculoDoTetoConstitucional>" + entraCalculoTeto + "</cvr:EntraNoCalculoDoTetoConstitucional>\n";
                itens += "\t</cvr:VerbasRemuneratorias>\n";
            }

            var abaCabecalho = ds.Tables[0];
            DataRow registroCabecalho = abaCabecalho.Rows[1];

            string templateFinal = templateVerbas
                                    .Replace("[VERBAS_REMUNERATORIAS]", itens)
                                    .Replace("[MUNICIPIO]", $"{registroCabecalho[18]}".Trim())
                                    .Replace("[ENTIDADE]", $"{registroCabecalho[19]}".Trim())
                                    .Replace("[ANO_EXERCICIO]", $"{registroCabecalho[20]}".Trim())
                                    .Replace("[DATA_CRIACAO]", DateTime.Now.ToString("yyyy-MM-dd"))
                                    .Replace("[TIPO_DOCUMENTO]", "Cadastro de Verbas Remuneratórias");
                                 
            using (StreamWriter saida = new StreamWriter(Path.Combine(diretorioBaseSaida, "AUDESPVerbas.xml")))
            {
                saida.Write(templateFinal);
                MessageBox.Show("Arquivo gerado com sucesso", 
                                "Informação", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            
        }

        #endregion
    }
}
