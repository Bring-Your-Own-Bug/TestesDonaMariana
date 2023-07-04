using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaTesteForm : Form, ITelaBase<Teste>
    {
        public TelaTesteForm()
        {
            InitializeComponent();
        }

        public TextBox TxtId => throw new NotImplementedException();

        public Teste? Entidade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
