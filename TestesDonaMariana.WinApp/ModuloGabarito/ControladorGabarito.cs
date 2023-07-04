using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloGabarito;

namespace TestesDonaMariana.WinApp.ModuloGabarito
{
    public class ControladorGabarito : ControladorBase<Gabarito, TabelaGabaritoControl, TelaGabaritoForm>
    {
        private TabelaGabaritoControl _tabelaGabarito;

        public ControladorGabarito(IRepositorio<Gabarito> _repositorio, TabelaGabaritoControl _tabela) : base(_repositorio, _tabela)
        {
        }

        public override TabelaGabaritoControl ObterListagem()
        {
            return _tabelaGabarito;
        }
    }
}
