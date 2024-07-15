namespace RPG_Fichas
{
    partial class frmRolagemDados
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
            label1 = new Label();
            label2 = new Label();
            txtQuantidade = new TextBox();
            txtLados = new TextBox();
            btnRolagem = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 116);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 0;
            label1.Text = "Quantidade dos Dados";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 186);
            label2.Name = "label2";
            label2.Size = new Size(167, 15);
            label2.TabIndex = 1;
            label2.Text = "Quantidade de Lados do Dado";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(47, 134);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(124, 23);
            txtQuantidade.TabIndex = 2;
            // 
            // txtLados
            // 
            txtLados.Location = new Point(47, 204);
            txtLados.Name = "txtLados";
            txtLados.Size = new Size(124, 23);
            txtLados.TabIndex = 3;
            // 
            // btnRolagem
            // 
            btnRolagem.Location = new Point(47, 274);
            btnRolagem.Name = "btnRolagem";
            btnRolagem.Size = new Size(124, 23);
            btnRolagem.TabIndex = 4;
            btnRolagem.Text = "Rolar Dado(s)";
            btnRolagem.UseVisualStyleBackColor = true;
            btnRolagem.Click += btnRolagem_Click;
            // 
            // Form_RolagemDados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 450);
            Controls.Add(btnRolagem);
            Controls.Add(txtLados);
            Controls.Add(txtQuantidade);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form_RolagemDados";
            Text = "Form_RolagemDados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtQuantidade;
        private TextBox txtLados;
        private Button btnRolagem;
    }
}