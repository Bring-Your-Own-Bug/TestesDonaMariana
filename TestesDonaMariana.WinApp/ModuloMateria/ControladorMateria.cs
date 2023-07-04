using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase<Materia, RepositorioMateria, TabelaMateriaControl, TelaMateriaForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private RepositorioMateria _repositorioMateria;
        private TabelaMateriaControl _tabelaMateria;

        private RepositorioDisciplina _repositorioDisciplina;
        private RepositorioQuestao _repositorioQuestao;

        public ControladorMateria(RepositorioMateria _repositorio, TabelaMateriaControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3) : base(_repositorio, _tabela, _repositorio2, _repositorio3)
        {
            _repositorio = _repositorioMateria;
            _tabela = _tabelaMateria;
            _repositorio2 = _repositorioDisciplina;
            _repositorio3 = _repositorioQuestao;
        }

        public override TabelaMateriaControl ObterListagem()
        {
            return _tabelaMateria;
        }
    }
}
