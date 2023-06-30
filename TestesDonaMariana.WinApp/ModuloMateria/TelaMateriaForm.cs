using TestesDonaMariana.WinApp.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form, ITelaBase<Materia>
    {
        public TelaMateriaForm()
        {
            InitializeComponent();
        }
    }
}
