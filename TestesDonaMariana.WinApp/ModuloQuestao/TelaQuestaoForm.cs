using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form, ITelaBase<Questao>
    {
        public TelaQuestaoForm()
        {
            InitializeComponent();
        }

        public Questao? Entidade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
