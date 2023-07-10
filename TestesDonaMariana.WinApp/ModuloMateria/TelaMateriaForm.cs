using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form, ITelaBase<Materia>
    {
        private Materia _materia;

        private bool _isValid;

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
                _materia = value;
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

            Serie serie = rdPrimeiraSerie.Checked ? Serie.Primeira : Serie.Segunda;

            Disciplina? disciplina = txtDisciplina.SelectedItem as Disciplina;

            _materia = new Materia(txtNome.Text, disciplina, serie);

            if (_materia.Id == 0)
                _materia.Id = int.Parse(txtId.Text);
        }

        private void ImplementarMetodos()
        {
            txtNome.TextChanged += ValidarCampos;
            txtDisciplina.TextChanged += ValidarCampos;
            rdPrimeiraSerie.CheckedChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Serie serie = rdPrimeiraSerie.Checked ? Serie.Primeira : Serie.Segunda;

            lbErroNome.Visible = false;

            if (txtNome.Text.ValidarCampoVazio())
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Campo obrigatório";
            }
            else if (_materia != null && string.Equals(_materia.Nome, txtNome.Text, StringComparison.OrdinalIgnoreCase) && _materia.Serie == serie) { }
            else if (ValidadorMateria.ValidarNomeExistente(txtNome.Text, serie, ListaMateria))
            {
                lbErroNome.Visible = true;
                lbErroNome.Text = "*Essa matéria já existe";
            }

            lbErroDisciplina.Visible = txtDisciplina.Text.ValidarCampoVazio();

            _isValid = !(lbErroNome.Visible || lbErroDisciplina.Visible);
        }
    }
}
