using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase<Questao, RepositorioQuestao, TabelaQuestaoControl, TelaQuestaoForm, RepositorioMateria, NenhumRepositorio>
    {
        private RepositorioQuestao _repositorioQuestao;
        private TabelaQuestaoControl _tabelaQuestao;

        private RepositorioMateria _repositorioMateria;

        public ControladorQuestao(RepositorioQuestao _repositorio, TabelaQuestaoControl _tabela, RepositorioMateria _repositorio2) : base(_repositorio, _tabela, _repositorio2)
        {
            _repositorio = _repositorioQuestao;
            _tabela = _tabelaQuestao;
            _repositorio2 = _repositorioMateria;
        }

        public override TabelaQuestaoControl ObterListagem()
        {
            return _tabelaQuestao;
        }
    }
}
