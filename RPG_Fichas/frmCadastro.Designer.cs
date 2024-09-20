namespace RPG_Fichas
{
    partial class frmCadastro
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
            txt_Usuario = new TextBox();
            txt_senha = new TextBox();
            btn_Cadastro = new Button();
            lbl_seguranca = new Label();
            SuspendLayout();
            // 
            // txt_Usuario
            // 
            txt_Usuario.Location = new Point(229, 110);
            txt_Usuario.Name = "txt_Usuario";
            txt_Usuario.Size = new Size(276, 23);
            txt_Usuario.TabIndex = 0;
            // 
            // txt_senha
            // 
            txt_senha.Location = new Point(229, 226);
            txt_senha.Name = "txt_senha";
            txt_senha.Size = new Size(276, 23);
            txt_senha.TabIndex = 1;
            txt_senha.TextChanged += txt_senha_TextChanged;
            // 
            // btn_Cadastro
            // 
            btn_Cadastro.Location = new Point(321, 303);
            btn_Cadastro.Name = "btn_Cadastro";
            btn_Cadastro.Size = new Size(75, 23);
            btn_Cadastro.TabIndex = 2;
            btn_Cadastro.Text = "Cadastro";
            btn_Cadastro.UseVisualStyleBackColor = true;
            btn_Cadastro.Click += Cadastro_Click;
            // 
            // lbl_seguranca
            // 
            lbl_seguranca.AutoSize = true;
            lbl_seguranca.Location = new Point(338, 252);
            lbl_seguranca.Name = "lbl_seguranca";
            lbl_seguranca.Size = new Size(0, 15);
            lbl_seguranca.TabIndex = 3;
            // 
            // frmCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_seguranca);
            Controls.Add(btn_Cadastro);
            Controls.Add(txt_senha);
            Controls.Add(txt_Usuario);
            Name = "frmCadastro";
            Text = "frmCadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Usuario;
        private TextBox txt_senha;
        private Button btn_Cadastro;
        private Label lbl_seguranca;
    }
}