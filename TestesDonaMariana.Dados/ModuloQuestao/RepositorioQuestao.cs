using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Dados.ModuloQuestao
{
    public class RepositorioQuestao : RepositorioBaseSql<Questao>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override void ConfigurarParametros(Questao registro)
        {
            throw new NotImplementedException();
        }

        protected override void ObterPropriedadesEntidade(Questao entidade, SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
