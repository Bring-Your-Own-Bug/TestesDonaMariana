using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloSerie;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinApp.ModuloMateria;
using TestesDonaMariana.WinApp.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaDetalhesTesteForm : Form
    {
        private Teste _teste;
        private ControladorTeste _ControladorQuestao;
        private List<Questao> ListaQuestao;
        private List<Teste> ListaTeste { get; set; }
        

        public TelaDetalhesTesteForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            ListaTeste = new ControladorTeste().ObterListaTeste();
            ListaQuestao = new ControladorTeste().ObterListaQuestao();
        }

        public Teste? Entidade
        {
            set
            {
                txtTitulo.Text = value.Titulo;
                txtDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                txtMateria.Text = value.Materia == null ? "Geral" : $"{value.Materia.Nome}, {value.Materia.Serie.ObterDescricao()}";
                listQuestoesSeleciondas.Items.AddRange(value.ListaQuestoes.ToArray());
                _teste = value;
            }

            get
            {
                return _teste;
            }
        }

        private void TelaDetalhesTeste_Load(object sender, EventArgs e)
        {
        }

        private void listQuestoesSeleciondas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtMateria_Click(object sender, EventArgs e)
        {

        }
    }
}
