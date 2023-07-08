using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaTesteForm : Form, ITelaBase<Teste>
    {
        private Teste _teste;

        private bool isValid;

        private List<Questao> listaQuestoesSorteadas = new();
        private List<Questao> ListaQuestao { get; set; }
        private List<Teste> ListaTeste { get; set; }
        private List<Materia> ListaMateria { get; set; }

        private ControladorTeste _controladorTeste;
        public TelaTesteForm()
        {
            InitializeComponent();

            _controladorTeste = new ControladorTeste();
            ListaQuestao = _controladorTeste.ObterListaQuestao();
            ListaTeste = _controladorTeste.ObterListaTeste();
            ListaMateria = _controladorTeste.ObterListaMateria();
        }

        public Teste? Entidade
        {
            get => _teste;

            set
            {
                txtId.Text = value.Id.ToString();
                txtTitulo.Text = value.Titulo;
                cmbDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                cmbMateria.Text = value.Materia == null ? "" : value.Materia.Nome;
                ckbRecuperacao.Checked = value.Materia == null ? true : false;
                numQuestao.Value = value.NumeroDeQuestoes;
                listQuestoes.Items.AddRange(value.ListaQuestoes.ToArray());
                _teste = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }


            Disciplina? disciplina = cmbDisciplina.SelectedItem as Disciplina;
            Materia? materia = cmbMateria.SelectedItem as Materia;

            int numeroQuestoes = Convert.ToInt32(numQuestao.Value);

            Recuperacao recuperacao = ckbRecuperacao.Checked ? Recuperacao.Sim : Recuperacao.Nao;

            List<Questao> questoes = listaQuestoesSorteadas;

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
            Teste teste = new();

            lbErroDisciplina.Visible = false;
            lbErroMateria.Visible = false;
            lbErroTitulo.Visible = false;

            if (teste.ValidarCampoVazio(txtTitulo.Text))
            {
                lbErroTitulo.Visible = true;
                lbErroTitulo.Text = "*Campo obrigatório";
            }
            else if (_teste != null && string.Equals(_teste.Titulo, txtTitulo.Text, StringComparison.OrdinalIgnoreCase)) { }
            else if (teste.ValidarNomeExistente(txtTitulo.Text, ListaTeste))
            {
                lbErroTitulo.Visible = true;
                lbErroTitulo.Text = "*Esse teste já existe";
            }

            lbErroDisciplina.Visible = teste.ValidarDisciplinaExistente(cmbDisciplina.SelectedIndex);

            lbErroMateria.Visible = teste.ValidarMateriaExistente(cmbMateria.SelectedIndex, ckbRecuperacao.Checked);

            if (lbErroDisciplina.Visible || lbErroTitulo.Visible || lbErroMateria.Visible)
                isValid = false;
            else
                isValid = true;
        }

        private void btnGerarQuestao_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            LimparListas();

            lbErroQtdQuestoes.Visible = false;

            Materia? materiaSelecionada = cmbMateria.SelectedItem as Materia;

            Disciplina? disciplinaSelecionada = cmbDisciplina.SelectedItem as Disciplina;

            List<Questao> listaPorMateria;

            if (!lbErroMateria.Visible)
            {
                if (materiaSelecionada == null)
                    listaPorMateria = ListaQuestao.FindAll(q => q.Disciplina.Id == disciplinaSelecionada.Id);
                else
                    listaPorMateria = ListaQuestao.FindAll(a => a.Materia.Id == materiaSelecionada.Id);

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
                        listaQuestoesSorteadas.Add(listaPorMateria[indexRandom]);
                        listQuestoes.Items.Add(listaPorMateria[indexRandom].Enunciado);
                    }
                    else
                        i--;
                }
            }
        }

        private void LimparListas()
        {
            listaQuestoesSorteadas.Clear();
            listQuestoes.Items.Clear();
        }

        private bool ValidarQtdQuestoes(int count)
        {
            return numQuestao.Value > count;
        }

        private void ckbRecuperacao_CheckedChanged(object sender, EventArgs e)
        {
            LimparListas();

            if (ckbRecuperacao.Checked)
            {
                cmbMateria.Enabled = false;
                cmbMateria.SelectedItem = null;
            }
            else cmbMateria.Enabled = true;
        }

        private void cmbDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparListas();

            if (ListaMateria.Count == 0)
                ListaMateria = (List<Materia>)cmbMateria.DataSource;

            if (cmbDisciplina.SelectedIndex != -1)
            {
                Disciplina disciplina = cmbDisciplina.SelectedItem as Disciplina;

                cmbMateria.DataSource = ListaMateria.FindAll(m => m.Disciplina.Id == disciplina.Id);
            }
        }

        private void cmbMateria_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparListas();
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
