using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.WinApp.ModuloDisciplina;

namespace TestesDonaMariana.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        public TelaPrincipalForm()
        {
            InitializeComponent();
        }

        public static void AtualizarStatus(string status)
        {
            //_telaPrincipal.lbStatus.Text = status;
        }
    }
}