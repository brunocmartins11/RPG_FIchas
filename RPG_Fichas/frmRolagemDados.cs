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

        private void btnRolagem_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var client = new HttpClient();
            string apiUrl = $"https://rpg-dice-roller-api.djpeacher.com/api/roll/{txtQuantidade.Text}d{txtLados.Text}";
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            using HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;
                var resultado = JsonSerializer.Deserialize<Dado>(jsonString, options);

                if (resultado != null)
                {
                    MessageBox.Show($"O total da sua rolagem foi. {resultado.Output}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
