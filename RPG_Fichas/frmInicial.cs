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
    }
}
