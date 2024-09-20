using RPG_Fichas.Models;
using System.Text.Json;

namespace RPG_Fichas
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
        }
        private void btnRolagem_Click(object sender, EventArgs e)
        {
            var rolarDados = new frmRolagemDados();
            rolarDados.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

        }

        private void frmInicial_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            frmCadastro cadastro = new frmCadastro();
            cadastro.Show();
        }
    }
}
