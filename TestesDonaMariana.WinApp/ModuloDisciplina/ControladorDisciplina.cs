using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase<Disciplina, RepositorioDisciplina, TabelaDisciplinaControl, TelaDisciplinaForm, RepositorioMateria, NenhumRepositorio>
    {
        private readonly TabelaDisciplinaControl _tabelaDisciplina;

        public ControladorDisciplina(RepositorioDisciplina _repositorio, TabelaDisciplinaControl _tabela, RepositorioMateria _repositorio2) : base(_repositorio, _tabela, _repositorio2)
        {
            _tabelaDisciplina = _tabela;
        }

        public ControladorDisciplina()
        {
            
        }

        public List<Disciplina> ObterListaDisciplina()
        {
            return new RepositorioDisciplina().ObterListaRegistros();
        }

        public override TabelaDisciplinaControl ObterListagem()
        {
            return _tabelaDisciplina;
        }
    }
}
