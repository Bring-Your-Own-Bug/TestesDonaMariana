using TestesDonaMariana.Dados.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloGabarito;

namespace TestesDonaMariana.WinApp.ModuloGabarito
{
    public class ControladorGabarito : ControladorBase<Gabarito, RepositorioGabarito, TabelaGabaritoControl, TelaGabaritoForm, NenhumRepositorio, NenhumRepositorio>
    {
        private RepositorioGabarito _repositorioGabarito;
        private TabelaGabaritoControl _tabelaGabarito;

        public ControladorGabarito(RepositorioGabarito _repositorio, TabelaGabaritoControl _tabela) : base(_repositorio, _tabela)
        {
            _repositorio = _repositorioGabarito;
            _tabela = _tabelaGabarito;
        }

        public override TabelaGabaritoControl ObterListagem()
        {
            return _tabelaGabarito;
        }
    }
}
