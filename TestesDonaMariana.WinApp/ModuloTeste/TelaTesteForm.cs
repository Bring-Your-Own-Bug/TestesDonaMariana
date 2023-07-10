using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaTesteForm : Form, ITelaBase<Teste>
    {
        private Teste _teste;

        private bool _isValid;

        private readonly List<Questao> _listaQuestoesSorteadas;
        private List<Questao> ListaQuestao { get; set; }
        private List<Teste> ListaTeste { get; set; }
        private List<Materia> ListaMateria { get; set; }

        public TelaTesteForm()
        {
            InitializeComponent();

            _listaQuestoesSorteadas = new List<Questao>();
            ListaQuestao = ControladorTeste.ObterListaQuestao();
            ListaTeste = ControladorTeste.ObterListaTeste();
            ListaMateria = ControladorTeste.ObterListaMateria();
        }

        public Teste? Entidade
        {
            get => _teste;

            set
            {
                txtId.Text = value.Id.ToString();
                txtTitulo.Text = value.Titulo;
                cmbDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                ckbRecuperacao.Checked = value.Materia == null ? true : false;
                cmbMateria.Text = value.Materia == null ? "" : value.Materia.Nome;
                numQuestao.Value = value.NumeroDeQuestoes;
                listQuestoes.Items.AddRange(value.ListaQuestoes.ToArray());
                _listaQuestoesSorteadas.AddRange(value.ListaQuestoes);
                _teste = value;
            }
        }

        public Teste? DuplicarTeste
        {
            get => _teste;

            set
            {
                this.Text = "Duplicador de Teste";
                txtId.Text = value.Id.ToString();
                txtTitulo.Text = value.Titulo;
                cmbDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                ckbRecuperacao.Checked = value.Materia == null ? true : false;
                cmbMateria.Text = value.Materia == null ? "" : value.Materia.Nome;
                numQuestao.Value = value.NumeroDeQuestoes;
                value.ListaQuestoes.Clear();
                _teste = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            Disciplina? disciplina = cmbDisciplina.SelectedItem as Disciplina;
            Materia? materia = cmbMateria.SelectedItem as Materia;

            int numeroQuestoes = Convert.ToInt32(numQuestao.Value);

            Recuperacao recuperacao = ckbRecuperacao.Checked ? Recuperacao.Sim : Recuperacao.Nao;

            List<Questao> questoes = _listaQuestoesSorteadas;

            _teste = new Teste(txtTitulo.Text, numeroQuestoes, disciplina, materia, questoes, DateTime.Now, recuperacao);

            if (_teste.Id == 0)
                _teste.Id = Convert.ToInt32(txtId.Text);
        }

        private void ImplementarMetodos()
        {
            txtTitulo.TextChanged += ValidarCampos;
            cmbDisciplina.TextChanged += ValidarCampos;
            cmbMateria.TextChanged += ValidarCampos;
            numQuestao.ValueChanged += ValidarCampos;
            ckbRecuperacao.Click += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            lbErroDisciplina.Visible = false;
            lbErroMateria.Visible = false;
            lbErroTitulo.Visible = false;
            lbErroQuestoes.Visible = false;

            if (txtTitulo.Text.ValidarCampoVazio())
            {
                lbErroTitulo.Visible = true;
                lbErroTitulo.Text = "*Campo obrigatório";
            }
            else if (_teste != null && string.Equals(_teste.Titulo, txtTitulo.Text, StringComparison.OrdinalIgnoreCase) && _teste.ListaQuestoes.Count != 0) { }
            else if (ValidadorTeste.ValidarNomeExistente(txtTitulo.Text, ListaTeste))
            {
                lbErroTitulo.Visible = true;
                lbErroTitulo.Text = "*Esse teste já existe";
            }

            lbErroDisciplina.Visible = ValidadorTeste.ValidarDisciplinaExistente(cmbDisciplina.SelectedIndex);

            lbErroMateria.Visible = ValidadorTeste.ValidarMateriaExistente(cmbMateria.SelectedIndex, ckbRecuperacao.Checked);

            if (ValidadorTeste.ValidarListaQuestoes(listQuestoes.Items.Count))
            {
                lbErroQuestoes.Text = "*Deve ser gerado ao menos 1 questão";
                lbErroQuestoes.Visible = true;
            }

            if (lbErroDisciplina.Visible || lbErroTitulo.Visible || lbErroMateria.Visible || lbErroQtdQuestoes.Visible || lbErroQuestoes.Visible)
                _isValid = false;
            else
                _isValid = true;
        }

        private void GerarQuestoes(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            ImplementarMetodos();

            LimparListas();

            lbErroQtdQuestoes.Visible = false;
            lbErroNoQuestoes.Visible = false;

            Disciplina? disciplinaSelecionada = cmbDisciplina.SelectedItem as Disciplina;

            List<Questao> listaPorMateria;

            if (!lbErroMateria.Visible)
            {
                if (cmbMateria.SelectedItem is not Materia materiaSelecionada)
                {
                    listaPorMateria = ListaQuestao.FindAll(q => q.Disciplina.Id == disciplinaSelecionada.Id);

                    if (ValidarSeExisteQuestaoParaGerar(listaPorMateria.Count))
                    {
                        lbErroNoQuestoes.Text = "*Não há questões nas Matérias dessa Disciplina para gerar";
                        lbErroNoQuestoes.Visible = true;
                    }
                }
                else
                {
                    listaPorMateria = ListaQuestao.FindAll(a => a.Materia.Id == materiaSelecionada.Id);

                    if (ValidarSeExisteQuestaoParaGerar(listaPorMateria.Count))
                    {
                        lbErroNoQuestoes.Text = "*Não há questões na Matéria para gerar";
                        lbErroNoQuestoes.Visible = true;
                    }
                }

                if (ValidarQtdQuestoes(listaPorMateria.Count))
                {
                    lbErroQtdQuestoes.Visible = true;
                    return;
                }

                Random random = new();

                for (int i = 0; i < numQuestao.Value; i++)
                {
                    int indexRandom = random.Next((int)numQuestao.Value);

                    if (!listQuestoes.Items.Contains(listaPorMateria[indexRandom].Enunciado))
                    {
                        _listaQuestoesSorteadas.Add(listaPorMateria[indexRandom]);
                        listQuestoes.Items.Add(listaPorMateria[indexRandom].Enunciado);
                    }
                    else
                        i--;
                }

                if (listQuestoes.Items.Count > 0)
                    lbErroQuestoes.Visible = false;
            }
        }

        private void HabilitarEDesabilitarMateria(object sender, EventArgs e)
        {
            LimparListas();

            if (ckbRecuperacao.Checked)
            {
                cmbMateria.Enabled = false;
                cmbMateria.SelectedItem = null;
            }
            else cmbMateria.Enabled = true;
        }

        private void AtualizarComboBoxMateria(object sender, EventArgs e)
        {
            LimparListas();

            if (ListaMateria.Count == 0)
                ListaMateria = (List<Materia>)cmbMateria.DataSource;

            if (cmbDisciplina.SelectedIndex != -1)
            {
                Disciplina? disciplina = cmbDisciplina.SelectedItem as Disciplina;

                cmbMateria.DataSource = ListaMateria.FindAll(m => m.Disciplina.Id == disciplina.Id);
            }
        }

        private void ResetarComboBoxMateria(object sender, EventArgs e)
        {
            cmbMateria.SelectedIndex = -1;
        }

        private void ResetarLista(object sender, EventArgs e)
        {
            LimparListas();
        }

        private void LimparListas()
        {
            _listaQuestoesSorteadas.Clear();
            listQuestoes.Items.Clear();
        }

        private static bool ValidarSeExisteQuestaoParaGerar(int qtdQuestoesLista)
        {
            return qtdQuestoesLista == 0;
        }

        private bool ValidarQtdQuestoes(int count)
        {
            return numQuestao.Value > count;
        }

        private void TelaTesteForm_Shown(object sender, EventArgs e)
        {
            cmbDisciplina.SelectedIndexChanged += ResetarComboBoxMateria;
        }
    }
}
