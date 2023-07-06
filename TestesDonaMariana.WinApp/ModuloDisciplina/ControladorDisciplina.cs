using Microsoft.Identity.Client;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.WinApp.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase<Disciplina, RepositorioDisciplina, TabelaDisciplinaControl, TelaDisciplinaForm, RepositorioMateria, NenhumRepositorio>
    {
        private readonly TabelaDisciplinaControl _tabelaDisciplina;
        private readonly RepositorioDisciplina _repositorioDisciplina;

        public ControladorDisciplina(RepositorioDisciplina _repositorio, TabelaDisciplinaControl _tabela, RepositorioMateria _repositorio2) : base(_repositorio, _tabela, _repositorio2)
        {
            _tabelaDisciplina = _tabela;
            _repositorioDisciplina = _repositorio;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
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

        public void CarregarComboBox(TelaDisciplinaForm telaDisciplina, Disciplina disciplina)
        {
            //disciplina.ListaMaterias = _repositorioDisciplina.ObterMaterias(disciplina);
        }
    }
}
