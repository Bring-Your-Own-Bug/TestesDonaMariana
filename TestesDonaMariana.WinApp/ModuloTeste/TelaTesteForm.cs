using FluentResults;
using System.Linq;
using TestesDonaMariana.Aplicacao.Compartilhado;
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

        private Result _resultado = new();

        public event Func<Teste, bool, Result> OnGravarRegistro;

        private List<Questao> ListaQuestao { get; set; }
        private List<Materia> ListaMateria { get; set; }

        public TelaTesteForm()
        {
            InitializeComponent();

            ListaQuestao = ControladorTeste.ObterListaQuestao();
            ListaMateria = ControladorTeste.ObterListaMateria();
            _teste = new Teste();
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
                rdPrimeiraSerie.Checked = ckbRecuperacao.Checked && value.Serie == Serie.Primeira;
                rdSegundaSerie.Checked = ckbRecuperacao.Checked && value.Serie == Serie.Segunda;
                numQuestao.Value = value.NumeroDeQuestoes;
                listQuestoes.Items.AddRange(value.ListaQuestoes.ToArray());
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
                rdPrimeiraSerie.Checked = ckbRecuperacao.Checked && value.Serie == Serie.Primeira;
                rdSegundaSerie.Checked = ckbRecuperacao.Checked && value.Serie == Serie.Segunda;
                numQuestao.Value = value.NumeroDeQuestoes;
                value.ListaQuestoes.Clear();
                _teste = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_resultado.IsFailed)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
            }
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
            ResetarErros();

            Disciplina? disciplina = cmbDisciplina.SelectedItem as Disciplina;

            Materia? materia = cmbMateria.SelectedItem as Materia;

            int numeroQuestoes = Convert.ToInt32(numQuestao.Value);

            Serie serieSelecao = rdPrimeiraSerie.Checked ? Serie.Primeira : Serie.Segunda;

            Serie serie = ckbRecuperacao.Checked ? serieSelecao : materia == null ? serieSelecao : materia.Serie;

            Recuperacao recuperacao = ckbRecuperacao.Checked ? Recuperacao.Sim : Recuperacao.Nao;

            List<Questao> questoes = listQuestoes.Items.Cast<Questao>().ToList();

            _teste = new Teste(txtTitulo.Text, numeroQuestoes, disciplina, materia, serie, questoes, DateTime.Now, recuperacao);

            if (_teste.Id == 0)
                _teste.Id = Convert.ToInt32(txtId.Text);

            _resultado = OnGravarRegistro(_teste, sender == btnAdd);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
            {
                switch (item.PropertyName)
                {
                    case "Titulo": lbErroTitulo.Text = item.ErrorMessage; lbErroTitulo.Visible = true; break;
                    case "Disciplina": lbErroDisciplina.Text = item.ErrorMessage; lbErroDisciplina.Visible = true; break;
                    case "Materia": lbErroMateria.Text = item.ErrorMessage; lbErroMateria.Visible = true; break;
                    case "Questoes": lbErroQuestoes.Text = item.ErrorMessage; lbErroQuestoes.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroDisciplina.Visible = false;
            lbErroMateria.Visible = false;
            lbErroTitulo.Visible = false;
            lbErroQuestoes.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }

        private void GerarQuestoes(object sender, EventArgs e)
        {
            ImplementarMetodos();

            LimparListas();

            Disciplina? disciplinaSelecionada = cmbDisciplina.SelectedItem as Disciplina;

            List<Questao> listaQuestoesPorMateria;

            if (!lbErroMateria.Visible)
            {
                if (cmbMateria.SelectedItem is not Materia materiaSelecionada)
                {
                    Serie serie = rdPrimeiraSerie.Checked ? Serie.Primeira : Serie.Segunda;

                    listaQuestoesPorMateria = ListaQuestao.FindAll(q => q.Disciplina.Id == disciplinaSelecionada.Id && q.Materia.Serie == serie);

                    listQuestoes.Items.AddRange(_teste.SortearQuestoes(listaQuestoesPorMateria, (int)numQuestao.Value).ToArray());
                }
                else
                {
                    listaQuestoesPorMateria = ListaQuestao.FindAll(a => a.Materia.Id == materiaSelecionada.Id);

                    listQuestoes.Items.AddRange(_teste.SortearQuestoes(listaQuestoesPorMateria, (int)numQuestao.Value).ToArray());
                }
            }

            ResetarErros();

            ValidarCampos(sender, e);
        }

        private void HabilitarEDesabilitarMateria(object sender, EventArgs e)
        {
            LimparListas();

            if (ckbRecuperacao.Checked)
            {
                cmbMateria.Enabled = false;
                cmbMateria.SelectedItem = null;
                plSerie.Enabled = true;
            }
            else
            {
                cmbMateria.Enabled = true;
                plSerie.Enabled = false;
            }
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
            listQuestoes.Items.Clear();
        }

        private void TelaTesteForm_Shown(object sender, EventArgs e)
        {
            cmbDisciplina.SelectedIndexChanged += ResetarComboBoxMateria;
        }
    }
}
