using TestesDonaMariana.WinApp.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form, ITelaBase<Disciplina>
    {
        private Disciplina _disciplina;

        private bool isValid;

        public TelaDisciplinaForm()
        {
            InitializeComponent();
        }

        public TextBox TxtId => txtId;

        public Disciplina? Entidade
        {
            get => _disciplina;

            set
            {
                txtNome.Text = value.Nome;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            _disciplina = new Disciplina(txtNome.Text);
        }

        private void ImplementarMetodos()
        {
            txtNome.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Disciplina disciplina = new();

            lbErroNome.Visible = disciplina.ValidarCampoVazio(txtNome.Text);

            if (lbErroNome.Visible)
                isValid = false;
            else
                isValid = true;
        }
    }
}
