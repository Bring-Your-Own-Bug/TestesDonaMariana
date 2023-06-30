using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dados.ModuloMateria
{
    public class RepositorioMateria : RepositorioBaseSql<Materia>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override void ConfigurarParametros(Materia registro)
        {
            throw new NotImplementedException();
        }

        protected override void ObterPropriedadesEntidade(Materia entidade, SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
