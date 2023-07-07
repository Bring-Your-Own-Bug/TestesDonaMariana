using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloGabarito;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.WinApp.ModuloDisciplina;
using TestesDonaMariana.WinApp.ModuloGabarito;
using TestesDonaMariana.WinApp.ModuloMateria;
using TestesDonaMariana.WinApp.ModuloQuestao;
using TestesDonaMariana.WinApp.ModuloTeste;

namespace TestesDonaMariana.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private Dictionary<Control, ToolStripButton> coresBotoes = new();

        private IControladorBase _controladorBase;
        private UserControl _tabela;

        private static TelaPrincipalForm _telaPrincipal;

        private RepositorioDisciplina _repositorioDisciplina = new();
        private RepositorioMateria _repositorioMateria = new();
        private RepositorioQuestao _repositorioQuestao = new();
        private RepositorioTeste _repositorioTeste = new();
        private RepositorioGabarito _repositorioGabarito = new();

        private TabelaDisciplinaControl _tabelaDisciplina = new();
        private TabelaMateriaControl _tabelaMateria = new();
        private TabelaQuestaoControl _tabelaQuestao = new();
        private TabelaTesteControl _tabelaTeste = new();
        private TabelaGabaritoControl _tabelaGabarito = new();

        public TelaPrincipalForm()
        {
            InitializeComponent();

            _telaPrincipal = this;

            AdicionarBotoesDicionario();
        }

        private void AdicionarBotoesDicionario()
        {
            coresBotoes.Add(_tabelaDisciplina, btnDisciplina);
            coresBotoes.Add(_tabelaMateria, btnMateria);
            coresBotoes.Add(_tabelaQuestao, btnQuestao);
            coresBotoes.Add(_tabelaTeste, btnTeste);
        }

        public static void AtualizarStatus(string status)
        {
            _telaPrincipal.lbStatus.Text = status;
        }

        private void btnDisciplina_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorDisciplina(_repositorioDisciplina, _tabelaDisciplina, _repositorioMateria);
            ConfigurarTelaPrincipal();
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorMateria(_repositorioMateria, _tabelaMateria, _repositorioDisciplina, _repositorioQuestao);

            ConfigurarTelaPrincipal();
        }

        private void btnQuestao_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorQuestao(_repositorioQuestao, _tabelaQuestao, _repositorioMateria, _repositorioDisciplina);

            ConfigurarTelaPrincipal();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorTeste(_repositorioTeste, _tabelaTeste, _repositorioDisciplina, _repositorioQuestao, _repositorioMateria);

            ConfigurarTelaPrincipal();
        }

        private void ConfigurarTelaPrincipal()
        {
            ConfigurarListagem();

            ConfigurarToolTipsAndButtons();

            AbrirListagem();

            ResetarBotoes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controladorBase.Adicionar();
            ResetarBotoes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _controladorBase.Editar();
            ResetarBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _controladorBase.Excluir();
            ResetarBotoes();
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            _controladorBase.MostrarDetalhes();

            ResetarBotoes();
        }

        private void btnAttStatus_Click(object sender, EventArgs e)
        {
            _controladorBase.AtualizarStatus();
            ResetarBotoes();
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

        private void ResetarBotoes()
        {
            ConfigurarBotaoItem();

            //ConfigurarBotaoAtualizarStatus();

            if (((DataGridView)_tabela.Controls[0]).SelectedRows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        private void ConfigurarBotaoItem()
        {
            if (((DataGridView)_tabela.Controls[0]).SelectedRows.Count > 0 && _controladorBase is ControladorTeste)
                btnDetalhes.Enabled = true;
            else
                btnDetalhes.Enabled = false;
        }

        //private void ConfigurarBotaoAtualizarStatus()
        //{
        //    if (((DataGridView)_tabela.Controls[0]).SelectedRows.Count > 0 && _controladorBase is ControladorAluguel)
        //        btnAttStatus.Enabled = true;
        //    else
        //        btnAttStatus.Enabled = false;
        //}

        private void btnColor_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;

            btn.ForeColor = Color.Black;
        }

        private void btnColor_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;

            btn.ForeColor = Color.White;
        }

        private void plPrincipal_ControlAdded(object sender, ControlEventArgs e)
        {
            ToolStripButton btn;

            coresBotoes.TryGetValue(e.Control, out btn);

            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.MouseLeave -= btnColor_MouseLeave;
        }

        private void plPrincipal_ControlRemoved(object sender, ControlEventArgs e)
        {
            ToolStripButton btn;

            coresBotoes.TryGetValue(e.Control, out btn);

            btn.BackColor = Color.FromArgb(0, 165, 100);
            btn.ForeColor = Color.White;
            btn.MouseLeave += btnColor_MouseLeave;
        }
    }
}