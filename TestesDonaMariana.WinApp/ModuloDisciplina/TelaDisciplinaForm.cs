using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form, ITelaBase<Disciplina>
    {
        private Disciplina _disciplina;

        private bool _isValid;

        private List<Disciplina> ListaDisciplinas { get; set; }

        public TelaDisciplinaForm()
        {
            InitializeComponent();

            ListaDisciplinas = new ControladorDisciplina().ObterListaDisciplina();
        }

        public Disciplina? Entidade
        {
            get => _disciplina;

            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
                _disciplina = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            _disciplina = new Disciplina(txtNome.Text);

            if (_disciplina.Id == 0)
                _disciplina.Id = int.Parse(txtId.Text);
        }

        private void ImplementarMetodos()
        {
            txtNome.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            lbErroNome.Visible = false;

            if (txtNome.Text.ValidarCampoVazio())
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Campo obrigatório";
            }
            else if (_disciplina != null && string.Equals(_disciplina.Nome, txtNome.Text, StringComparison.OrdinalIgnoreCase)) { }
            else if (ValidadorDisciplina.ValidarNomeExistente(txtNome.Text, ListaDisciplinas))
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Essa disciplina já existe";
            }

            _isValid = lbErroNome.Visible ? false : true;
        }
    }
}
