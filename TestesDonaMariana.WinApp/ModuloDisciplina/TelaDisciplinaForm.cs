using TestesDonaMariana.WinApp.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form, ITelaBase<Disciplina>
    {
        public TelaDisciplinaForm()
        {
            InitializeComponent();
        }

        public TextBox TxtId => throw new NotImplementedException();

        public Disciplina? Entidade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
