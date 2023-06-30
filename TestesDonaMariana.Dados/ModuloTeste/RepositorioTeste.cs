using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloTeste
{
    public class RepositorioTeste : RepositorioBaseSql<Teste>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override void ConfigurarParametros(Teste registro)
        {
            throw new NotImplementedException();
        }

        protected override void ObterPropriedadesEntidade(Teste entidade, SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
