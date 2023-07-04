using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase<Questao, TabelaQuestaoControl, TelaQuestaoForm>
    {
        private TabelaQuestaoControl _tabelaQuestao;

        public ControladorQuestao(IRepositorio<Questao> _repositorio, IRepositorio<Materia> _repositorio2, TabelaQuestaoControl _tabela) : base(_repositorio, _repositorio2, _tabela)
        {
        }

        public override TabelaQuestaoControl ObterListagem()
        {
            return _tabelaQuestao;
        }
    }
}
