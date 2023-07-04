using TestesDonaMariana.Dados.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase<Disciplina, TabelaDisciplinaControl, TelaDisciplinaForm>
    {
        private TabelaDisciplinaControl _tabelaDisciplina;

        public ControladorDisciplina(IRepositorio<Disciplina> _repositorio, TabelaDisciplinaControl _tabela) : base(_repositorio, _tabela)
        {
        }

        public override TabelaDisciplinaControl ObterListagem()
        {
            _tabelaDisciplina ??= new TabelaDisciplinaControl();
            return _tabelaDisciplina;
        }
    }
}
