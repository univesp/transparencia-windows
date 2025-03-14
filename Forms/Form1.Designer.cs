
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
            this.SuspendLayout();
            // 
            // btnCarregarPlanilhaMensal
            // 
            this.btnCarregarPlanilhaMensal.Location = new System.Drawing.Point(28, 31);
            this.btnCarregarPlanilhaMensal.Name = "btnCarregarPlanilhaMensal";
            this.btnCarregarPlanilhaMensal.Size = new System.Drawing.Size(136, 23);
            this.btnCarregarPlanilhaMensal.TabIndex = 0;
            this.btnCarregarPlanilhaMensal.Text = "Carregar planilha";
            this.btnCarregarPlanilhaMensal.UseVisualStyleBackColor = true;
            this.btnCarregarPlanilhaMensal.Click += new System.EventHandler(this.btnCarregarPlanilhaMensal_Click);
            // 
            // btnConverter
            // 
            this.btnConverter.Location = new System.Drawing.Point(28, 70);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(99, 23);
            this.btnConverter.TabIndex = 1;
            this.btnConverter.Text = "Converter";
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.btnCarregarPlanilhaMensal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCarregarPlanilhaMensal;
        private System.Windows.Forms.Button btnConverter;
    }
}

