using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RPG_Fichas
{
    public partial class frmListaFicha : Form
    {
        private string _connectionString = @"Data Source=C:\Users\eduar\Source\Repos\RPG_Fichas\RPG_Fichas\ficha.db;Version=3;";

        public frmListaFicha()
        {
            InitializeComponent();
            LoadFichas();
            dgvFichas.CellDoubleClick += dgvFichas_CellDoubleClick;
        }

        private void LoadFichas()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Ficha";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvFichas.DataSource = dataTable; // dgvFichas é o seu DataGridView
                    }
                }
            }
        }

        private void dgvFichas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;

                DataRowView rowView = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    int idFicha = Convert.ToInt32(rowView["idFicha"]);

                    frmFicha detalhesForm = new frmFicha
                    {
                        FichaId = idFicha // Passa o ID da ficha
                    };

                    detalhesForm.Show(); // Abre o formulário
                }

            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvFichas.SelectedRows.Count > 0) // Verifica se há linhas selecionadas
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();

                        DataGridViewRow selectedRow = dgvFichas.SelectedRows[0];
                        int idFicha = Convert.ToInt32(selectedRow.Cells["idFicha"].Value); // Obtém o ID da coluna "idFicha"

                        string query = "DELETE FROM Ficha WHERE idFicha = @idFicha";

                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idFicha", idFicha);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ficha deletada com sucesso!");
                                LoadFichas(); // Recarrega as fichas após a deleção
                            }
                            else
                            {
                                MessageBox.Show("Ficha não encontrada.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma ficha para deletar.");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmFicha detalhesForm = new frmFicha();
            detalhesForm.Show(); // Abre o formulário
        }
    }
}
