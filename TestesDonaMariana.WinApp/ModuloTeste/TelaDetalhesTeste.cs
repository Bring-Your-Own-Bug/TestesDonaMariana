using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaDetalhesTeste : Form
    {
        public TelaDetalhesTeste()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public Teste? Entidade { get; set; }
    }
}
