namespace ComercioSistema
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
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnClassificacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(70, 34);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(207, 59);
            this.btnCliente.TabIndex = 10;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Location = new System.Drawing.Point(419, 34);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(207, 59);
            this.btnFornecedor.TabIndex = 11;
            this.btnFornecedor.Text = "Fornecedores";
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // btnProduto
            // 
            this.btnProduto.Location = new System.Drawing.Point(419, 155);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(207, 59);
            this.btnProduto.TabIndex = 13;
            this.btnProduto.Text = "Produtos";
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnClassificacao
            // 
            this.btnClassificacao.Location = new System.Drawing.Point(70, 155);
            this.btnClassificacao.Name = "btnClassificacao";
            this.btnClassificacao.Size = new System.Drawing.Size(207, 59);
            this.btnClassificacao.TabIndex = 12;
            this.btnClassificacao.Text = "Classificação Produto";
            this.btnClassificacao.UseVisualStyleBackColor = true;
            this.btnClassificacao.Click += new System.EventHandler(this.btnClassificacao_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 282);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.btnClassificacao);
            this.Controls.Add(this.btnFornecedor);
            this.Controls.Add(this.btnCliente);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnClassificacao;
    }
}

