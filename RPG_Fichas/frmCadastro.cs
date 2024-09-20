using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Fichas
{
    public partial class frmCadastro : Form
    {
        private string _connectionString = @"Data Source=C:\Users\eduar\Source\Repos\RPG_Fichas\RPG_Fichas\ficha.db;Version=3;";
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {
            string senha = txt_senha.Text;
            if (senha.Length < 8)
            {
                lbl_seguranca.Text = "A senha deve ter pelo menos 8 caracteres.";
            }

            if (!Regex.IsMatch(senha, @"[A-Z]"))
            {
                lbl_seguranca.Text = "A senha deve conter pelo menos uma letra maiúscula.";
            }

            if (!Regex.IsMatch(senha, @"[a-z]"))
            {
                lbl_seguranca.Text = "A senha deve conter pelo menos uma letra minúscula.";
            }

            if (!Regex.IsMatch(senha, @"[0-9]"))
            {
                lbl_seguranca.Text = "A senha deve conter pelo menos um número.";
            }

            if (!Regex.IsMatch(senha, @"[\W_]")) // caracteres especiais
            {
                lbl_seguranca.Text = "A senha deve conter pelo menos um caractere especial.";
            }

            lbl_seguranca.Text = "A senha é forte.";
        }
    }
}
