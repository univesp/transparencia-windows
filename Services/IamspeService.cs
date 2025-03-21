using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using TransparenciaWindows.Utils;

namespace TransparenciaWindows.Services
{
    public class IamspeService
    {
        // Constantes identificadoras da Univesp
        private const string Cliente = "306";
        private const string IdentEntid = "F";
        private const string IdentUA = "95694";
        private const string NomeEntidade = "FUND.UN.VIRTUAL EST.SP UNIVESP";
        private const string IdentOrgao = "48";
        private const string IdentUO = "46";
        private const string IdentUD = "30";

        public static void ConverterParaTXT(IExcelDataReader planilha)
        {
            MessageBox.Show("Convertendo para TXT do IAMSPE",
                            "Informação", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            var ds = planilha.AsDataSet();                
            var dadosPessoais = ConverterDadosPessoais(ds.Tables[2]);

            string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");
            string filePath = Path.Combine(baseDirectory, "iamspe.txt");

            using (StreamWriter saida = new StreamWriter(filePath))
            {                 
                saida.Write(dadosPessoais);                 
                MessageBox.Show("Arquivo gerado com sucesso",
                                "Informação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }            
        }

        private static string ConverterDadosPessoais(DataTable aba)
        {
            string conteudo = "";

            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                if ($"{registro[163]}".Trim() != "1 - SIM") // pula a linha se opção "IAMSPE - ADERIU?" for diferente de SIM
                {
                    continue;
                }

                string linhaFormatada = "";

                // CLIENTE n3
                linhaFormatada += $"{Cliente}".PadRightSubstring(3);
                // IDENT_FUNCIO n11
                linhaFormatada += $"{registro[9]}".Trim().PadRightSubstring(11); // [J]
                // SUB_IDENT_FUNCIO n2
                linhaFormatada += $"{registro[10]}".Trim().PadRightSubstring(2); // [K]
                // NOME_FUNCIONARIO a30
                linhaFormatada += $"{registro[13]}".Trim().PadRightSubstring(30); // [N]
                // NUMERO_IDENTIDADE a11
                linhaFormatada += $"{registro[22]}".Trim().PadRightSubstring(11);
                // NUMERO_CPF n9
                linhaFormatada += $"{registro[24]}".Trim().PadRightSubstring(9); // [Y]
                // CONTROLE_CPF n2
                linhaFormatada += $"{registro[25]}".Trim().PadRightSubstring(2); // [Z]
                // SEXO a1
                linhaFormatada += $"{registro[15]}".Split(' ')[0].Trim().PadRightSubstring(1); // [P]
                // EST_CIVIL a1
                linhaFormatada += $"{registro[16]}".Split(' ')[0].Trim().PadRightSubstring(1); // [Q]
                // DATA_NASC n8
                linhaFormatada += $"{registro[14]}".Trim().PadRightSubstring(8); // [O]
                                                                                 // POP_CAR a2
                linhaFormatada += $"{registro[164]}".Trim().PadRightSubstring(2); // [FJ]
                // COD_SITUA_FUNCIO a2
                linhaFormatada += $"{registro[165]}".Split('=')[0].Trim().PadRightSubstring(2); // [FK]
                // MOTIVO_SITUA_FUNCIO n3
                linhaFormatada += $"{registro[166]}".Split('=')[0].Trim().PadRightSubstring(3); // [FL]
                // DAT_INIC_SITUA_FUNCIO n8
                linhaFormatada += $"{registro[61]}".Trim().PadRightSubstring(8); // [BJ]
                // VD_IAMSPE n15
                linhaFormatada += "".PadRightSubstring(15); // [FM]
                // VD_AGREGADO n15
                linhaFormatada += "".PadRightSubstring(15); // [FM]
                // IDENT_ENTID a1
                linhaFormatada += $"{IdentEntid}".PadRightSubstring(1); // [FN]
                // IDENT_UA n7
                linhaFormatada += $"{IdentUA}".PadRightSubstring(7);
                // NOME_ENTIDADE a40
                linhaFormatada += $"{NomeEntidade}".PadRightSubstring(40);
                // IDENT_ORGAO n2
                linhaFormatada += $"{IdentOrgao}".PadRightSubstring(2);
                // IDENT_UO n3
                linhaFormatada += $"{IdentUO}".PadRightSubstring(3);
                // VD_FÉRIAS n15
                linhaFormatada += $"{TratarVirgulaMoeda(registro[169].ToString())}".Trim().PadRightSubstring(15); // [FO]
                // VD_PARCELAMENTO n15
                linhaFormatada += "".PadRightSubstring(15); // [FP]
                // VD_RESERVA n15
                linhaFormatada += "".PadRightSubstring(15); // [FQ]
                // VD_IAMSPE_LEI_11456 n15
                linhaFormatada += "".PadRightSubstring(15); // [FR]
                // VD_AGREGADOS_LEI_11456 n15
                linhaFormatada += "".PadRightSubstring(15); // [FS]
                // VD_FÉRIAS_LEI_11456 n15
                linhaFormatada += "".PadRightSubstring(15); // [FT]
                // VD_AFAST_IAMSPE_CEETEPS n15
                linhaFormatada += "".PadRightSubstring(15); // [FU]
                // VD_AGREG_IAMSPE_CEETEPS n15
                linhaFormatada += "".PadRightSubstring(15); // [FV]
                // IDENT_MUNICIPIO n5
                linhaFormatada += "".PadRightSubstring(5);
                // DENOM_NACIO a20
                linhaFormatada += "".PadRightSubstring(20);
                // NOME_MAE a30
                linhaFormatada += $"{registro[19]}".Trim().PadRightSubstring(30); // [T] C 30
                // EST_EMIS_IDENTIDADE a2
                linhaFormatada += "".PadRightSubstring(2);
                // NUMERO_PISPASEP n11
                linhaFormatada += "".PadRightSubstring(11);
                // DATA_INGR_SERV_PUBL n8
                linhaFormatada += "".PadRightSubstring(8);
                // ANO_PRIM_EMPREGO n4
                linhaFormatada += "".PadRightSubstring(4);
                // COD_BANCO n5
                linhaFormatada += "".PadRightSubstring(5);
                // COG_AGENCIA n5
                linhaFormatada += "".PadRightSubstring(5);
                // DIG_AGENCIA n1
                linhaFormatada += "".PadRightSubstring(1);
                // NUMERO_CONTA_CORRENTE n7
                // conta_cc = row[159].to_s[0..-2].to_s
                // conta_dig = row[159].to_s[-1].to_s
                // line += conta_cc.pad_with_right_spaces! 7
                linhaFormatada += "".PadRightSubstring(7);
                // DIGITO_CONTA_CORRENTE n1
                // line += conta_dig.pad_with_right_spaces! 1
                linhaFormatada += "".PadRightSubstring(1);
                // ENDERECO_RESIDE a50
                linhaFormatada += $"{registro[35]}".Trim().PadRightSubstring(50); // [AJ]
                // ENDERECO_BAIRRO a30
                linhaFormatada += "".PadRightSubstring(30);
                // CEP_RESIDENCIAL n8
                linhaFormatada += $"{registro[36]}".Trim().PadRightSubstring(8); // [AK]
                // CIDADE_RESIDENCIAL a30
                linhaFormatada += $"{registro[37]}".Trim().PadRightSubstring(30); // [AL]
                // VD_IAMSPE_SPPREV_070127 n15
                linhaFormatada += "".PadRightSubstring(15); // [FW]
                // VD_IAMSPE_SPPREV_700062 n15
                linhaFormatada += "".PadRightSubstring(15); // [FX]
                // VD_IAMSPE_SPPREV_700371 n15
                linhaFormatada += "".PadRightSubstring(15);// [FY]
                // VD_IAMSPE_SPPREV_700372 n15
                linhaFormatada += "".PadRightSubstring(15); // [FZ]
                // VD_IAMSPE_SPPREV_000504 n15
                linhaFormatada += "".PadRightSubstring(15); // [GA]
                // VD_IAMSPE_ODONTO_SEFAZ n15
                linhaFormatada += $"{TratarVirgulaMoeda(registro[182].ToString())}".Trim().PadRightSubstring(15); // [GB]
                // VD_IAMSPE_ODONTO_SPPREV n15
                linhaFormatada += $"{TratarVirgulaMoeda(registro[183].ToString())}".Trim().PadRightSubstring(15); // [GC]      

                // VD_IAMSPE_BENEFI_070119 n15
                if ($"{registro[184]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[184].ToString())}".Trim().PadRightSubstring(15); // [GD]    
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_AGRESF_070120 n15
                if ($"{registro[185]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[185].ToString())}".Trim().PadRightSubstring(15); // [GE]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_BENESF_070121 n15
                if ($"{registro[186]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[186].ToString())}".Trim().PadRightSubstring(15); // [GF]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_13SAL_070122 n15
                if ($"{registro[187]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[187].ToString())}".Trim().PadRightSubstring(15); // [GG]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_AGRE13_070123 n15
                if ($"{registro[188]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[188].ToString())}".Trim().PadRightSubstring(15); // [GH]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_BENE13_070124 n15
                if ($"{registro[189]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[189].ToString())}".Trim().PadRightSubstring(15); // [GI]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_DEPENT_070641 n15
                linhaFormatada += "".PadRightSubstring(15); // [GJ]

                // VD_IAMSPE_070642 n15
                linhaFormatada += "".PadRightSubstring(15); // [GK]

                // VD_IAMSPE_070037 n15
                if ($"{registro[168]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[168].ToString())}".Trim().PadRightSubstring(15); // [GL]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_907100 n15
                linhaFormatada += "".PadRightSubstring(15); // [GM]

                // VD_IAMSPE_901699 n15
                linhaFormatada += "".PadRightSubstring(15); // [GN]

                // VD_IAMSPE_000924 n15
                linhaFormatada += "".PadRightSubstring(15); // [GO]

                // VD_IAMSPE_070006 n15
                if ($"{registro[196]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[196].ToString())}".Trim().PadRightSubstring(15); // [GP]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_000510 n15
                linhaFormatada += "".PadRightSubstring(15); // [GQ]

                // VD_IAMSPE_907015 n15
                linhaFormatada += "".PadRightSubstring(15); // [GR]

                // VD_IAMSPE_930401 n15
                linhaFormatada += "".PadRightSubstring(15); // [GS]

                // VD_IAMSPE_000110 n15
                linhaFormatada += "".PadRightSubstring(15); // [GT]

                // VD_IAMSPE_900302 n15
                linhaFormatada += "".PadRightSubstring(15); // [GU]

                // VD_IAMSPE_000923 n15
                linhaFormatada += "".PadRightSubstring(15); // [GV]

                // VD_IAMSPE_000826 n15
                linhaFormatada += "".PadRightSubstring(15); // [GW]

                // IDENT_UD n3
                linhaFormatada += $"{IdentUD}".PadRightSubstring(3); // [GW]

                // VD_IAMSPE_070125 n15
                linhaFormatada += "".PadRightSubstring(15); // [GW]

                // VD_IAMSPE_070126 n15
                if ($"{registro[167]}".Trim() != "")
                {
                    linhaFormatada += $"{TratarVirgulaMoeda(registro[167].ToString())}".Trim().PadRightSubstring(15); // [GW]
                }
                else
                {
                    linhaFormatada += "".PadLeftSubstring(15);
                }

                // VD_IAMSPE_SPPREV_070127 n15
                linhaFormatada += "".PadRightSubstring(15); // [GW]

                conteudo += $"{linhaFormatada}\n";
            }

            return conteudo;
        }

        private static string TratarVirgulaMoeda(string valor)
        {
            if (valor.Trim() == "") { return ""; }

            // garante que o valor tenha sempre 3 dígitos (previne a vírgula quando valor for menos de R$ 1,00
            string valorMilhar = valor.Trim().PadRight(3, '0');
            return valorMilhar.Insert(valorMilhar.Length - 2, ",");
        }
    }
}
