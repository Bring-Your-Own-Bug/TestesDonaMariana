using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase<Teste, RepositorioTeste, TabelaTesteControl, TelaTesteForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private RepositorioTeste _repositorioTeste;
        private TabelaTesteControl _tabelaTeste;

        private RepositorioDisciplina _repositorioDisciplina;
        private RepositorioQuestao _repositorioQuestao;

        public ControladorTeste()
        {

        }
        public ControladorTeste(RepositorioTeste _repositorio, TabelaTesteControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3) : base(_repositorio, _tabela, _repositorio2, _repositorio3)
        {
            _repositorioTeste = _repositorio;
            _tabelaTeste = _tabela;
            _repositorioDisciplina = _repositorio2;
            _repositorioQuestao = _repositorio3;
        }

        public override TabelaTesteControl ObterListagem()
        {
            return _tabelaTeste;
        }

        public List<Teste>? ObterListaTeste()
        {
            return new RepositorioTeste().ObterListaRegistros();
        }
    }
}
