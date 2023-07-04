using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form, ITelaBase<Materia>
    {
        public TelaMateriaForm()
        {
            InitializeComponent();
        }

        public Materia? Entidade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
