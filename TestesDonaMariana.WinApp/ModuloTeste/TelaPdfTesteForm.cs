using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using TestesDonaMariana.Dominio.ModuloTeste;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaPdfTesteForm : Form, ITelaBase<Teste>
    {
        private Teste _teste;

        private bool isValid;

        private List<Questao> ListaQuestoes { get; set; }
        public TelaPdfTesteForm(Teste teste)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _teste = teste;
            ListaQuestoes = new ControladorTeste().ObterListaQuestao();
        }

        public Teste? Entidade
        {
            get => _teste;

            set { txtTitulo.Text = value.Titulo; }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new();

            if (folder.ShowDialog() == DialogResult.OK)
                txtDiretorio.Text = folder.SelectedPath;
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            GerarTeste();

            if (ckbGabarito.Checked)
                GerarGabarito();
        }

        private void GerarGabarito()
        {
            PdfWriter writer = new(txtDiretorio.Text + "/" + _teste.Titulo + " - Gabarito.pdf");
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            document.Add(new LineSeparator(new SolidLine(1f)));
            document.Add(new Paragraph(""));

            Paragraph info = new Paragraph()
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(13)
                .Add(new Text("• Aluno:").SetBold());

            info.Add(new Text($"\n• Disciplina: ").SetBold());
            info.Add(new Text(_teste.Disciplina.Nome));

            if (_teste.Materia != null)
            {
                info.Add(new Text($"\n• Matéria: ").SetBold());
                info.Add(new Text(_teste.Materia.Nome));
                info.Add(new Text($"\n• Série: ").SetBold());
                info.Add(new Text(_teste.Materia.Serie.ObterDescricao()));
            }
            else
            {
                info.Add(new Text($"\n• Provão").SetBold());
            }

            document.Add(info);
            document.Add(new Paragraph(""));
            document.Add(new LineSeparator(new SolidLine(1f)));
            document.Add(new Paragraph("\n"));

            Paragraph title = new Paragraph(_teste.Titulo)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(21)
                .SetBold();

            document.Add(title);
            document.Add(new Paragraph("\n"));

            foreach (Questao questao in ListaQuestoes)
            {
                Paragraph question = new($"\n{questao.Enunciado}");
                document.Add(question);

                Paragraph alternativaParagraph = new($"Resposta correta: {questao.AlternativaCorreta}");
                document.Add(alternativaParagraph);
            }

            document.Close();
        }

        private void GerarTeste()
        {
            PdfWriter writer = new(txtDiretorio.Text + "/" + _teste.Titulo + ".pdf");
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            document.Add(new LineSeparator(new SolidLine(1f)));
            document.Add(new Paragraph(""));

            Paragraph info = new Paragraph()
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(13)
                .Add(new Text("• Aluno:").SetBold());

            info.Add(new Text($"\n• Disciplina: ").SetBold());
            info.Add(new Text(_teste.Disciplina.Nome));

            if (_teste.Materia != null)
            {
                info.Add(new Text($"\n• Matéria: ").SetBold());
                info.Add(new Text(_teste.Materia.Nome));
                info.Add(new Text($"\n• Série: ").SetBold());
                info.Add(new Text(_teste.Materia.Serie.ObterDescricao()));
            }
            else
            {
                info.Add(new Text($"\n• Provão").SetBold());
            }

            document.Add(info);
            document.Add(new Paragraph(""));
            document.Add(new LineSeparator(new SolidLine(1f)));
            document.Add(new Paragraph("\n"));

            Paragraph title = new Paragraph(_teste.Titulo)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(21)
                .SetBold();

            document.Add(title);
            document.Add(new Paragraph("\n"));

            char letra = 'a';

            foreach (Questao questao in ListaQuestoes)
            {
                Paragraph question = new($"\n{questao.Enunciado}");
                document.Add(question);

                for (int i = 0; i < questao.Alternativas.Count; i++)
                {
                    string alternativa = $"{letra}) {questao.Alternativas[i]}";
                    Paragraph alternativaParagraph = new(alternativa);
                    document.Add(alternativaParagraph);

                    letra++;
                }

                letra = 'a';
            }

            document.Close();
        }

        private void ImplementarMetodos()
        {
            txtTitulo.TextChanged += ValidarCampos;
            txtDiretorio.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            Teste teste = new();

            lbErroTitulo.Visible = false;
            lbErroDiretorio.Visible = false;

            if (teste.ValidarCampoVazio(txtTitulo.Text))
            {
                lbErroTitulo.Visible = true;
                lbErroTitulo.Text = "*Campo obrigatório";
            }

            if (teste.ValidarDiretorioExistente(txtDiretorio.Text))
            {
                lbErroDiretorio.Text = "*Diretório inválido";
                lbErroDiretorio.Visible = true;
            }

            if (lbErroTitulo.Visible || lbErroDiretorio.Visible)
                isValid = false;
            else
                isValid = true;
        }
    }
}
