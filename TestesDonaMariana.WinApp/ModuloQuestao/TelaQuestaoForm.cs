using iText.StyledXmlParser.Jsoup.Nodes;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form, ITelaBase<Questao>
    {
        private Questao _questao;

        private bool _isValid;

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

            if (_isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            Materia? materia = txtMateria.SelectedItem as Materia;

            List<string> alternativas = listAlternativas.Items.Cast<string>().ToList();

            _questao = new Questao(materia, txtEnunciado.Text, alternativas, listAlternativas.CheckedItems[0].ToString());

            if (_questao.Id == 0)
                _questao.Id = int.Parse(txtId.Text);
        }

        private void ImplementarMetodos()
        {
            txtMateria.TextChanged += ValidarCampos;
            txtDisciplina.TextChanged += ValidarCampos;
            txtEnunciado.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            lbErroAlternativas.Visible = false;
            lbErroEnunciado.Visible = false;

            if (ValidadorQuestao.ValidarQtdMinimaAlternativas(listAlternativas.Items.Count))
            {
                lbErroAlternativas.Text = "*Deve ter no mínimo 3 alternativas";
                lbErroAlternativas.Visible = true;
            }
            else if (ValidadorQuestao.ValidarAlternativaCorreta(listAlternativas.CheckedItems.Count))
            {
                lbErroAlternativas.Text = "*Precisa ter 1 Resposta Correta";
                lbErroAlternativas.Visible = true;
            }

            if (txtEnunciado.Text.ValidarCampoVazio())
            {
                lbErroEnunciado.Text = "*Campo obrigatório";
                lbErroEnunciado.Visible = true;
            }
            else if (_questao != null && string.Equals(_questao.Enunciado, txtEnunciado.Text, StringComparison.OrdinalIgnoreCase)) { }
            else if (ValidadorQuestao.ValidarQuestaoExistente(txtEnunciado.Text, ListaQuestao))
            {
                lbErroEnunciado.Visible = true;
                lbErroEnunciado.Text = "*Essa questão já existe";
            }

            lbErroMateria.Visible = txtMateria.Text.ValidarCampoVazio();

            lbErroDisciplina.Visible = txtDisciplina.Text.ValidarCampoVazio();

            if (lbErroDisciplina.Visible || lbErroMateria.Visible || lbErroEnunciado.Visible || lbErroAlternativas.Visible)
                _isValid = false;
            else
                _isValid = true;
        }

        private void AdicionarAlternativa(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

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
    }
}
