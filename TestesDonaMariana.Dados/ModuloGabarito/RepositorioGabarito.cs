using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloGabarito;

namespace TestesDonaMariana.Dados.ModuloGabarito
{
    public class RepositorioGabarito : RepositorioBaseSql<Gabarito>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override void ConfigurarParametros(Gabarito registro)
        {
            throw new NotImplementedException();
        }

        protected override void ObterPropriedadesEntidade(Gabarito entidade, SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
