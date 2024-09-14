using System.Data.SqlClient;

namespace RPG_Fichas
{


    public partial class frmFicha : Form
    {
        private string _connectionString = "Server=localhost;Database=fichasrpg;User Id=root;Password=;";

        public frmFicha()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    // Adicione aqui o código para executar comandos SQL, por exemplo:
                    // SqlCommand command = new SqlCommand("INSERT INTO Tabela (Coluna) VALUES (@valor)", connection);
                    // command.Parameters.AddWithValue("@valor", valor);
                    // command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        private void cbx_classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            chk_forca.Checked = false;
            chk_destreza.Checked = false;
            chk_constituicao.Checked = false;
            chk_inteligencia.Checked = false;
            chk_sabedoria.Checked = false;
            chk_carisma.Checked = false;
            switch (cbx_classe.SelectedIndex)
            {
                case 0:
                    chk_forca.Checked = true;
                    chk_constituicao.Checked = true;
                    break;
                case 1:
                    chk_inteligencia.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
                case 2:
                    chk_destreza.Checked = true;
                    chk_inteligencia.Checked = true;
                    break;
                case 3:
                    chk_forca.Checked = true;
                    chk_destreza.Checked = true;
                    break;
                case 4:
                    chk_constituicao.Checked = true;
                    chk_carisma.Checked = true;
                    break;
                case 5:
                    chk_inteligencia.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
                case 6:
                    chk_carisma.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
                case 7:
                    chk_carisma.Checked = true;
                    chk_destreza.Checked = true;
                    break;
                case 8:
                    chk_forca.Checked = true;
                    chk_constituicao.Checked = true;
                    break;
                case 9:
                    chk_sabedoria.Checked = true;
                    chk_carisma.Checked = true;
                    break;
                case 10:
                    chk_forca.Checked = true;
                    chk_destreza.Checked = true;
                    break;
                case 11:
                    chk_carisma.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
            }
        }

        private void numeric_nivel_ValueChanged(object sender, EventArgs e)
        {
            if (numeric_nivel.Value > 0 && numeric_nivel.Value < 5)
            {
                lbl_proficiencia.Text = "+2";
            }
            else if (numeric_nivel.Value >= 5 && numeric_nivel.Value < 9)
            {
                lbl_proficiencia.Text = "+3";
            }
            else if (numeric_nivel.Value >= 9 && numeric_nivel.Value < 13)
            {
                lbl_proficiencia.Text = "+4";
            }
            else if (numeric_nivel.Value >= 13 && numeric_nivel.Value < 17)
            {
                lbl_proficiencia.Text = "+5";
            }
            else if (numeric_nivel.Value >= 17 && numeric_nivel.Value <= 20)
            {
                lbl_proficiencia.Text = "+6";
            }
        }



        private void cbx_raca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_forca.Text = $"0";
            txt_destreza.Text = $"0";
            txt_constituicao.Text = $"0";
            txt_sabedoria.Text = $"0";
            txt_inteligencia.Text = $"0";
            txt_carisma.Text = $"0";

            switch (cbx_raca.SelectedIndex)
            {

                case 0:
                    txt_forca.Text = $"{Convert.ToInt32(txt_forca.Text) + 1}";
                    txt_destreza.Text = $"{Convert.ToInt32(txt_destreza.Text) + 1}";
                    txt_constituicao.Text = $"{Convert.ToInt32(txt_constituicao.Text) + 1}";
                    txt_sabedoria.Text = $"{Convert.ToInt32(txt_sabedoria.Text) + 1}";
                    txt_inteligencia.Text = $"{Convert.ToInt32(txt_inteligencia.Text) + 1}";
                    txt_carisma.Text = $"{Convert.ToInt32(txt_carisma.Text) + 1}";
                    break;
                case 1:
                    txt_destreza.Text = $"{Convert.ToInt32(txt_destreza.Text) + 2}";
                    txt_inteligencia.Text = $"{Convert.ToInt32(txt_inteligencia.Text) + 1}";
                    break;
                case 2:
                    txt_forca.Text = $"{Convert.ToInt32(txt_forca.Text) + 2}";
                    txt_constituicao.Text = $"{Convert.ToInt32(txt_constituicao.Text) + 2}";
                    break;
                case 3:
                    txt_destreza.Text = $"{Convert.ToInt32(txt_destreza.Text) + 2}";
                    txt_carisma.Text = $"{Convert.ToInt32(txt_carisma.Text) + 1}";
                    break;
            }

        }

        private void txt_forca_TextChanged(object sender, EventArgs e)
        {
            AtualizarModificador(txt_forca, lbl_forca_atributo);
        }

        private void txt_destreza_TextChanged(object sender, EventArgs e)
        {
            AtualizarModificador(txt_destreza, lbl_destreza_atributo);
        }

        private void txt_constituicao_TextChanged(object sender, EventArgs e)
        {
            AtualizarModificador(txt_constituicao, lbl_constituicao_atributo);
        }

        private void txt_inteligencia_TextChanged(object sender, EventArgs e)
        {
            AtualizarModificador(txt_inteligencia, lbl_inteligencia_atributo);
        }

        private void txt_sabedoria_TextChanged(object sender, EventArgs e)
        {
            AtualizarModificador(txt_sabedoria, lbl_sabedoria_atributo);
        }

        private void txt_carisma_TextChanged(object sender, EventArgs e)
        {
            AtualizarModificador(txt_carisma, lbl_carisma_atributo);
        }

        private void AtualizarModificador(TextBox textBox, Label label)
        {
            int valorAtributo;

            // Tenta converter o texto para um número inteiro
            if (int.TryParse(textBox.Text, out valorAtributo))
            {
                // Calcula o modificador de habilidade
                int modificador = (valorAtributo - 10) / 2;

                // Atualiza o rótulo com o modificador
                label.Text = modificador.ToString();
            }
            else
            {
                // Se a conversão falhar, exibe um valor padrão ou uma mensagem de erro
                label.Text = "Inválido";
            }
        }

        private void txt_destreza_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_constituicao_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_inteligencia_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_sabedoria_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_carisma_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
