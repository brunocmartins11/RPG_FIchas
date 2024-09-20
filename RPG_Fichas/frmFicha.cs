using System.Data.SQLite; // Import SQLite library
using Microsoft.VisualBasic.PowerPacks;

namespace RPG_Fichas
{
    public partial class frmFicha : Form
    {
        public int FichaId { get; set; }

        private string _connectionString = @"Data Source=C:\Users\eduar\Source\Repos\RPG_Fichas\RPG_Fichas\ficha.db;Version=3;";

        Dictionary<string, List<CheckBox>> periciasAntecedentes = new Dictionary<string, List<CheckBox>>();

        public frmFicha()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmFicha_Load);
        }

        private void frmFicha_Load(object sender, EventArgs e)
        {
            if (FichaId > 0) // Verifica se o ID da ficha é válido
            {
                LoadFichaData();
                InicializarAntecedentes();
            }
        }

        private void InicializarAntecedentes()
        {
            // Antecedente: Acólito (Acolyte)
            periciasAntecedentes["Acólito"] = new List<CheckBox> { chk_religiao, chk_intuicao };

            // Antecedente: Artesão de Guilda (Guild Artisan)
            periciasAntecedentes["Artesão de Guilda"] = new List<CheckBox> { chk_intuicao, chk_persuasao };

            // Antecedente: Charlatão (Charlatan)
            periciasAntecedentes["Charlatão"] = new List<CheckBox> { chk_enganacao, chk_prestidigitacao };

            // Antecedente: Criminoso (Criminal)
            periciasAntecedentes["Criminoso"] = new List<CheckBox> { chk_furtividade, chk_enganacao };

            // Antecedente: Eremita (Hermit)
            periciasAntecedentes["Eremita"] = new List<CheckBox> { chk_medicina, chk_religiao };

            // Antecedente: Forasteiro (Outlander)
            periciasAntecedentes["Forasteiro"] = new List<CheckBox> { chk_sobrevivencia, chk_animais };

            // Antecedente: Herói do Povo (Folk Hero)
            periciasAntecedentes["Herói do Povo"] = new List<CheckBox> { chk_animais, chk_sobrevivencia };

            // Antecedente: Marinheiro (Sailor)
            periciasAntecedentes["Marinheiro"] = new List<CheckBox> { chk_atletismo, chk_percepcao };

            // Antecedente: Nobre (Noble)
            periciasAntecedentes["Nobre"] = new List<CheckBox> { chk_historia, chk_persuasao };

            // Antecedente: Órfão (Urchin)
            periciasAntecedentes["Órfão"] = new List<CheckBox> { chk_furtividade, chk_prestidigitacao };

            // Antecedente: Sábio (Sage)
            periciasAntecedentes["Sábio"] = new List<CheckBox> { chk_arcanismo, chk_historia };

            // Antecedente: Soldado (Soldier)
            periciasAntecedentes["Soldado"] = new List<CheckBox> { chk_atletismo, chk_intimidacao };

            // Antecedente: Artista (Entertainer)
            periciasAntecedentes["Artista"] = new List<CheckBox> { chk_atuacao, chk_acrobacia };
        }

        private void LoadFichaData()
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para carregar os dados da ficha
                    string queryFicha = "SELECT * FROM Ficha WHERE idFicha = @idFicha";
                    using (SQLiteCommand command = new SQLiteCommand(queryFicha, connection))
                    {
                        command.Parameters.AddWithValue("@idFicha", FichaId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_nome_personagem.Text = reader["nomePersonagem"].ToString();
                                numeric_nivel.Value = Convert.ToInt32(reader["nivel"]);
                                cbx_classe.SelectedItem = reader["classe"].ToString();
                                cbx_raca.SelectedItem = reader["raca"].ToString();
                                cbx_antecedente.Text = reader["antecedente"].ToString();
                                txt_alinhamento.Text = reader["alinhamento"].ToString();
                                txt_HP.Text = reader["pontosVida"].ToString();
                                txt_CA.Text = reader["ca"].ToString();
                                txt_deslocamento.Text = reader["deslocamento"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Ficha não encontrada.");
                                return; // Sai do método se a ficha não for encontrada
                            }
                        }
                    }

                    // Consulta para carregar os atributos relacionados à ficha
                    string queryAtributos = "SELECT * FROM Atributos WHERE idAtributos = @idFicha";
                    using (SQLiteCommand command = new SQLiteCommand(queryAtributos, connection))
                    {
                        command.Parameters.AddWithValue("@idFicha", FichaId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Popula os campos do formulário com os dados dos atributos
                                txt_forca.Text = reader["forca"].ToString();
                                txt_destreza.Text = reader["destreza"].ToString();
                                txt_constituicao.Text = reader["constituicao"].ToString();
                                txt_inteligencia.Text = reader["inteligencia"].ToString();
                                txt_sabedoria.Text = reader["sabedoria"].ToString();
                                txt_carisma.Text = reader["carisma"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Atributos não encontrados.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        private void SelecionarPericiasDoAntecedente(string antecedente)
        {
            foreach (CheckBox chk in periciasAntecedentes.SelectMany(kvp => kvp.Value))
            {
                chk.Checked = false;
            }

            if (periciasAntecedentes.ContainsKey(antecedente))
            {
                foreach (CheckBox chk in periciasAntecedentes[antecedente])
                {
                    chk.Checked = true;
                }
            }
        }

        private String AtualizarModificador(TextBox textBox, Label label)
        {
            int valorAtributo;

            // Tenta converter o texto para um número inteiro
            if (int.TryParse(textBox.Text, out valorAtributo))
            {
                // Calcula o modificador de habilidade
                int modificador = (valorAtributo - 10) / 2;

                // Atualiza o rótulo com o modificador
                label.Text = modificador.ToString();

                return modificador.ToString();
            }
            else
            {
                // Se a conversão falhar, exibe um valor padrão ou uma mensagem de erro
                label.Text = "Inválido";

                return "";
            }
        }

        private void AtualizarPericia(CheckBox checkBox, Label label, int proficiencia)
        {
            // Verifica se a label contém um número válido
            int valorAtual;
            if (!int.TryParse(label.Text, out valorAtual))
            {
                MessageBox.Show($"Erro: {label.Name} não contém um número válido. Definindo valor atual como 0.");
                valorAtual = 0; // ou trate de outra forma
            }

            if (checkBox.Checked)
            {
                label.Text = (valorAtual + proficiencia).ToString();
                MessageBox.Show($"{label.Name} atualizado para {label.Text} (Adicionado {proficiencia})");
            }
            else
            {
                label.Text = (valorAtual - proficiencia).ToString();
                MessageBox.Show($"{label.Name} atualizado para {label.Text} (Subtraído {proficiencia})");
            }
        }
        private void AtualizarProficiencia()
        {
            // Tente converter o nível de proficiência
            int nivelDeProficiencia;
            if (!int.TryParse(lbl_proficiencia.Text, out nivelDeProficiencia))
            {
                MessageBox.Show("Erro: lbl_proficiencia não contém um número válido.");
                return; // Encerra a função se não for um número válido
            }
            MessageBox.Show($"Nível de Proficiência: {nivelDeProficiencia}");

            // Lista de todas as checkboxes que você está monitorando
            List<CheckBox> checkboxes = new List<CheckBox>
    {
        chk_forca,
        chk_destreza,
        chk_constituicao,
        chk_inteligencia,
        chk_sabedoria,
        chk_carisma,
        chk_acrobacia,
        chk_enganacao,
        chk_intuicao,
        chk_natureza,
        chk_arcanismo,
        chk_furtividade,
        chk_investigacao,
        chk_percepcao,
        chk_religiao,
        chk_atletismo,
        chk_historia,
        chk_animais,
        chk_persuasao,
        chk_sobrevivencia,
        chk_atuacao,
        chk_intimidacao,
        chk_medicina,
        chk_prestidigitacao
    };

            // Atualiza cada perícia com base nas checkboxes marcadas
            foreach (var chk in checkboxes)
            {
                if (chk.Checked)
                {
                    // Atualiza a perícia associada ao checkbox
                    string nomeSemPrefixo = chk.Name.Replace("chk_", "");
                    Label lbl = (Label)this.Controls.Find("lbl_" + nomeSemPrefixo, true).FirstOrDefault();
                    MessageBox.Show($"Atualizando: {lbl} com a proficiência de {nivelDeProficiencia}");
                    if (lbl != null)
                    {
                        MessageBox.Show($"Atualizando: {lbl.Name} com a proficiência de {nivelDeProficiencia}");
                        AtualizarPericia(chk, lbl, nivelDeProficiencia);
                    }
                    else
                    {
                        MessageBox.Show($"Erro: Label não encontrada para {chk.Name}");
                    }
                }
            }
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Obtendo os valores dos campos do formulário
                    string nomePersonagem = txt_nome_personagem.Text;
                    string nomePlayer = txt_nome_jogador.Text;
                    int nivel = (int)numeric_nivel.Value;
                    string classe = cbx_classe.Text;
                    string raca = cbx_raca.Text;
                    string antecedente = cbx_antecedente.Text;
                    string alinhamento = txt_alinhamento.Text;
                    int pontosVida = int.Parse(txt_HP.Text);
                    int ca = int.Parse(txt_CA.Text);
                    int deslocamento = int.Parse(txt_deslocamento.Text);

                    // Comando SQL para inserir a nova ficha
                    string queryFicha = @"
        INSERT INTO Ficha (nomePersonagem, nomePlayer, nivel, classe, raca, antecedente, alinhamento, pontosVida, ca, deslocamento)
        VALUES (@nomePersonagem, @nomePlayer, @nivel, @classe, @raca, @antecedente, @alinhamento, @pontosVida, @ca, @deslocamento);
        SELECT last_insert_rowid();"; // Obtendo o ID da ficha criada

                    int idFicha;

                    using (SQLiteCommand command = new SQLiteCommand(queryFicha, connection))
                    {
                        // Adicionando os parâmetros ao comando
                        command.Parameters.AddWithValue("@nomePersonagem", nomePersonagem);
                        command.Parameters.AddWithValue("@nomePlayer", nomePlayer);
                        command.Parameters.AddWithValue("@nivel", nivel);
                        command.Parameters.AddWithValue("@classe", classe);
                        command.Parameters.AddWithValue("@raca", raca);
                        command.Parameters.AddWithValue("@antecedente", string.IsNullOrEmpty(antecedente) ? (object)DBNull.Value : antecedente);
                        command.Parameters.AddWithValue("@alinhamento", string.IsNullOrEmpty(alinhamento) ? (object)DBNull.Value : alinhamento);
                        command.Parameters.AddWithValue("@pontosVida", pontosVida);
                        command.Parameters.AddWithValue("@ca", ca);
                        command.Parameters.AddWithValue("@deslocamento", deslocamento);

                        // Executando o comando e obtendo o ID da nova ficha
                        idFicha = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Comando SQL para inserir os atributos relacionados com a ficha
                    string queryAtributos = @"
        INSERT INTO Atributos (idAtributos, forca, destreza, constituicao, inteligencia, sabedoria, carisma)
        VALUES (@idFicha, @forca, @destreza, @constituicao, @inteligencia, @sabedoria, @carisma)";

                    using (SQLiteCommand command = new SQLiteCommand(queryAtributos, connection))
                    {
                        // Aqui você deve definir os valores dos atributos, por exemplo:
                        int forca = int.Parse(txt_forca.Text);
                        int destreza = int.Parse(txt_destreza.Text);
                        int constituicao = int.Parse(txt_constituicao.Text);
                        int inteligencia = int.Parse(txt_inteligencia.Text);
                        int sabedoria = int.Parse(txt_sabedoria.Text);
                        int carisma = int.Parse(txt_carisma.Text);

                        // Adicionando os parâmetros ao comando
                        command.Parameters.AddWithValue("@idFicha", idFicha);
                        command.Parameters.AddWithValue("@forca", forca);
                        command.Parameters.AddWithValue("@destreza", destreza);
                        command.Parameters.AddWithValue("@constituicao", constituicao);
                        command.Parameters.AddWithValue("@inteligencia", inteligencia);
                        command.Parameters.AddWithValue("@sabedoria", sabedoria);
                        command.Parameters.AddWithValue("@carisma", carisma);

                        // Executando o comando
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ficha cadastrada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        /*

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Obtendo os valores dos campos do formulário
                    int idFicha = int.Parse(txt_id_ficha.Text);
                    string nomePersonagem = txt_nome_personagem.Text;
                    int nivel = (int)numeric_nivel.Value; // Use Value instead of Text
                    string classe = cbx_classe.Text;
                    string raca = cbx_raca.Text;
                    string antecedente = txt_antecedente.Text;
                    string alinhamento = txt_alinhamento.Text;
                    int pontosVida = int.Parse(txt_HP.Text);
                    int ca = int.Parse(txt_CA.Text);
                    int deslocamento = int.Parse(txt_deslocamento.Text);

                    // Comando SQL para atualizar a ficha
                    string query = @"
                    UPDATE Ficha
                    SET nomePersonagem = @nomePersonagem,
                        nivel = @nivel,
                        classe = @classe,
                        raca = @raca,
                        antecedente = @antecedente,
                        alinhamento = @alinhamento,
                        pontosVida = @pontosVida,
                        ca = @ca,
                        deslocamento = @deslocamento
                    WHERE idFicha = @idFicha";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Adicionando os parâmetros ao comando
                        command.Parameters.AddWithValue("@idFicha", idFicha);
                        command.Parameters.AddWithValue("@nomePersonagem", nomePersonagem);
                        command.Parameters.AddWithValue("@nivel", nivel);
                        command.Parameters.AddWithValue("@classe", classe);
                        command.Parameters.AddWithValue("@raca", raca);
                        command.Parameters.AddWithValue("@antecedente", string.IsNullOrEmpty(antecedente) ? (object)DBNull.Value : antecedente);
                        command.Parameters.AddWithValue("@alinhamento", string.IsNullOrEmpty(alinhamento) ? (object)DBNull.Value : alinhamento);
                        command.Parameters.AddWithValue("@pontosVida", pontosVida);
                        command.Parameters.AddWithValue("@ca", ca);
                        command.Parameters.AddWithValue("@deslocamento", deslocamento);

                        // Executando o comando
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ficha atualizada com sucesso!");
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
        }*/

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
                case 0: // Bárbaro
                    chk_forca.Checked = true;
                    chk_constituicao.Checked = true;
                    break;
                case 1: // Bardo
                    chk_inteligencia.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
                case 2: // Bruxo
                    chk_destreza.Checked = true;
                    chk_inteligencia.Checked = true;
                    break;
                case 3: // Clérigo
                    chk_forca.Checked = true;
                    chk_destreza.Checked = true;
                    break;
                case 4: // Druida
                    chk_constituicao.Checked = true;
                    chk_carisma.Checked = true;
                    break;
                case 5: // Feiticeiro
                    chk_inteligencia.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
                case 6: // Guerreiro
                    chk_carisma.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
                case 7: // Ladino
                    chk_carisma.Checked = true;
                    chk_destreza.Checked = true;
                    break;
                case 8: // Mago
                    chk_forca.Checked = true;
                    chk_constituicao.Checked = true;
                    break;
                case 9: // Monge
                    chk_sabedoria.Checked = true;
                    chk_carisma.Checked = true;
                    break;
                case 10: // Paladino
                    chk_forca.Checked = true;
                    chk_destreza.Checked = true;
                    break;
                case 11: // Patrulheiro
                    chk_carisma.Checked = true;
                    chk_sabedoria.Checked = true;
                    break;
            }
        }

        private void numeric_nivel_ValueChanged(object sender, EventArgs e)
        {
            string proficienciaAntes = lbl_proficiencia.Text;

            int nivel = (int)numeric_nivel.Value;

            int proficiencia = (nivel < 5) ? 2 :
                               (nivel < 9) ? 3 :
                               (nivel < 13) ? 4 :
                               (nivel < 17) ? 5 :
                               (nivel <= 20) ? 6 : 0;
            lbl_proficiencia.Text = $"{proficiencia}";
            if (proficienciaAntes != Convert.ToString(proficiencia))
            {
                AtualizarProficiencia();
            }
        }

        private void cbx_raca_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void cbx_antecedente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string antecedenteSelecionado = cbx_antecedente.SelectedItem.ToString();
            SelecionarPericiasDoAntecedente(antecedenteSelecionado);
        }

        private void txt_forca_TextChanged(object sender, EventArgs e)
        {
            String modificador = AtualizarModificador(txt_forca, lbl_forca_atributo);

            lbl_atletismo.Text = modificador; // Atletismo
            lbl_forca_salvaguarda.Text = modificador;

        }

        private void txt_destreza_TextChanged(object sender, EventArgs e)
        {
            String modificador = AtualizarModificador(txt_destreza, lbl_destreza_atributo);

            lbl_acrobacia.Text = modificador; // Acrobacia
            lbl_prestidifitacao.Text = modificador; // Sutileza
            lbl_furtividade.Text = modificador; // Furtividade
            lbl_destreza_salvaguarda.Text = modificador;
        }

        private void txt_constituicao_TextChanged(object sender, EventArgs e)
        {
            String modificador = AtualizarModificador(txt_constituicao, lbl_constituicao_atributo);

            lbl_constituicao_salvaguarda.Text = modificador;
        }


        private void txt_inteligencia_TextChanged(object sender, EventArgs e)
        {
            String modificador = AtualizarModificador(txt_inteligencia, lbl_inteligencia_atributo);

            lbl_arcanismo.Text = modificador; // Amanhã
            lbl_historia.Text = modificador; // História
            lbl_investigacao.Text = modificador; // Investigação
            lbl_religiao.Text = modificador; // Religião
            lbl_natureza.Text = modificador;

            lbl_inteligencia_salvaguarda.Text = modificador;

        }

        private void txt_sabedoria_TextChanged(object sender, EventArgs e)
        {
            String modificador = AtualizarModificador(txt_sabedoria, lbl_sabedoria_atributo);

            lbl_animais.Text = modificador; // Lidar com Animais
            lbl_medicina.Text = modificador; // Medicina
            lbl_percepcao.Text = modificador; // Percepção
            lbl_sobrevivencia.Text = modificador;
            lbl_intuicao.Text = modificador;

            lbl_sabedoria_salvaguarda.Text = modificador;
        }

        private void txt_carisma_TextChanged(object sender, EventArgs e)
        {
            String modificador = AtualizarModificador(txt_carisma, lbl_carisma_atributo);

            lbl_atuacao.Text = modificador; // Atuação
            lbl_intimidacao.Text = modificador; // Intimidação
            lbl_persuasao.Text = modificador; // Persuasão
            lbl_enganacao.Text = modificador; // Enganação


            lbl_carisma_salvaguarda.Text = modificador;
        }

        private void chk_forca_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarPericia(chk_forca, lbl_forca_salvaguarda, Convert.ToInt32(lbl_proficiencia.Text));
        }

        private void chk_destreza_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarPericia(chk_destreza, lbl_destreza_salvaguarda, Convert.ToInt32(lbl_proficiencia.Text));
        }

        private void chk_constituicao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarPericia(chk_constituicao, lbl_constituicao_salvaguarda, Convert.ToInt32(lbl_proficiencia.Text));
        }

        private void chk_inteligencia_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarPericia(chk_inteligencia, lbl_inteligencia_salvaguarda, Convert.ToInt32(lbl_proficiencia.Text));
        }

        private void chk_sabedoria_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarPericia(chk_sabedoria, lbl_sabedoria_salvaguarda, Convert.ToInt32(lbl_proficiencia.Text));
        }

        private void chk_carisma_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarPericia(chk_carisma, lbl_carisma_salvaguarda, Convert.ToInt32(lbl_proficiencia.Text));
        }

        private void chk_acrobacia_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
                }

        private void chk_enganacao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_intuicao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_natureza_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_arcanismo_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_furtividade_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_investigacao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_percepcao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_religiao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_atletismo_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_historia_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_animais_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_persuasao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_sobrevivencia_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_atuacao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_intimidacao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_medicina_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }

        private void chk_prestidigitacao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarProficiencia();
        }


    }
}
