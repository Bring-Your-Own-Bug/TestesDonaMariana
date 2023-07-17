using TestesDonaMariana.Aplicacao.ModuloTeste;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase<Teste, RepositorioTeste, ServicoTeste, TabelaTesteControl, TelaTesteForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private readonly RepositorioDisciplina _repositorioDisciplina;
        private readonly RepositorioMateria _repositorioMateria;
        private readonly ServicoTeste _servicoTeste;

        private readonly TabelaTesteControl _tabelaTeste;

        public ControladorTeste(RepositorioTeste _repositorio, ServicoTeste _servico, TabelaTesteControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3, RepositorioMateria repositorio4) : base(_repositorio, _servico, _tabela, _repositorio2, _repositorio3)
        {
            _tabelaTeste = _tabela;
            _servicoTeste = _servico;
            _repositorioDisciplina = _repositorio2;
            _repositorioMateria = repositorio4;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
        }

        public ControladorTeste()
        {

        }

        public override TabelaTesteControl ObterListagem()
        {
            return _tabelaTeste;
        }

        public override void MostrarDetalhesTeste()
        {
            Teste? teste = _tabelaTeste.ObterRegistroSelecionado();

            TelaDetalhesTesteForm tela = new()
            {
                Entidade = teste
            };

            TelaPrincipalForm.AtualizarStatus($"Visualizando o Teste \"{teste.Titulo}\"");

            tela.ShowDialog();

            CarregarRegistros();
        }

        public override void DuplicarTeste()
        {
            Teste? teste = _tabelaTeste.ObterRegistroSelecionado();

            TelaTesteForm tela = new();

            CarregarComboBox(tela, teste);

            tela.DuplicarTeste = teste;

            TelaPrincipalForm.AtualizarStatus($"Duplicando o Teste \"{teste.Titulo}\"");

            if (tela.ShowDialog() == DialogResult.OK)
                _repositorio.Adicionar(tela.DuplicarTeste);

            CarregarRegistros();
        }

        public override void GerarPdf()
        {
            Teste? teste = _tabelaTeste.ObterRegistroSelecionado();

            TelaPdfTesteForm tela = new(teste)
            {
                Entidade = teste
            };

            TelaPrincipalForm.AtualizarStatus($"Gerando PDF do Teste \"{teste.Titulo}\"");

            tela.ShowDialog();

            CarregarRegistros();
        }

        public static List<Materia>? ObterListaMateria()
        {
            return new RepositorioMateria().ObterListaRegistros();
        }

        public static List<Questao>? ObterListaQuestao()
        {
            return new RepositorioQuestao().ObterListaRegistros();
        }

        private void CarregarComboBox(TelaTesteForm telaTeste, Teste teste)
        {
            telaTeste.cmbMateria.DisplayMember = "NomeSerie";
            telaTeste.cmbMateria.ValueMember = "NomeSerie";
            telaTeste.cmbMateria.DataSource = _repositorioMateria.ObterListaRegistros();

            telaTeste.cmbDisciplina.DisplayMember = "Nome";
            telaTeste.cmbDisciplina.ValueMember = "Nome";
            telaTeste.cmbDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }
    }
}
