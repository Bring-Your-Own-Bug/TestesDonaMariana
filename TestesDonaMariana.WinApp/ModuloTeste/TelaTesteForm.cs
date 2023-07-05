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
        public TelaTesteForm()
        {
            InitializeComponent();

            ListaTeste = new ControladorTeste().ObterListaTeste();
        }

        public Teste? Entidade
        {
            get => _teste;

            set
            {
                
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

            List<Questao> questoes = new();

            foreach (Questao questao in listQuestoes.Items)
            {
                questoes.Add(questao);
            }

            _teste = new Teste(txtTitulo.Text, numeroQuestoes, disciplina, materia, questoes, DateTime.Now, recuperacao)
            {
                Id = 0
            };
        }

        private void ImplementarMetodos()
        {
            txtTitulo.TextChanged += ValidarCampos;
            cmbDisciplina.TextChanged += ValidarCampos;
            cmbMateria.TextChanged += ValidarCampos;
            numQuestao.ValueChanged += ValidarCampos;
            ckbRecuperacao.CheckedChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Teste teste = new();

            Recuperacao recuperacao = ckbRecuperacao.Checked ? Recuperacao.Sim : Recuperacao.Nao;

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
            listQuestoes.Items.Add(new Questao { Enunciado = "Qual é a capital do Brasil?"});
            listQuestoes.Items.Add(new Questao { Enunciado = "Quem descobriu o Brasil?"});
            listQuestoes.Items.Add(new Questao { Enunciado = "Quanto é 2 + 2?"});
        }
    }
}
