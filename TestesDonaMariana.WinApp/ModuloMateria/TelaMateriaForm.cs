using FluentResults;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form, ITelaBase<Materia>
    {
        private Materia _materia;

        private Result _resultado = new();

        public event GravarRegistroDelegate<Materia> onGravarRegistro;

        private List<Materia> ListaMateria { get; set; }

        public TelaMateriaForm()
        {
            InitializeComponent();
            ListaMateria = ControladorMateria.ObterListaMateria();
        }

        public Materia? Entidade
        {
            get => _materia;

            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
                txtDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                rdPrimeiraSerie.Checked = value.Serie == Serie.Primeira;
                rdSegundaSerie.Checked = value.Serie == Serie.Segunda;
                _materia = value;
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
            txtDisciplina.TextChanged += ValidarCampos;
            rdPrimeiraSerie.CheckedChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            ResetarErros();

            Serie serie = rdPrimeiraSerie.Checked ? Serie.Primeira : Serie.Segunda;

            Disciplina? disciplina = txtDisciplina.SelectedItem as Disciplina;

            _materia = new Materia(txtNome.Text, disciplina, serie);

            if (_materia.Id == 0)
                _materia.Id = int.Parse(txtId.Text);

            _resultado = onGravarRegistro(_materia, sender == btnAdd);

            if (_resultado.IsFailed)
            {
                MostrarErros();
            }
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors.Cast<CustomError>())
            {
                switch (item.PropertyName)
                {
                    case "Nome": lbErroNome.Text = item.ErrorMessage; lbErroNome.Visible = true; break;
                    case "Disciplina": lbErroDisciplina.Text = item.ErrorMessage; lbErroDisciplina.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroNome.Visible = false;
            lbErroDisciplina.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
