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

        private int _contador;

        private List<Teste> ListaTeste { get; set; }
        public TelaTesteForm()
        {
            InitializeComponent();

            ListaTeste = new ControladorTeste().ObterListaTeste();

            _contador = 0;
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

            lbErroNome.Visible = false;

            if (teste.ValidarCampoVazio(txtTitulo.Text))
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Campo obrigatório";
            }
            else if (_teste != null && string.Equals(_teste.Titulo, txtTitulo.Text, StringComparison.OrdinalIgnoreCase)) { }
            else if (teste.ValidarNomeExistente(txtTitulo.Text, ListaTeste))
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Esse teste já existe";
            }

            if (lbErroNome.Visible)
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
                cmbMateria.SelectedItem = null;
            }
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_contador >= 1)
            cmbMateria.SelectedItem = null;

            _contador = 1;
        }
    }
}
