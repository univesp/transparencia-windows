
namespace TransparenciaWindows
{
    partial class frmAplicacao
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAplicacao));
            this.btnCarregarPlanilhaMensal = new System.Windows.Forms.Button();
            this.btnConverter = new System.Windows.Forms.Button();
            this.cbxTipoArquivo = new System.Windows.Forms.ComboBox();
            this.webCabecalho = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCaminhoPlanilhaMensal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCarregarPlanilhaContabil = new System.Windows.Forms.Button();
            this.lblCaminhoPlanilhaContabil = new System.Windows.Forms.Label();
            this.lnkArquivoGerado = new System.Windows.Forms.LinkLabel();
            this.pnlArquivosDownload = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkPlanilhaMesclada = new System.Windows.Forms.LinkLabel();
            this.lnkReiniciarAplicacao = new System.Windows.Forms.LinkLabel();
            this.pnlArquivosDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCarregarPlanilhaMensal
            // 
            this.btnCarregarPlanilhaMensal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarPlanilhaMensal.Location = new System.Drawing.Point(21, 321);
            this.btnCarregarPlanilhaMensal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCarregarPlanilhaMensal.Name = "btnCarregarPlanilhaMensal";
            this.btnCarregarPlanilhaMensal.Size = new System.Drawing.Size(149, 28);
            this.btnCarregarPlanilhaMensal.TabIndex = 0;
            this.btnCarregarPlanilhaMensal.Text = "Carregar planilha";
            this.btnCarregarPlanilhaMensal.UseVisualStyleBackColor = true;
            this.btnCarregarPlanilhaMensal.Click += new System.EventHandler(this.btnCarregarPlanilhaMensal_Click);
            // 
            // btnConverter
            // 
            this.btnConverter.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConverter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConverter.Location = new System.Drawing.Point(22, 610);
            this.btnConverter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(489, 35);
            this.btnConverter.TabIndex = 1;
            this.btnConverter.Text = "Converter";
            this.btnConverter.UseVisualStyleBackColor = false;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // cbxTipoArquivo
            // 
            this.cbxTipoArquivo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoArquivo.FormattingEnabled = true;
            this.cbxTipoArquivo.Items.AddRange(new object[] {
            "TXT do Portal da Transparência",
            "TXT do IAMSPE",
            "XML de Cadastro de Verbas Remuneratórias (AUDESP)",
            "XML de Folha Ordinária (AUDESP)",
            "XML de Pagamento da Folha Ordinária (AUDESP)",
            "XML de Resumo Mensal da Folha Ordinária (AUDESP)"});
            this.cbxTipoArquivo.Location = new System.Drawing.Point(21, 556);
            this.cbxTipoArquivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxTipoArquivo.Name = "cbxTipoArquivo";
            this.cbxTipoArquivo.Size = new System.Drawing.Size(489, 27);
            this.cbxTipoArquivo.TabIndex = 2;
            // 
            // webCabecalho
            // 
            this.webCabecalho.AllowNavigation = false;
            this.webCabecalho.Location = new System.Drawing.Point(21, 10);
            this.webCabecalho.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.webCabecalho.MinimumSize = new System.Drawing.Size(15, 16);
            this.webCabecalho.Name = "webCabecalho";
            this.webCabecalho.ScrollBarsEnabled = false;
            this.webCabecalho.Size = new System.Drawing.Size(490, 259);
            this.webCabecalho.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "1) Carregue a planilha mensal:";
            // 
            // lblCaminhoPlanilhaMensal
            // 
            this.lblCaminhoPlanilhaMensal.AutoSize = true;
            this.lblCaminhoPlanilhaMensal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaminhoPlanilhaMensal.Location = new System.Drawing.Point(175, 326);
            this.lblCaminhoPlanilhaMensal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaminhoPlanilhaMensal.Name = "lblCaminhoPlanilhaMensal";
            this.lblCaminhoPlanilhaMensal.Size = new System.Drawing.Size(177, 19);
            this.lblCaminhoPlanilhaMensal.TabIndex = 6;
            this.lblCaminhoPlanilhaMensal.Text = "Nenhum arquivo carregado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 525);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "3) Selecione o tipo de arquivo a ser gerado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 377);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "2) Carregue a planilha da contabilidade (*):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 453);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(501, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCarregarPlanilhaContabil
            // 
            this.btnCarregarPlanilhaContabil.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarPlanilhaContabil.Location = new System.Drawing.Point(22, 410);
            this.btnCarregarPlanilhaContabil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCarregarPlanilhaContabil.Name = "btnCarregarPlanilhaContabil";
            this.btnCarregarPlanilhaContabil.Size = new System.Drawing.Size(149, 28);
            this.btnCarregarPlanilhaContabil.TabIndex = 10;
            this.btnCarregarPlanilhaContabil.Text = "Carregar planilha";
            this.btnCarregarPlanilhaContabil.UseVisualStyleBackColor = true;
            this.btnCarregarPlanilhaContabil.Click += new System.EventHandler(this.btnCarregarPlanilhaContabil_Click);
            // 
            // lblCaminhoPlanilhaContabil
            // 
            this.lblCaminhoPlanilhaContabil.AutoSize = true;
            this.lblCaminhoPlanilhaContabil.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaminhoPlanilhaContabil.Location = new System.Drawing.Point(175, 415);
            this.lblCaminhoPlanilhaContabil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaminhoPlanilhaContabil.Name = "lblCaminhoPlanilhaContabil";
            this.lblCaminhoPlanilhaContabil.Size = new System.Drawing.Size(177, 19);
            this.lblCaminhoPlanilhaContabil.TabIndex = 11;
            this.lblCaminhoPlanilhaContabil.Text = "Nenhum arquivo carregado";
            // 
            // lnkArquivoGerado
            // 
            this.lnkArquivoGerado.AutoSize = true;
            this.lnkArquivoGerado.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkArquivoGerado.Location = new System.Drawing.Point(26, 41);
            this.lnkArquivoGerado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkArquivoGerado.Name = "lnkArquivoGerado";
            this.lnkArquivoGerado.Size = new System.Drawing.Size(104, 19);
            this.lnkArquivoGerado.TabIndex = 13;
            this.lnkArquivoGerado.TabStop = true;
            this.lnkArquivoGerado.Text = "Arquivo gerado";
            this.lnkArquivoGerado.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkArquivoGerado_LinkClicked);
            // 
            // pnlArquivosDownload
            // 
            this.pnlArquivosDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlArquivosDownload.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlArquivosDownload.Controls.Add(this.label8);
            this.pnlArquivosDownload.Controls.Add(this.label7);
            this.pnlArquivosDownload.Controls.Add(this.label6);
            this.pnlArquivosDownload.Controls.Add(this.label5);
            this.pnlArquivosDownload.Controls.Add(this.lnkPlanilhaMesclada);
            this.pnlArquivosDownload.Controls.Add(this.lnkArquivoGerado);
            this.pnlArquivosDownload.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlArquivosDownload.Location = new System.Drawing.Point(22, 704);
            this.pnlArquivosDownload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlArquivosDownload.Name = "pnlArquivosDownload";
            this.pnlArquivosDownload.Size = new System.Drawing.Size(489, 163);
            this.pnlArquivosDownload.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(434, 39);
            this.label8.TabIndex = 15;
            this.label8.Text = resources.GetString("label8.Text");
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 67);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "🡻";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "🡻";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Arquivos para download (**):";
            // 
            // lnkPlanilhaMesclada
            // 
            this.lnkPlanilhaMesclada.AutoSize = true;
            this.lnkPlanilhaMesclada.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPlanilhaMesclada.Location = new System.Drawing.Point(26, 67);
            this.lnkPlanilhaMesclada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkPlanilhaMesclada.Name = "lnkPlanilhaMesclada";
            this.lnkPlanilhaMesclada.Size = new System.Drawing.Size(116, 19);
            this.lnkPlanilhaMesclada.TabIndex = 14;
            this.lnkPlanilhaMesclada.TabStop = true;
            this.lnkPlanilhaMesclada.Text = "Planilha mesclada";
            this.lnkPlanilhaMesclada.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPlanilhaMesclada_LinkClicked);
            // 
            // lnkReiniciarAplicacao
            // 
            this.lnkReiniciarAplicacao.AutoSize = true;
            this.lnkReiniciarAplicacao.Location = new System.Drawing.Point(220, 665);
            this.lnkReiniciarAplicacao.Name = "lnkReiniciarAplicacao";
            this.lnkReiniciarAplicacao.Size = new System.Drawing.Size(102, 13);
            this.lnkReiniciarAplicacao.TabIndex = 15;
            this.lnkReiniciarAplicacao.TabStop = true;
            this.lnkReiniciarAplicacao.Text = "Reiniciar aplicação";
            this.lnkReiniciarAplicacao.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReiniciarAplicacao_LinkClicked);
            // 
            // frmAplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(536, 862);
            this.Controls.Add(this.lnkReiniciarAplicacao);
            this.Controls.Add(this.pnlArquivosDownload);
            this.Controls.Add(this.lblCaminhoPlanilhaContabil);
            this.Controls.Add(this.btnCarregarPlanilhaContabil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCaminhoPlanilhaMensal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webCabecalho);
            this.Controls.Add(this.cbxTipoArquivo);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.btnCarregarPlanilhaMensal);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAplicacao";
            this.Text = "Transparência UNIVESP - v1.0";
            this.pnlArquivosDownload.ResumeLayout(false);
            this.pnlArquivosDownload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCarregarPlanilhaMensal;
        private System.Windows.Forms.Button btnConverter;
        private System.Windows.Forms.ComboBox cbxTipoArquivo;
        private System.Windows.Forms.WebBrowser webCabecalho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCaminhoPlanilhaMensal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCarregarPlanilhaContabil;
        private System.Windows.Forms.Label lblCaminhoPlanilhaContabil;
        private System.Windows.Forms.LinkLabel lnkArquivoGerado;
        private System.Windows.Forms.Panel pnlArquivosDownload;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkPlanilhaMesclada;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lnkReiniciarAplicacao;
    }
}

