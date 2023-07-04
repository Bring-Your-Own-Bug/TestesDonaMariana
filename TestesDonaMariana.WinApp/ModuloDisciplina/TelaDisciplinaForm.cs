using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form, ITelaBase<Disciplina>
    {
        private Disciplina _disciplina;

        private bool isValid;

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

            if (_disciplina.Id == 0)
                _disciplina.Id = int.Parse(txtId.Text);
        }

        private void ImplementarMetodos()
        {
            txtNome.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Disciplina disciplina = new();

            lbErroNome.Visible = false;

            if (disciplina.ValidarCampoVazio(txtNome.Text))
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Campo obrigatório";
            }
            else if (disciplina.ValidarNomeExistente(txtNome.Text, ListaDisciplinas))
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Essa disciplina já existe";
            }

            if (lbErroNome.Visible)
                isValid = false;
            else
                isValid = true;
        }
    }
}
