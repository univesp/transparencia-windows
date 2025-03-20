
namespace TransparenciaWindows
{
    partial class Form1
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
            this.btnCarregarPlanilhaMensal = new System.Windows.Forms.Button();
            this.btnConverter = new System.Windows.Forms.Button();
            this.cbxTipoArquivo = new System.Windows.Forms.ComboBox();
            this.webCabecalho = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCaminhoPlanilhaMensal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCarregarPlanilhaMensal
            // 
            this.btnCarregarPlanilhaMensal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarPlanilhaMensal.Location = new System.Drawing.Point(28, 410);
            this.btnCarregarPlanilhaMensal.Name = "btnCarregarPlanilhaMensal";
            this.btnCarregarPlanilhaMensal.Size = new System.Drawing.Size(199, 34);
            this.btnCarregarPlanilhaMensal.TabIndex = 0;
            this.btnCarregarPlanilhaMensal.Text = "Carregar planilha";
            this.btnCarregarPlanilhaMensal.UseVisualStyleBackColor = true;
            this.btnCarregarPlanilhaMensal.Click += new System.EventHandler(this.btnCarregarPlanilhaMensal_Click);
            // 
            // btnConverter
            // 
            this.btnConverter.BackColor = System.Drawing.Color.LightGreen;
            this.btnConverter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConverter.Location = new System.Drawing.Point(197, 586);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(123, 43);
            this.btnConverter.TabIndex = 1;
            this.btnConverter.Text = "Converter";
            this.btnConverter.UseVisualStyleBackColor = false;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // cbxTipoArquivo
            // 
            this.cbxTipoArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoArquivo.FormattingEnabled = true;
            this.cbxTipoArquivo.Items.AddRange(new object[] {
            "TXT do Portal da Transparência",
            "TXT do IAMSPE",
            "XML de Cadastro de Verbas Remuneratórias (AUDESP)",
            "XML de Folha Ordinária (AUDESP)",
            "XML de Pagamento da Folha Ordinária (AUDESP)",
            "XML de Resumo Mensal da Folha Ordinária (AUDESP)"});
            this.cbxTipoArquivo.Location = new System.Drawing.Point(28, 519);
            this.cbxTipoArquivo.Name = "cbxTipoArquivo";
            this.cbxTipoArquivo.Size = new System.Drawing.Size(653, 28);
            this.cbxTipoArquivo.TabIndex = 2;
            // 
            // webCabecalho
            // 
            this.webCabecalho.AllowNavigation = false;
            this.webCabecalho.Location = new System.Drawing.Point(28, 12);
            this.webCabecalho.MinimumSize = new System.Drawing.Size(20, 20);
            this.webCabecalho.Name = "webCabecalho";
            this.webCabecalho.ScrollBarsEnabled = false;
            this.webCabecalho.Size = new System.Drawing.Size(653, 319);
            this.webCabecalho.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "1) Carregue a planilha mensal:";
            // 
            // lblCaminhoPlanilhaMensal
            // 
            this.lblCaminhoPlanilhaMensal.AutoSize = true;
            this.lblCaminhoPlanilhaMensal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaminhoPlanilhaMensal.Location = new System.Drawing.Point(233, 417);
            this.lblCaminhoPlanilhaMensal.Name = "lblCaminhoPlanilhaMensal";
            this.lblCaminhoPlanilhaMensal.Size = new System.Drawing.Size(210, 20);
            this.lblCaminhoPlanilhaMensal.TabIndex = 6;
            this.lblCaminhoPlanilhaMensal.Text = "Nenhum arquivo carregado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "2) Selecione o tipo de arquivo a ser gerado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(715, 697);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCaminhoPlanilhaMensal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webCabecalho);
            this.Controls.Add(this.cbxTipoArquivo);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.btnCarregarPlanilhaMensal);
            this.Name = "Form1";
            this.Text = "Transparência UNIVESP - v1.0";
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
    }
}

