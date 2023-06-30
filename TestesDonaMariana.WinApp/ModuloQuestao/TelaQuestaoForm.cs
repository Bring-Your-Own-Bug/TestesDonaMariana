using TestesDonaMariana.WinApp.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form, ITelaBase<Questao>
    {
        public TelaQuestaoForm()
        {
            InitializeComponent();
        }
    }
}
