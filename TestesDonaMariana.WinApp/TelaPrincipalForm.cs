using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.WinApp.ModuloDisciplina;

namespace TestesDonaMariana.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private Dictionary<Control, ToolStripButton> coresBotoes = new();

        private IControladorBase _controladorBase;
        private UserControl _tabela;

        private static TelaPrincipalForm _telaPrincipal;

        private IRepositorio<Disciplina> _repositorioDisciplina = new RepositorioDisciplina();

        private TabelaDisciplinaControl _tabelaDisciplina = new();

        public TelaPrincipalForm()
        {
            InitializeComponent();

            _telaPrincipal = this;

            AdicionarBotoesDicionario();
        }

        private void AdicionarBotoesDicionario()
        {

        }

        public static void AtualizarStatus(string status)
        {
            //_telaPrincipal.lbStatus.Text = status;
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorDisciplina(_repositorioDisciplina, _tabelaDisciplina);

            ConfigurarTelaPrincipal();
        }

        private void ConfigurarTelaPrincipal()
        {
            ConfigurarListagem();

            ConfigurarToolTipsAndButtons();

            AbrirListagem();

            //ResetarBotoes();
        }

        private void AbrirListagem()
        {
            lbTipoCadastro.Text = _controladorBase.ObterTipoCadastro();
            plPrincipal.Controls.Clear();
            plPrincipal.Controls.Add(_tabela);
            _controladorBase.CarregarRegistros();
        }

        private void ConfigurarListagem()
        {
            _tabela = _controladorBase.ObterListagem();

            _tabela.Dock = DockStyle.Fill;
        }

        private void ConfigurarToolTipsAndButtons()
        {
            btnAdicionar.ToolTipText = _controladorBase.ToolTipAdicionar;
            btnEditar.ToolTipText = _controladorBase.ToolTipEditar;
            btnExcluir.ToolTipText = _controladorBase.ToolTipExcluir;
            barraFuncoes.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controladorBase.Adicionar();
            //ResetarBotoes();
        }

        //private void ResetarBotoes()
        //{
        //    ConfigurarBotaoItem();

        //    ConfigurarBotaoAtualizarStatus();

        //    if (((DataGridView)_tabela.Controls[0]).SelectedRows.Count > 0)
        //    {
        //        btnEditar.Enabled = true;
        //        btnExcluir.Enabled = true;
        //    }
        //    else
        //    {
        //        btnEditar.Enabled = false;
        //        btnExcluir.Enabled = false;
        //    }
        //}
    }
}