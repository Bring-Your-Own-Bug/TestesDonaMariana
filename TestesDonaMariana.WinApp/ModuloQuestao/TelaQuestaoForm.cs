using FluentResults;
using iText.StyledXmlParser.Jsoup.Nodes;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.WinApp.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form, ITelaBase<Questao>
    {
        private Questao _questao;

        private Result _resultado = new();

        public event GravarRegistroDelegate<Questao> onGravarRegistro;

        private List<Materia> ListaMateria { get; set; } = new();
        private List<Questao> ListaQuestao { get; set; } = new();

        public TelaQuestaoForm()
        {
            InitializeComponent();
            ListaQuestao = ControladorQuestao.ObterListaQuestao();
        }

        public Questao? Entidade
        {
            get => _questao;

            set
            {
                txtId.Text = value.Id.ToString();
                txtDisciplina.Text = value.Disciplina == null ? "" : value.Disciplina.Nome;
                txtMateria.Text = value.Materia == null ? "" : value.Materia.Nome;
                txtEnunciado.Text = value.Enunciado;

                listAlternativas.Items.AddRange(value.Alternativas.ToArray());
                int index = listAlternativas.Items.IndexOf(value.AlternativaCorreta);
                listAlternativas.SetItemChecked(index, true);

                _questao = value;
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
            txtMateria.TextChanged += ValidarCampos;
            txtDisciplina.TextChanged += ValidarCampos;
            txtEnunciado.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            ResetarErros();

            Disciplina? disciplina = txtDisciplina.SelectedItem as Disciplina;

            Materia? materia = txtMateria.SelectedItem as Materia;

            List<string> alternativas = listAlternativas.Items.Cast<string>().ToList();

            _questao = new Questao(materia, txtEnunciado.Text, alternativas, listAlternativas.CheckedItems[0].ToString());

            if (_questao.Id == 0)
                _questao.Id = int.Parse(txtId.Text);

            _resultado = onGravarRegistro(_questao, sender == btnAdd);

            if (_resultado.IsFailed)
            {
                MostrarErros();
            }
        }

        private void AdicionarAlternativa(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtResposta.Text))
            {
                if (ValidadorQuestao.ValidarAlternativaExistente(txtResposta.Text, listAlternativas.Items.Cast<string>().ToList()))
                {
                    lbErroAlternativas.Text = "*Alternativa já existente";
                    lbErroAlternativas.Visible = true;
                }
                else if (ValidadorQuestao.ValidarQtdMaximaAlternativas(listAlternativas.Items.Count))
                {
                    lbErroAlternativas.Text = "*Máximo de 4 alternativas";
                    lbErroAlternativas.Visible = true;
                }
                else
                {
                    char letra = 'A';

                    letra = (char)(letra + listAlternativas.Items.Count);

                    listAlternativas.Items.Add($"{letra}) {txtResposta.Text}");
                    lbErroAlternativas.Visible = false;
                }
            }

            txtResposta.ResetText();
            txtResposta.Focus();
        }

        private void ExcluirAlternativa(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (listAlternativas.SelectedIndex != -1)
            {
                listAlternativas.Items.RemoveAt(listAlternativas.SelectedIndex);

                char letra = 'A';

                for (int i = 0; i < listAlternativas.Items.Count; i++)
                {
                    listAlternativas.Items[i] = $"{letra}) {listAlternativas.Items[i].ToString().Substring(3)}";
                    letra++;
                }
            }
        }

        private void ApenasUmaAlternativaCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (int index in listAlternativas.CheckedIndices)
            {
                if (index != e.Index)
                    listAlternativas.SetItemChecked(index, false);
            }
        }

        private void AtualizarComboBoxMateria(object sender, EventArgs e)
        {
            if (ListaMateria.Count == 0)
                ListaMateria = (List<Materia>)txtMateria.DataSource;

            if (txtDisciplina.SelectedIndex != -1)
            {
                Disciplina disciplina = txtDisciplina.SelectedItem as Disciplina;

                txtMateria.DataSource = ListaMateria.FindAll(m => m.Disciplina.Id == disciplina.Id);
            }
        }

        private void MostrarErros()
        {
            for (int i = 0; i < _resultado.Reasons.Count; i++)
            {
                switch (_resultado.Errors[i].Reasons[i].Message)
                {
                    case "Enunciado": lbErroEnunciado.Text = _resultado.Errors[i].Message; lbErroEnunciado.Visible = true; break;
                    case "Disciplina": lbErroDisciplina.Text = _resultado.Errors[i].Message; lbErroDisciplina.Visible = true; break;
                    case "Materia": lbErroMateria.Text = _resultado.Errors[i].Message; lbErroMateria.Visible = true; break;
                    case "Alternativas": lbErroAlternativas.Text = _resultado.Errors[i].Message; lbErroAlternativas.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroAlternativas.Visible = false;
            lbErroEnunciado.Visible = false;
            lbErroMateria.Visible = false;
            lbErroDisciplina.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
