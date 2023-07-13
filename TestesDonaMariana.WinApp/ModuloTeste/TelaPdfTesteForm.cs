using FluentResults;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;
using Text = iText.Layout.Element.Text;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaPdfTesteForm : Form, ITelaBase<Teste>
    {
        private readonly Teste _teste;

        private bool _isValid;

        public event Func<Teste, bool, Result> OnGravarRegistro;

        public TelaPdfTesteForm(Teste teste)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _teste = teste;
        }

        public Teste? Entidade
        {
            get => _teste;

            set { txtTitulo.Text = value.Titulo; }
        }

        private void SelecionarLocalizacao(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new();

            if (folder.ShowDialog() == DialogResult.OK)
                txtDiretorio.Text = folder.SelectedPath;
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_isValid == false)
            {
                this.DialogResult = DialogResult.None;
                ImplementarMetodos();
                return;
            }

            GerarTestePdf();

            if (ckbGabarito.Checked)
                GerarGabaritoPdf();

            MessageBox.Show($"PDF Gerado com Sucesso!",
                    "Gerar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GerarGabaritoPdf()
        {
            string diretorio = VerificarENomearArquivo($"{txtDiretorio.Text}/{txtTitulo.Text}", " - Gabarito");

            PdfWriter writer = new(diretorio);
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            GerarCabecalho(document);

            int numeroQuestao = 1;

            foreach (Questao questao in _teste.ListaQuestoes)
            {
                Paragraph question = new($"\n{numeroQuestao} - {questao.Enunciado}");
                document.Add(question);
                numeroQuestao++;

                for (int i = 0; i < questao.Alternativas.Count; i++)
                {
                    string alternativa = questao.Alternativas[i];
                    Paragraph alternativaParagraph = new(alternativa);
                    document.Add(alternativaParagraph);
                }

                Paragraph respostaCorreta = new();
                respostaCorreta.Add(new Text($"\nAlternativa Correta: "));
                respostaCorreta.Add(new Text($"{questao.AlternativaCorreta.Substring(0, 2)}").SetBold());
                document.Add(respostaCorreta);
            }

            document.Close();
        }

        private void GerarTestePdf()
        {
            string diretorio = VerificarENomearArquivo($"{txtDiretorio.Text}/{txtTitulo.Text}", "");

            PdfWriter writer = new(diretorio);
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            GerarCabecalho(document);

            Paragraph title = new Paragraph(_teste.Titulo)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(21)
                .SetBold();

            document.Add(title);
            document.Add(new Paragraph("\n"));

            int numeroQuestao = 1;

            foreach (Questao questao in _teste.ListaQuestoes)
            {
                Paragraph question = new($"\n{numeroQuestao} - {questao.Enunciado}");
                document.Add(question);
                numeroQuestao++;

                for (int i = 0; i < questao.Alternativas.Count; i++)
                {
                    string alternativa = questao.Alternativas[i];
                    Paragraph alternativaParagraph = new(alternativa);
                    document.Add(alternativaParagraph);
                }
            }

            document.Close();
        }

        private string VerificarENomearArquivo(string diretorioEscolhido, string sufixo)
        {
            int contador = 1;
            string diretorio = diretorioEscolhido + sufixo + ".pdf";

            if (File.Exists(diretorio))
            {
                while (File.Exists($"{txtDiretorio.Text}/{txtTitulo.Text}{sufixo}({contador}).pdf"))
                {
                    contador++;
                }

                diretorio = $"{txtDiretorio.Text}/{txtTitulo.Text}{sufixo}({contador}).pdf";
            }

            return diretorio;
        }

        private void GerarCabecalho(Document document)
        {
            document.Add(new LineSeparator(new SolidLine(1f)));
            document.Add(new Paragraph(""));

            Paragraph info = new Paragraph()
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(13)
                .Add(new Text("• Aluno:").SetBold());

            info.Add(new Text($"\n• Disciplina: ").SetBold());
            info.Add(new Text(_teste.Disciplina.Nome));
            info.Add(new Text($"\n• Série: ").SetBold());
            info.Add(new Text(_teste.Serie.ObterDescricao()));

            if (_teste.Materia != null)
            {
                info.Add(new Text($"\n• Matéria: ").SetBold());
                info.Add(new Text(_teste.Materia.Nome));
            }
            else
            {
                info.Add(new Text($"\n• Prova de Recuperação").SetBold());
            }

            document.Add(info);
            document.Add(new Paragraph(""));
            document.Add(new LineSeparator(new SolidLine(1f)));
            document.Add(new Paragraph("\n"));
        }

        private void ImplementarMetodos()
        {
            txtTitulo.TextChanged += ValidarCampos;
            txtDiretorio.TextChanged += ValidarCampos;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            lbErroTitulo.Visible = false;
            lbErroDiretorio.Visible = false;

            if (txtTitulo.Text.ValidarCampoVazio())
            {
                lbErroTitulo.Visible = true;
                lbErroTitulo.Text = "*Campo obrigatório";
            }

            if (ValidadorTeste.ValidarDiretorioExistente(txtDiretorio.Text))
            {
                lbErroDiretorio.Text = "*Diretório inválido";
                lbErroDiretorio.Visible = true;
            }

            _isValid = !(lbErroTitulo.Visible || lbErroDiretorio.Visible);
        }
    }
}
