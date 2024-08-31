using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Fichas
{
    public partial class frmCarregando : Form
    {
        public frmCarregando()
        {
            InitializeComponent();
            // Customize the form for loading indication (e.g., a spinning wheel or "Loading..." message)
            this.Text = "Carregando...";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.BackColor = Color.White;
            this.ClientSize = new Size(200, 100);
            Label loadingLabel = new Label
            {
                Text = "Por favor, aguarde...",
                AutoSize = true,
                Location = new Point(50, 40)
            };
            this.Controls.Add(loadingLabel);
        }
    }
}
