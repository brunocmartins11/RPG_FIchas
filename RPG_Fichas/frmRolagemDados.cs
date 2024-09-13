using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG_Fichas.Models;

namespace RPG_Fichas
{
    public partial class frmRolagemDados : Form
    {
        public frmRolagemDados()
        {
            InitializeComponent();
        }

        private async void btnRolagem_Click(object sender, EventArgs e)
        {
            // Cria e exibe o formulário de carregamento
            using (var carregandoForm = new frmCarregando())
            {
                // Exibe o formulário de carregamento de forma modal
                carregandoForm.StartPosition = FormStartPosition.CenterParent;
                carregandoForm.Show(this);

                // Execute a operação assíncrona
                await Task.Run(() => ExecuteLongRunningOperation());

                // Fecha o formulário de carregamento
                carregandoForm.Invoke(new Action(() =>
                {
                    carregandoForm.Close();
                }));
            }
        }

        private void ExecuteLongRunningOperation()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d4";
            using var client = new HttpClient();
            RadioButton[] radioButtons = new RadioButton[]
            {
        radioButton0,
        radioButton1,
        radioButton2,
        radioButton3,
        radioButton4,
        radioButton5,
        radioButton6
            };
            int selectedIndex = -1;
            for (int i = 0; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked)
                {
                    selectedIndex = i;
                    break;
                }
            }

            switch (selectedIndex)
            {
                case -1:
                    return;
                case 0:
                    apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d4";
                    break;
                case 1:
                    apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d6";
                    break;
                case 2:
                    apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d8";
                    break;
                case 3:
                    apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d10";
                    break;
                case 4:
                    apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d12";
                    break;
                case 5:
                    apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d20";
                    break;
                case 6:
                    apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d100";
                    break;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            using HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;
                var resultado = JsonSerializer.Deserialize<Dado>(jsonString, options);

                if (resultado != null)
                {
                    // Atualiza a interface do usuário com o resultado (deve ser feito na thread principal)
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"O total da sua rolagem foi. {resultado.Output}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
            }
        }


    }
}
