using FluentResults;
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
            for (int i = 0; i < _resultado.Reasons.Count; i++)
            {
                switch (_resultado.Errors[i].Reasons[0].Message)
                {
                    case "Nome": lbErroNome.Text = _resultado.Errors[i].Message; lbErroNome.Visible = true; break;
                    case "Disciplina": lbErroDisciplina.Text = _resultado.Errors[i].Message; lbErroDisciplina.Visible = true; break;
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
