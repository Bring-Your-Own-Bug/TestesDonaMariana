using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase<Disciplina, RepositorioDisciplina, TabelaDisciplinaControl, TelaDisciplinaForm, RepositorioMateria, NenhumRepositorio>
    {
        private RepositorioDisciplina _repositorioDisciplina;
        private TabelaDisciplinaControl _tabelaDisciplina;
        private RepositorioMateria _repositorioMateria;

        public ControladorDisciplina(RepositorioDisciplina _repositorio, TabelaDisciplinaControl _tabela, RepositorioMateria _repositorio2) : base(_repositorio, _tabela, _repositorio2)
        {
            _repositorioDisciplina = _repositorio;
            _tabelaDisciplina = _tabela;
            _repositorioMateria = _repositorio2;
        }

        public ControladorDisciplina()
        {
            
        }

        public List<Disciplina> ObterListaDisciplina()
        {
            RepositorioDisciplina _repositorioDisciplina = new();

            return _repositorioDisciplina.ObterListaRegistros();
        }

        public override TabelaDisciplinaControl ObterListagem()
        {
            return _tabelaDisciplina;
        }
    }
}
