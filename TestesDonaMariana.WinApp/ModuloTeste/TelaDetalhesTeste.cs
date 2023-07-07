using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.WinApp.ModuloMateria;
using TestesDonaMariana.WinApp.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaDetalhesTeste : Form
    {
        private Teste _teste;
        private ControladorTeste _ControladorQuestao;
        private List<Questao> listaQuestao;
        private List<Teste> ListaTeste { get; set; }


        public TelaDetalhesTeste()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            ListaTeste = new ControladorTeste().ObterListaTeste();

            listaQuestao = new ControladorTeste().ObterListaQuestao();
        }

        public Teste? Entidade
        {
            set
            {
                txtTitulo.Text = value.Titulo;
                txtDisciplina.Text = value.Disciplina.Nome;
                txtMateria.Text = value.Materia.Nome;
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
    }
}
