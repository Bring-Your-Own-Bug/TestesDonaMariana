using TestesDonaMariana.Aplicacao.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase<Disciplina, RepositorioDisciplina, ServicoDisciplina, TabelaDisciplinaControl, TelaDisciplinaForm, RepositorioMateria, NenhumRepositorio>
    {
        private readonly TabelaDisciplinaControl _tabelaDisciplina;
        private readonly RepositorioMateria _repositorioMateria;
        private readonly ServicoDisciplina _servicoDisciplina;

        public ControladorDisciplina(RepositorioDisciplina _repositorio, ServicoDisciplina _servico, TabelaDisciplinaControl _tabela, RepositorioMateria _repositorio2) : base(_repositorio, _servico, _tabela, _repositorio2)
        {
            _tabelaDisciplina = _tabela;
            _servicoDisciplina = _servico;
            _repositorioMateria = _repositorio2;
        }

        public ControladorDisciplina()
        {

        }

        public override TabelaDisciplinaControl ObterListagem()
        {
            return _tabelaDisciplina;
        }
    }
}
