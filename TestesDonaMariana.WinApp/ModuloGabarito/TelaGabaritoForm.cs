using TestesDonaMariana.Dominio.ModuloGabarito;

namespace TestesDonaMariana.WinApp.ModuloGabarito
{
    public partial class TelaGabaritoForm : Form, ITelaBase<Gabarito>
    {
        public TelaGabaritoForm()
        {
            InitializeComponent();
        }

        public Gabarito? Entidade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
