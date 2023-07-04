using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase<Materia, TabelaMateriaControl, TelaMateriaForm>
    {
        private TabelaMateriaControl _tabelaMateria;

        public ControladorMateria(IRepositorio<Questao> _repositorio, IRepositorio<Materia> _repositorio2, IRepositorio<Disciplina> _repositorio3, TabelaMateriaControl _tabela) : base(_repositorio, _repositorio2, _repositorio3, _tabela)
        {

        }

        public override TabelaMateriaControl ObterListagem()
        {
            return _tabelaMateria;
        }
    }
}
