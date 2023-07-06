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

        private List<Teste> ListaTeste { get; set; }
        private List<Materia> ListaMateria { get; set; }

        private ControladorTeste _controladorTeste;
        public TelaTesteForm()
        {
            InitializeComponent();

            _controladorTeste = new ControladorTeste();
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

            List<Questao> questoes = listQuestoes.Items.Cast<Questao>().ToList();

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
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Teste teste = new();

            lbErroDisciplina.Visible = false;

            if (teste.ValidarCampoVazio(txtTitulo.Text))
            {
                lbErroDisciplina.Visible = true;
                lbErroDisciplina.Text = "*Campo obrigatório";
            }
            else if (_teste != null && string.Equals(_teste.Titulo, txtTitulo.Text, StringComparison.OrdinalIgnoreCase)) { }
            else if (teste.ValidarNomeExistente(txtTitulo.Text, ListaTeste))
            {
                lbErroDisciplina.Visible = true;
                lbErroDisciplina.Text = "*Esse teste já existe";
            }
            else if (teste.ValidarDisciplinaExistente(cmbDisciplina.SelectedIndex))
            {
                lbErroDisciplina.Visible = true;
                lbErroDisciplina.Text = "*teste";
            }
            else if (teste.ValidarMateriaExistente(cmbMateria.SelectedIndex, ckbRecuperacao.Checked))
            {
                lbErroDisciplina.Visible = true;
                lbErroDisciplina.Text = "*teste";
            }

            if (lbErroDisciplina.Visible)
                isValid = false;
            else
                isValid = true;
        }

        private void btnGerarQuestao_Click(object sender, EventArgs e)
        {

        }

        private void ckbRecuperacao_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbRecuperacao.Checked)
            {
                cmbMateria.Enabled = false;
                cmbMateria.SelectedItem = null;
            }
            else cmbMateria.Enabled = true;
        }

        private void cmbDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListaMateria.Count == 0)
                ListaMateria = (List<Materia>)cmbMateria.DataSource;

            if (cmbDisciplina.SelectedIndex != -1)
            {
                Disciplina disciplina = cmbDisciplina.SelectedItem as Disciplina;

                cmbMateria.DataSource = ListaMateria.FindAll(m => m.Disciplina.Id == disciplina.Id);
            }
        }

        //private void numQuestao_ValueChanged(object sender, EventArgs e)
        //{
        //    if (cmbMateria != null)
        //        ListaMateria
        //}
    }
}
