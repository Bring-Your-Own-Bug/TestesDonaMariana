using FluentResults;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form, ITelaBase<Disciplina>
    {
        private Disciplina _disciplina;

        private Result _resultado = new();

        public event Func<Disciplina, bool, Result> OnGravarRegistro;

        public TelaDisciplinaForm()
        {
            InitializeComponent();
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

            if (_resultado.IsFailed)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
            }
        }

        private void ImplementarMetodos()
        {
            txtNome.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            ResetarErros();

            _disciplina = new Disciplina(txtNome.Text);

            if (_disciplina.Id == 0)
                _disciplina.Id = int.Parse(txtId.Text);

            _resultado = OnGravarRegistro(_disciplina, sender == btnAdd);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
            {
                switch (item.PropertyName)
                {
                    case "Nome": lbErroNome.Text = item.ErrorMessage; lbErroNome.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroNome.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}