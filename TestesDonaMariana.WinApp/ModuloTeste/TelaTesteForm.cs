using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaTesteForm : Form, ITelaBase<Teste>
    {
        private Teste _teste;

        private bool isValid;
        public TelaTesteForm()
        {
            InitializeComponent();
        }

        public Teste? Entidade
        {
            get => _teste;

            set
            {
                txtTitulo.Text = value.Titulo;
                cmbDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                cmbMateria.Text = value.Materia == null ? "" : value.Materia.Nome;
            }
        }
    }
}
