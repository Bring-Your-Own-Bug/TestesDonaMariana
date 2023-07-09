using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaDetalhesTesteForm : Form
    {
        private Teste _teste;        

        public TelaDetalhesTesteForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public Teste? Entidade
        {
            get => _teste;

            set
            {
                txtTitulo.Text = value.Titulo;
                txtDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                txtMateria.Text = value.Materia == null ? "Geral" : $"{value.Materia.Nome}, {value.Materia.Serie.ObterDescricao()}";
                listQuestoesSeleciondas.Items.AddRange(value.ListaQuestoes.ToArray());
                _teste = value;
            }
        }
    }
}
