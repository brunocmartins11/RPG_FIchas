namespace RPG_Fichas
{
    partial class frmListaFicha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvFichas = new DataGridView();
            btnNovo = new Button();
            btnDeletar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFichas).BeginInit();
            SuspendLayout();
            // 
            // dgvFichas
            // 
            dgvFichas.AllowUserToAddRows = false;
            dgvFichas.AllowUserToDeleteRows = false;
            dgvFichas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFichas.Location = new Point(79, 91);
            dgvFichas.Name = "dgvFichas";
            dgvFichas.ReadOnly = true;
            dgvFichas.Size = new Size(637, 286);
            dgvFichas.TabIndex = 0;
            dgvFichas.CellContentDoubleClick += dgvFichas_CellDoubleClick;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(79, 62);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnDeletar
            // 
            btnDeletar.Location = new Point(160, 62);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(75, 23);
            btnDeletar.TabIndex = 2;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // frmListaFicha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeletar);
            Controls.Add(btnNovo);
            Controls.Add(dgvFichas);
            Name = "frmListaFicha";
            Text = "frmListaFicha";
            ((System.ComponentModel.ISupportInitialize)dgvFichas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFichas;
        private Button btnNovo;
        private Button btnDeletar;
    }
}