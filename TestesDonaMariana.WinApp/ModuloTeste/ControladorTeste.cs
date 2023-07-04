using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase<Teste, TabelaTesteControl, TelaTesteForm>
    {
        private TabelaTesteControl _tabelaTeste;

        public ControladorTeste(IRepositorio<Teste> _repositorio, IRepositorio<Disciplina> _repositorio2, IRepositorio<Questao> _repositorio3, TabelaTesteControl _tabela) : base(_repositorio, _repositorio2, _repositorio3, _tabela)
        {
        }

        public override TabelaTesteControl ObterListagem()
        {
            return _tabelaTeste;
        }
    }
}
