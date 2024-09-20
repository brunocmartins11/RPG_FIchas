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
            btnRolagem = new Button();
            groupBox1 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton1 = new RadioButton();
            radioButton0 = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 156);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 0;
            label1.Text = "Quantidade dos Dados";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 249);
            label2.Name = "label2";
            label2.Size = new Size(214, 20);
            label2.TabIndex = 1;
            label2.Text = "Quantidade de Lados do Dado";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(161, 180);
            txtQuantidade.Margin = new Padding(3, 4, 3, 4);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(141, 27);
            txtQuantidade.TabIndex = 2;
            // 
            // btnRolagem
            // 
            btnRolagem.Location = new Point(161, 478);
            btnRolagem.Margin = new Padding(3, 4, 3, 4);
            btnRolagem.Name = "btnRolagem";
            btnRolagem.Size = new Size(142, 31);
            btnRolagem.TabIndex = 4;
            btnRolagem.Text = "Rolar Dado(s)";
            btnRolagem.UseVisualStyleBackColor = true;
            btnRolagem.Click += btnRolagem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton5);
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton6);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton0);
            groupBox1.Location = new Point(122, 272);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(229, 143);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(149, 81);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(57, 24);
            radioButton5.TabIndex = 5;
            radioButton5.TabStop = true;
            radioButton5.Text = "D20";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(21, 81);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(57, 24);
            radioButton4.TabIndex = 4;
            radioButton4.TabStop = true;
            radioButton4.Text = "D12";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(149, 51);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(57, 24);
            radioButton3.TabIndex = 3;
            radioButton3.TabStop = true;
            radioButton3.Text = "D10";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(21, 51);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(49, 24);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "D8";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(84, 111);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(65, 24);
            radioButton6.TabIndex = 6;
            radioButton6.TabStop = true;
            radioButton6.Text = "D100";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(149, 19);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(49, 24);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "D6";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton0
            // 
            radioButton0.AutoSize = true;
            radioButton0.Location = new Point(21, 21);
            radioButton0.Name = "radioButton0";
            radioButton0.Size = new Size(49, 24);
            radioButton0.TabIndex = 0;
            radioButton0.TabStop = true;
            radioButton0.Text = "D4";
            radioButton0.UseVisualStyleBackColor = true;
            // 
            // frmRolagemDados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 600);
            Controls.Add(groupBox1);
            Controls.Add(btnRolagem);
            Controls.Add(txtQuantidade);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRolagemDados";
            Text = "Form_RolagemDados";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtQuantidade;
        private Button btnRolagem;
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton6;
        private RadioButton radioButton1;
        private RadioButton radioButton0;
        private RadioButton radioButton5;
    }
}