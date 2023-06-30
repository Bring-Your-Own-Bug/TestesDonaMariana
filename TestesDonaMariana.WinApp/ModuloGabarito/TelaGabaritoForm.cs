using TestesDonaMariana.WinApp.Compartilhado;
using TestesDonaMariana.Dominio.ModuloGabarito;

namespace TestesDonaMariana.WinApp.ModuloGabarito
{
    public partial class TelaGabaritoForm : Form, ITelaBase<Gabarito>
    {
        public TelaGabaritoForm()
        {
            InitializeComponent();
        }
    }
}
