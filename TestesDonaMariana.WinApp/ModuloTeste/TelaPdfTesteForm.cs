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
        private readonly Teste _teste;

        private bool _isValid;

        private int _contador;

        public TelaPdfTesteForm(Teste teste)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _teste = teste;
            _contador = 1;
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
            PdfWriter writer = new(rdbSim.Checked
            ? $"{txtDiretorio.Text}/{txtTitulo.Text} - Gabarito ({_contador}).pdf"
            : $"{txtDiretorio.Text}/{txtTitulo.Text} - Gabarito.pdf");

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

            PdfWriter writer = new(rdbSim.Checked
            ? $"{txtDiretorio.Text}/{txtTitulo.Text} ({_contador}).pdf"
            : $"{txtDiretorio.Text}/{txtTitulo.Text}.pdf");

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

            if (_teste.Materia != null)
            {
                info.Add(new Text($"\n• Matéria: ").SetBold());
                info.Add(new Text(_teste.Materia.Nome));
                info.Add(new Text($"\n• Série: ").SetBold());
                info.Add(new Text(_teste.Materia.Serie.ObterDescricao()));
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

            if (ValidadorTeste.ValidarArquivoExistente(txtDiretorio.Text, txtTitulo.Text))
            {
                lbErroDiretorio.Text = "*Já existe um arquivo com mesmo nome nesse diretório";
                lbErroDiretorio.Visible = true;
                gboxDuplicar.Visible = true;

                if (rdbSim.Checked)
                {
                    lbErroDiretorio.Visible = false;
                    _contador++;
                }                   
            }

            _isValid = !(lbErroTitulo.Visible || lbErroDiretorio.Visible);
        }
    }
}
