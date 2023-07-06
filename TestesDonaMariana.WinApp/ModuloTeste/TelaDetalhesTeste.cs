using TestesDonaMariana.Dados.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaDetalhesTeste : Form
    {
        public TelaDetalhesTeste()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public object Entidade { get; internal set; }

        public void PreencherLabel(){}
    }
}
