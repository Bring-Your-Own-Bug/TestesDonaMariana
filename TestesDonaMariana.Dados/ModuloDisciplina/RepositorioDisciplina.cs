using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.Dados.ModuloDisciplina
{
    public class RepositorioDisciplina : RepositorioBaseSql<Disciplina>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override void ConfigurarParametros(Disciplina registro)
        {
            throw new NotImplementedException();
        }

        protected override void ObterPropriedadesEntidade(Disciplina entidade, SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
