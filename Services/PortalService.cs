using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace TransparenciaWindows.Services
{
    public class PortalService
    {
        public static void ConverterParaTXT(Stream dadosPlanilha)
        {
            using (var planilha = ExcelReaderFactory.CreateReader(dadosPlanilha))
            {
                var ds = planilha.AsDataSet();
                var dadosEncargos = ConverterDadosEncargos(ds.Tables[1]);
                var dadosPessoais = ConverterDadosPessoais(ds.Tables[2]);
                var dadosFinanceiros = ConverterDadosFinanceiros(ds.Tables[3]);
                var dadosCargos = ConverterDadosCargos(ds.Tables[4]);
                var dadosVencimentos = ConverterDadosVencimentos(ds.Tables[5]);
                var dadosUnidades = ConverterDadosUnidades(ds.Tables[6]);

                string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Outputs");
                string filePath = Path.Combine(baseDirectory, "portal.txt");

                using (StreamWriter saida = new StreamWriter(filePath))
                {
                    saida.Write(dadosEncargos);
                    saida.Write(dadosPessoais);
                    saida.Write(dadosFinanceiros);
                    saida.Write(dadosCargos);
                    saida.Write(dadosVencimentos);
                    saida.Write(dadosUnidades);
                    MessageBox.Show("Arquivo gerado com sucesso!");
                }
            }
        }

        private static String ConverterDadosEncargos(DataTable aba)
        {
            string conteudo = "";
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                string linhaFormatada = "";
                linhaFormatada += "ES".PadRight(2); /* [A] C 02 */
                linhaFormatada += $"{i}".PadLeft(7, '0'); /* [B] Z 07 */
                linhaFormatada += $"{registro[2]}".Trim().PadLeft(2, '0'); /* [C] Z 02 */
                linhaFormatada += $"{registro[3]}".Trim().PadLeft(3, '0'); /* [D] Z 03 */
                linhaFormatada += "".PadRight(33); /* [E] C 33 */
                linhaFormatada += $"{registro[5]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [F] Z 06 */
                linhaFormatada += $"{registro[6]}".Trim().PadLeft(15,'0'); /* [G] Z 15 */
                linhaFormatada += $"{registro[7]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [H] Z 06 */
                linhaFormatada += $"{registro[8]}".Trim().PadLeft(15,'0'); /* [I] Z 15 */
                linhaFormatada += $"{registro[9]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [J] Z 06 */
                linhaFormatada += $"{registro[10]}".Trim().PadLeft(15,'0'); /* [K] Z 15 */
                linhaFormatada += $"{registro[11]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [L] Z 06 */
                linhaFormatada += $"{registro[12]}".Trim().PadLeft(15,'0'); /* [M] Z 15 */
                linhaFormatada += $"{registro[13]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [N] Z 06 */
                linhaFormatada += $"{registro[14]}".Trim().PadLeft(15,'0'); /* [O] Z 15 */
                linhaFormatada += $"{registro[15]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [P] Z 06 */
                linhaFormatada += $"{registro[16]}".Trim().PadLeft(15,'0'); /* [Q] Z 15 */
                linhaFormatada += $"{registro[17]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [R] Z 06 */
                linhaFormatada += $"{registro[18]}".Trim().PadLeft(15,'0'); /* [S] Z 15 */
                linhaFormatada += $"{registro[19]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [T] Z 06 */
                linhaFormatada += $"{registro[20]}".Trim().PadLeft(15,'0'); /* [U] Z 15 */
                linhaFormatada += $"{registro[21]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [V] Z 06 */
                linhaFormatada += $"{registro[22]}".Trim().PadLeft(15,'0'); /* [W] Z 15 */
                linhaFormatada += $"{registro[23]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [X] Z 06 */
                linhaFormatada += $"{registro[24]}".Trim().PadLeft(15,'0'); /* [Y] Z 15 */
                linhaFormatada += $"{registro[25]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [Z] Z 06 */
                linhaFormatada += $"{registro[26]}".Trim().PadLeft(15,'0'); /* [AA] Z 15 */
                linhaFormatada += $"{registro[27]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AB] Z 06 */
                linhaFormatada += $"{registro[28]}".Trim().PadLeft(15,'0'); /* [AC] Z 15 */
                linhaFormatada += $"{registro[29]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AD] Z 06 */
                linhaFormatada += $"{registro[30]}".Trim().PadLeft(15,'0'); /* [AE] Z 15 */
                linhaFormatada += $"{registro[31]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AF] Z 06 */
                linhaFormatada += $"{registro[32]}".Trim().PadLeft(15,'0'); /* [AG] Z 15 */
                linhaFormatada += $"{registro[33]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AH] Z 06 */
                linhaFormatada += $"{registro[34]}".Trim().PadLeft(15,'0'); /* [AI] Z 15 */
                linhaFormatada += $"{registro[35]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AJ] Z 06 */
                linhaFormatada += $"{registro[36]}".Trim().PadLeft(15,'0'); /* [AK] Z 15 */
                linhaFormatada += $"{registro[37]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AL] Z 06 */
                linhaFormatada += $"{registro[38]}".Trim().PadLeft(15,'0'); /* [AM] Z 15 */
                linhaFormatada += $"{registro[39]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AN] Z 06 */
                linhaFormatada += $"{registro[40]}".Trim().PadLeft(15,'0'); /* [AO] Z 15 */
                linhaFormatada += $"{registro[41]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AP] Z 06 */
                linhaFormatada += $"{registro[42]}".Trim().PadLeft(15,'0'); /* [AQ] Z 15 */
                linhaFormatada += $"{registro[43]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AR] Z 06 */
                linhaFormatada += $"{registro[44]}".Trim().PadLeft(15,'0'); /* [AS] Z 15 */
                linhaFormatada += $"{registro[45]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AT] Z 06 */
                linhaFormatada += $"{registro[46]}".Trim().PadLeft(15,'0'); /* [AU] Z 15 */
                linhaFormatada += $"{registro[47]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AV] Z 06 */
                linhaFormatada += $"{registro[48]}".Trim().PadLeft(15,'0'); /* [AW] Z 15 */
                linhaFormatada += $"{registro[49]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AX] Z 06 */
                linhaFormatada += $"{registro[50]}".Trim().PadLeft(15,'0'); /* [AY] Z 15 */
                linhaFormatada += $"{registro[51]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [AZ] Z 06 */
                linhaFormatada += $"{registro[52]}".Trim().PadLeft(15,'0'); /* [BA] Z 15 */
                linhaFormatada += $"{registro[53]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [BB] Z 06 */
                linhaFormatada += $"{registro[54]}".Trim().PadLeft(15,'0'); /* [BC] Z 15 */
                linhaFormatada += $"{registro[55]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [BD] Z 06 */
                linhaFormatada += $"{registro[56]}".Trim().PadLeft(15,'0'); /* [BE] Z 15 */
                linhaFormatada += $"{registro[57]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [BF] Z 06 */
                linhaFormatada += $"{registro[58]}".Trim().PadLeft(15,'0'); /* [BG] Z 15 */
                linhaFormatada += $"{registro[59]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [BH] Z 06 */
                linhaFormatada += $"{registro[60]}".Trim().PadLeft(15,'0'); /* [BI] Z 15 */
                linhaFormatada += $"{registro[61]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [BJ] Z 06 */
                linhaFormatada += $"{registro[62]}".Trim().PadLeft(15,'0'); /* [BK] Z 15 */
                linhaFormatada += $"{registro[63]}".Split(' ')[0].Trim().PadLeft(6,'0'); /* [BL] Z 06 */
                linhaFormatada += $"{registro[64]}".Trim().PadLeft(15,'0'); /* [BM] Z 15 */
                linhaFormatada += "".PadRight(72); /* [BN] C 73 */

                conteudo += $"{linhaFormatada}\n";
            }
         
            return conteudo;

        }

        private static String ConverterDadosPessoais(DataTable aba)
        {
            string conteudo = "";
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                string linhaFormatada = "";
                linhaFormatada += "F1".PadRight(2); /* [A] C 02 */
                linhaFormatada += "".PadRight(7); /* [B] C 07 */
                linhaFormatada += $"{registro[2]}".Trim().PadLeft(2,'0'); /* [C] Z 02 */
                linhaFormatada += $"{registro[3]}".Trim().PadLeft(3,'0'); /* [D] Z 03 */
                linhaFormatada += $"{registro[4]}".Trim().PadLeft(3,'0'); /* [E] Z 03 */
                linhaFormatada += $"{registro[5]}".Trim().PadLeft(7,'0'); /* [F] Z 07 */
                linhaFormatada += "".PadRight(5); /* [G] C 05 */
                linhaFormatada += $"{registro[7]}".Split(' ')[0].Trim().PadLeft(2, '0'); /* [H] Z 02 */
                linhaFormatada += $"{registro[8]}".Split(' ')[0].Trim().PadLeft(4,'0'); /* [I] Z 04 */
                linhaFormatada += $"{registro[9]}".Trim().PadLeft(10,'0'); /* [J] Z 10 */
                linhaFormatada += $"{registro[10]}".Trim().PadLeft(2,'0'); /* [K] Z 02 */
                linhaFormatada += "".PadLeft(2, '0'); /* [L] Z 02 */
                linhaFormatada += $"{registro[12]}".Trim().PadLeft( 8, '0'); /* [M] Z 08 */
                linhaFormatada += $"{registro[13]}".Trim().PadRight(30); /* [N] C 30 */
                linhaFormatada += $"{registro[14]}".Trim().PadLeft( 8, '0'); /* [O] Z 08 */
                linhaFormatada += $"{registro[15]}".Split(' ')[0].Trim().PadRight(1); /* [P] C 01 */
                linhaFormatada += $"{registro[16]}".Split(' ')[0].Trim().PadRight(1); /* [Q] C 01 */
                linhaFormatada += $"{registro[17]}".Split(' ')[0].Trim().PadRight(2); /* [R] C 02 */
                linhaFormatada += $"{registro[18]}".Split(' ')[0].Trim().PadLeft(2, '0'); /* [S] Z 02 */
                linhaFormatada += $"{registro[19]}".Trim().PadRight(30); /* [T] C 30 */
                linhaFormatada += $"{registro[20]}".Split(' ')[0].Trim().PadRight(1); /* [U] C 01 */
                linhaFormatada += $"{registro[21]}".Split(' ')[0].Trim().PadLeft(1, '0'); /* [V] Z 01 */
                linhaFormatada += $"{registro[22]}".Trim().PadLeft( 11, '0'); /* [W] C 11 */
                linhaFormatada += $"{registro[23]}".Split(' ')[0].Trim().PadRight(2); /* [X] C 02 */
                linhaFormatada += $"{registro[24]}".Trim().PadLeft( 9, '0'); /* [Y] Z 09 */
                linhaFormatada += $"{registro[25]}".Trim().PadLeft( 2, '0'); /* [Z] Z 02 */
                linhaFormatada += $"{registro[26]}".Trim().PadLeft( 11, '0');/* [AA] Z 11 */
                linhaFormatada += $"{registro[27]}".Trim().PadLeft( 7, '0'); /* [AB] Z 07 */
                linhaFormatada += $"{registro[28]}".Trim().PadLeft( 5, '0'); /* [AC] Z 05 */
                linhaFormatada += $"{registro[29]}".Split(' ')[0].Trim().PadRight(2); /* [AD] C 02 */
                linhaFormatada += $"{registro[30]}".Trim().PadLeft( 11, '0'); /* [AE] Z 11 */
                linhaFormatada += $"{registro[31]}".Trim().PadLeft( 3, '0'); /* [AF] Z 03 */
                linhaFormatada += $"{registro[32]}".Trim().PadLeft( 4, '0'); /* [AG] Z 04 */
                linhaFormatada += $"{registro[33]}".Trim().PadRight(30); /* [AH] C 30 */
                linhaFormatada += $"{registro[34]}".Split(' ')[0].Trim().PadRight(2); /* [AI] C 02 */
                linhaFormatada += $"{registro[35]}".Trim().PadRight(30); /* [AJ] C 30 */
                linhaFormatada += $"{registro[36]}".Trim().PadLeft( 8, '0'); /* [AK] Z 08 */
                linhaFormatada += $"{registro[37]}".Trim().PadRight(20); /* [AL] C 20 */
                linhaFormatada += $"{registro[38]}".Trim().PadLeft( 3, '0'); /* [AM] Z 03 */
                linhaFormatada += $"{registro[39]}".Trim().PadLeft( 3, '0'); /* [AN] Z 03 */
                linhaFormatada += $"{registro[40]}".Trim().PadLeft( 8, '0'); /* [AO] Z 08 */
                linhaFormatada += $"{registro[41]}".Trim().PadLeft( 4, '0'); /* [AP] Z 04 */
                linhaFormatada += $"{registro[42]}".Trim().PadLeft( 3, '0'); /* [AQ] Z 03 */
                linhaFormatada += $"{registro[43]}".Trim().PadLeft( 8, '0'); /* [AR] Z 08 */
                linhaFormatada += $"{registro[44]}".Split(' ')[0].Trim().PadRight(1); /* [AS] C 01 */
                linhaFormatada += $"{registro[45]}".Trim().PadLeft( 7, '0'); /* [AT] Z 07 */
                linhaFormatada += $"{registro[46]}".Trim().PadLeft( 5, '0'); /* [AU] Z 05 */
                linhaFormatada += $"{registro[47]}".Split(' ')[0].Trim().PadRight(1); /* [AV] C 01 */
                linhaFormatada += $"{registro[48]}".Split(' ')[0].Trim().PadRight(1); /* [AW] C 01 */
                linhaFormatada += $"{registro[49]}".Split(' ')[0].Trim().PadLeft(2,'0'); /* [AX] Z 02 */
                linhaFormatada += $"{registro[50]}".Split(' ')[0].Trim().PadLeft(3,'0'); /* [AY] Z 03 */
                linhaFormatada += $"{registro[51]}".Trim().PadLeft(7,'0'); /* [AZ] Z 07 */
                linhaFormatada += $"{registro[52]}".Trim().PadLeft(8,'0'); /* [BA] Z 08 */
                linhaFormatada += $"{registro[53]}".Trim().PadLeft(2,'0'); /* [BB] Z 02 */
                linhaFormatada += $"{registro[54]}".Trim().PadLeft(5,'0'); /* [BC] Z 05 */
                linhaFormatada += $"{registro[55]}".Trim().PadLeft(5,'0'); /* [BD] Z 05 */
                linhaFormatada += $"{registro[56]}".Trim().PadLeft(5,'0'); /* [BE] Z 05 */
                linhaFormatada += $"{registro[57]}".Trim().PadLeft(5,'0'); /* [BF] Z 05 */
                linhaFormatada += $"{registro[58]}".Trim().PadLeft(5,'0');/* [BG] Z 05 */
                linhaFormatada += $"{registro[59]}".Split(' ')[0].Trim().PadLeft(2,'0'); /* [BH] Z 02 */
                linhaFormatada += $"{registro[60]}".Split(' ')[0].Trim().PadLeft(3,'0'); /* [BI] Z 03 */
                linhaFormatada += $"{registro[61]}".Trim().PadLeft(8,'0'); /* [BJ] Z 08 */
                linhaFormatada += $"{registro[62]}".Trim().PadLeft(3,'0'); /* [BK] Z 03 */
                linhaFormatada += $"{registro[63]}".Trim().PadLeft(3,'0'); /* [BL] Z 03 */
                linhaFormatada += $"{registro[64]}".Trim().PadLeft(2,'0'); /* [BM] Z 02 */
                linhaFormatada += $"{registro[65]}".Trim().PadRight(10); /* [BN] C 10 */
                linhaFormatada += $"{registro[66]}".Trim().PadRight(1); /* [BO] C 01 */
                linhaFormatada += $"{registro[67]}".Split(' ')[0].Trim().PadRight(1); /* [BP] C 01 */
                linhaFormatada += $"{registro[68]}".Split(' ')[0].Trim().PadRight(1); /* [BQ] C 01 */
                linhaFormatada += $"{registro[69]}".Trim().PadLeft( 2, '0'); /* [BR] Z 02 */
                linhaFormatada += $"{registro[70]}".Trim().PadLeft( 2, '0'); /* [BS] Z 02 */
                linhaFormatada += $"{registro[71]}".Trim().PadLeft( 4, '0'); /* [BT] Z 04 */
                linhaFormatada += $"{registro[72]}".Trim().PadLeft( 5, '0'); /* [BU] Z 05 */
                linhaFormatada += $"{registro[73]}".Trim().PadLeft( 2, '0'); /* [BV] Z 02 */
                linhaFormatada += $"{registro[74]}".Trim().PadLeft( 5, '0'); /* [BW] Z 05 */
                linhaFormatada += $"{registro[75]}".Trim().PadLeft( 5, '0'); /* [BX] Z 05 */
                linhaFormatada += $"{registro[76]}".Trim().PadRight(1); /* [BY] C 01 */
                linhaFormatada += $"{registro[77]}".Trim().PadRight(1); /* [BZ] C 01 */
                linhaFormatada += $"{registro[78]}".Split(' ')[0].Trim().PadRight(1); /* [CA] C 01 */
                linhaFormatada += $"{registro[79]}".Split(' ')[0].Trim().PadRight(1); /* [CB] C 01 */
                linhaFormatada += $"{registro[80]}".Split(' ')[0].Trim().PadRight(1); /* [CC] C 01 */
                linhaFormatada += $"{registro[81]}".Trim().PadLeft( 2, '0'); /* [CD] Z 02 */
                linhaFormatada += $"{registro[82]}".Trim().PadLeft( 2, '0'); /* [CE] Z 02 */
                linhaFormatada += $"{registro[83]}".Trim().PadLeft( 7, '0'); /* [CF] Z 07 */
                linhaFormatada += $"{registro[84]}".Trim().PadLeft( 3, '0'); /* [CG] Z 03 */
                linhaFormatada += $"{registro[85]}".Trim().PadLeft( 3, '0'); /* [CH] Z 03 */
                linhaFormatada += $"{registro[86]}".Trim().PadLeft( 3, '0'); /* [CI] Z 03 */
                linhaFormatada += $"{registro[87]}".Trim().PadLeft( 5, '0'); /* [CJ] Z 05 */
                linhaFormatada += $"{registro[88]}".Trim().PadLeft( 5, '0'); /* [CK] Z 05 */
                linhaFormatada += $"{registro[89]}".Split(' ')[0].Trim().PadRight(1); /* [CL] C 01 */
                linhaFormatada += $"{registro[90]}".Trim().PadLeft( 13, '0'); /* [CM] Z 13 */
                linhaFormatada += $"{registro[91]}".Trim().PadLeft( 7, '0'); /* [CN] Z 07 */
                linhaFormatada += $"{registro[92]}".Trim().PadLeft( 7, '0'); /* [CO] Z 07 */
                linhaFormatada += $"{registro[93]}".Trim().PadLeft( 7, '0'); /* [CP] Z 07 */
                linhaFormatada += $"{registro[94]}".Trim().PadLeft( 7, '0'); /* [CQ] Z 07 */
                linhaFormatada += $"{registro[95]}".Trim().PadLeft( 7, '0'); /* [CR] Z 07 */
                linhaFormatada += $"{registro[96]}".Trim().PadLeft( 7, '0'); /* [CS] Z 07 */
                linhaFormatada += $"{registro[97]}".Trim().PadLeft( 3, '0'); /* [CT] Z 03 */
                linhaFormatada += $"{registro[98]}".Trim().PadLeft( 3, '0'); /* [CU] Z 03 */
                linhaFormatada += $"{registro[99]}".Trim().PadLeft( 2, '0'); /* [CV] Z 02 */
                linhaFormatada += $"{registro[100]}".Trim().PadRight(10); /* [CW] C 10 */
                linhaFormatada += $"{registro[101]}".Trim().PadRight(1); /* [CX] C 01 */
                linhaFormatada += $"{registro[102]}".Trim().PadLeft( 7, '0'); /* [CY] Z 07 */
                linhaFormatada += $"{registro[103]}".Trim().PadLeft( 3, '0'); /* [CZ] Z 03 */
                linhaFormatada += $"{registro[104]}".Trim().PadLeft( 3, '0'); /* [DA] Z 03 */
                linhaFormatada += $"{registro[105]}".Trim().PadLeft( 2, '0'); /* [DB] Z 02 */
                linhaFormatada += $"{registro[106]}".Trim().PadRight(10); /* [DC] C 10 */
                linhaFormatada += $"{registro[107]}".Trim().PadRight(1); /* [DD] C 01 */
                linhaFormatada += $"{registro[108]}".Trim().PadLeft( 7, '0'); /* [DE] Z 07 */
                linhaFormatada += $"{registro[109]}".Trim().PadLeft( 3, '0'); /* [DF] Z 03 */
                linhaFormatada += $"{registro[110]}".Trim().PadLeft( 3, '0'); /* [DG] Z 03 */
                linhaFormatada += $"{registro[111]}".Trim().PadLeft( 2, '0'); /* [DH] Z 02 */
                linhaFormatada += $"{registro[112]}".Trim().PadRight(10); /* [DI] C 10 */
                linhaFormatada += $"{registro[113]}".Trim().PadRight(1); /* [DJ] C 01 */
                linhaFormatada += $"{registro[114]}".Trim().PadLeft( 7, '0'); /* [DK] Z 07 */
                linhaFormatada += $"{registro[115]}".Trim().PadLeft( 3, '0'); /* [DL] Z 03 */
                linhaFormatada += $"{registro[116]}".Trim().PadLeft( 3, '0'); /* [DM] Z 03 */
                linhaFormatada += $"{registro[117]}".Trim().PadLeft( 2, '0'); /* [DN] Z 02 */
                linhaFormatada += $"{registro[118]}".Trim().PadRight(10); /* [DO] C 10 */
                linhaFormatada += $"{registro[119]}".Trim().PadRight(1); /* [DP] C 01 */
                linhaFormatada += $"{registro[120]}".Trim().PadLeft( 7, '0'); /* [DQ] Z 07 */
                linhaFormatada += $"{registro[121]}".Trim().PadLeft( 3, '0'); /* [DR] Z 03 */
                linhaFormatada += $"{registro[122]}".Trim().PadLeft( 3, '0'); /* [DS] Z 03 */
                linhaFormatada += $"{registro[123]}".Trim().PadLeft( 2, '0'); /* [DT] Z 02 */
                linhaFormatada += $"{registro[124]}".Trim().PadRight(10); /* [DU] C 10 */
                linhaFormatada += $"{registro[125]}".Trim().PadRight(1); /* [DV] C 01 */
                linhaFormatada += $"{registro[126]}".Split(' ')[0].Trim().PadLeft(3, '0'); /* [DW] Z 03 */
                linhaFormatada += $"{registro[127]}".Trim().PadLeft( 8, '0'); /* [DX] Z 08 */
                linhaFormatada += $"{registro[128]}".Trim().PadLeft( 5, '0'); /* [DY] Z 05 */
                linhaFormatada += $"{registro[129]}".Trim().PadLeft( 5, '0');/* [DZ] Z 05 */
                linhaFormatada += $"{registro[130]}".Split(' ')[0].Trim().PadLeft(3,'0'); /* [EA] Z 03 */
                linhaFormatada += $"{registro[131]}".Trim().PadLeft( 13, '0');/* [EB] Z 13  */
                linhaFormatada += $"{registro[132]}".Trim().PadLeft( 13, '0'); /* [EC] Z 13 */
                linhaFormatada += $"{registro[133]}".Trim().PadLeft( 13, '0'); /* [ED] Z 13 */
                linhaFormatada += $"{registro[134]}".Split(' ')[0].Trim().PadRight(2); /* [EE] C 02 */
                linhaFormatada += $"{registro[135]}".Trim().PadRight(1); /* [EF] C 01 */
                linhaFormatada += $"{registro[136]}".Trim().PadLeft( 7, '0'); /* [EG] Z 07 */
                linhaFormatada += $"{registro[137]}".Trim().PadLeft( 15, '0'); /* [EH] Z 15 */
                linhaFormatada += $"{registro[138]}".Trim().PadLeft( 3, '0'); /* [EI] Z 03 */
                linhaFormatada += $"{registro[139]}".Split(' ')[0].Trim().PadLeft(1, '0'); /* [EJ] Z 01 */
                linhaFormatada += $"{registro[140]}".Split(' ')[0].Trim().PadRight(1); /* [EK] C 01 */
                linhaFormatada += "".PadRight(2); /* [EL] C 03 */
  
                conteudo += $"{linhaFormatada}\n";
            }
         
            return conteudo;
        }

        private static String ConverterDadosFinanceiros(DataTable aba)
        {
            string conteudo = "";
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                string linhaFormatada = "";
                linhaFormatada += "F2".PadRight(2); /* [A] C 02 */
                linhaFormatada += $"{i}".PadLeft(7,'0'); /* [B] Z 07 */
                linhaFormatada += $"{registro[2]}".Trim().PadLeft(2,'0'); /* [C] Z 02 */
                linhaFormatada += $"{registro[3]}".Trim().PadLeft(3,'0'); /* [D] Z 03 */
                linhaFormatada += $"{registro[4]}".Trim().PadLeft(3,'0'); /* [E] Z 03 */
                linhaFormatada += $"{registro[5]}".Trim().PadLeft(7,'0'); /* [F] Z 07 */
                linhaFormatada += "".PadRight(5); /* [G] C 05 */
                linhaFormatada += $"{registro[7]}".Split(' ')[0].Trim().PadLeft(2,'0'); /* [H] Z 02 */
                linhaFormatada += $"{registro[8]}".Split(' ')[0].Trim().PadLeft(4,'0'); /* [I] Z 04 */
                linhaFormatada += $"{registro[9]}".Trim().PadLeft(10,'0'); /* [J] Z 10 */
                linhaFormatada += $"{registro[10]}".Trim().PadLeft(2,'0'); /* [K] Z 02 */

                // a estrutura a seguir se repete por 30 entradas
                var index = 11;
                for (int j = 0; j < 30; j++)
                {
                    linhaFormatada += $"{registro[index]}".Trim().PadLeft(6,'0'); /* [L] Z 06 */
                    linhaFormatada += $"{registro[index + 1]}".Trim().PadLeft(13,'0'); /* [M] Z 13 */
                    linhaFormatada += $"{registro[index + 2]}".Split(' ')[0].Trim().PadRight(1); /* [N] C 01 */
                    linhaFormatada += $"{registro[index + 3]}".Split(' ')[0].Trim().PadRight(1); /* [O] C 01 */
                    linhaFormatada += $"{registro[index + 4]}".Split(' ')[0].Trim().PadRight(1); /* [P] C 01 */
                    index += 8;
                }

                linhaFormatada += "".PadRight(18); /* [JA] C 19 */
                conteudo += $"{linhaFormatada}\n";
            }

            return conteudo;
        }

        private static String ConverterDadosCargos(DataTable aba)
        {
            string conteudo = "";
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                string linhaFormatada = "";
                linhaFormatada += "TC".PadRight(2); /* [A] C 02 */
                linhaFormatada += $"{i}".PadLeft(7,'0'); /* [B] Z 07 */
                linhaFormatada += $"{registro[2]}".Trim().PadLeft(2, '0'); /* [C] Z 02 */
                linhaFormatada += $"{registro[3]}".Trim().PadLeft(3, '0'); /* [D] Z 03 */
                linhaFormatada += "".PadRight(33); /* [E] C 33 */
                linhaFormatada += $"{registro[5]}".Trim().PadLeft(7,'0'); /* [F] Z 07 */
                linhaFormatada += $"{registro[6]}".Trim().PadRight(30); /* [G] C 30 */
                linhaFormatada += "".PadRight(665); /* [H] C 666 */

                conteudo += $"{linhaFormatada}\n";
            }

            return conteudo;
        }

        private static String ConverterDadosVencimentos(DataTable aba)
        {
            string conteudo = "";
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                string linhaFormatada = "";
                linhaFormatada += "TV".PadRight(2); /* [A] C 02 */
                linhaFormatada += $"{i}".PadLeft(7,'0'); /* [B] Z 07 */
                linhaFormatada += $"{registro[2]}".Trim().PadLeft(2,'0'); /* [C] Z 02 */
                linhaFormatada += $"{registro[3]}".Trim().PadLeft(3,'0'); /* [D] Z 03 */
                linhaFormatada += "".PadRight(33); /* [E] C 33 */
                linhaFormatada += $"{registro[5]}".Trim().PadLeft(6,'0'); /* [F] Z 06 */
                linhaFormatada += $"{registro[6]}".Trim().PadRight(30); /* [G] C 30 */
                linhaFormatada += $"{registro[7]}".Split(' ')[0].PadRight(1); /* [H] C 01 */
                linhaFormatada += $"{registro[8]}".Split(' ')[0].PadRight(1); /* [I] C 01 */
                linhaFormatada += $"{registro[9]}".Split(' ')[0].PadLeft(2,'0'); /* [J] Z 02 */
                linhaFormatada += "".PadRight(662); /* [K] C 663 */

                conteudo += $"{linhaFormatada}\n";
            }

            return conteudo;
        }

        private static String ConverterDadosFaixas(DataTable aba)
        {
            string conteudo = "";
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                string linhaFormatada = "";
                linhaFormatada += "TF".PadRight(2); /* [A] C 02 */
                linhaFormatada += $"{i}".PadLeft(7,'0'); /* [B] Z 07 */
                linhaFormatada += $"{registro[2]}".Trim().PadLeft(2, '0'); /* [C] Z 02 */
                linhaFormatada += $"{registro[3]}".Trim().PadLeft(3, '0'); /* [D] Z 03 */
                linhaFormatada += "".PadRight(33); /* [E] C 33 */
                linhaFormatada += $"{registro[5]}".Trim().PadRight(10); /* [F] C 10 */
                linhaFormatada += $"{registro[6]}".Trim().PadLeft(13, '0'); /*[G] Z 13 */
                linhaFormatada += $"{registro[7]}".Trim().PadLeft(5, '0'); /* [H] Z 05 */
                linhaFormatada += $"{registro[8]}".Trim().PadLeft(13, '0'); /* [I] Z 13 */
                linhaFormatada += $"{registro[9]}".Trim().PadLeft(5, '0'); /* [J] Z 05 */
                linhaFormatada += $"{registro[10]}".Trim().PadLeft(13, '0'); /* [K] Z 13 */
                linhaFormatada += $"{registro[11]}".Trim().PadLeft(5, '0'); /* [L] Z 05 */
                linhaFormatada += $"{registro[12]}".Trim().PadLeft(13, '0'); /* [M] Z 13 */
                linhaFormatada += $"{registro[13]}".Trim().PadLeft(5, '0'); /* [N] Z 05 */
                linhaFormatada += "".PadRight(620); /* [O] C 621 */
                conteudo += $"{linhaFormatada}\n";
            }

            return conteudo;
        }

        private static String ConverterDadosUnidades(DataTable aba)
        {
            string conteudo = "";
            for (int i = 1; i < aba.Rows.Count; i++)
            {
                DataRow registro = aba.Rows[i];

                string linhaFormatada = "";
                linhaFormatada += "TU".PadRight(2); /* [A] C 02 */
                linhaFormatada += $"{i}".PadLeft(7,'0'); /* [B] Z 07 */
                linhaFormatada += $"{registro[2]}".Trim().PadLeft(2,'0'); /* [C] Z 02 */
                linhaFormatada += $"{registro[3]}".Trim().PadLeft(3,'0'); /* [D] Z 03 */
                linhaFormatada += "".PadRight(33); /* [E] C 33 */
                linhaFormatada += $"{registro[5]}".Trim().PadLeft(3,'0'); /* [F] Z 03 */
                linhaFormatada += $"{registro[6]}".Trim().PadLeft(7,'0'); /* [G] Z 07 */
                linhaFormatada += $"{registro[7]}".Trim().PadLeft(70,'0'); /* [H] C 70 */
                linhaFormatada += $"{registro[8]}".Trim().PadLeft(15,'0'); /* [I] Z 15 */
                linhaFormatada += $"{registro[9]}".Trim().PadLeft(70,'0'); /* [J] C 70 */
                linhaFormatada += "".PadRight(537); /* [K] C 538 */
                conteudo += $"{linhaFormatada}\n";
            }

            return conteudo;
            }
    }
}
