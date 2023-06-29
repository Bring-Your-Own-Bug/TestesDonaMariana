using Microsoft.Data.SqlClient;
using PartyPlanner.Dominio.Compartilhado;

namespace PartyPlanner.Dados.Compartilhado
{
    public abstract class RepositorioBaseSql<TEntidade> where TEntidade : Entidade<TEntidade>, new()
    {
        protected int id = 1001;

        private const string ENDERECO_BD = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=PartyPlannerDb;Integrated Security=True;Pooling=False";

        private static SqlConnection conectarBd = new(ENDERECO_BD);

        protected SqlCommand comandoBd = conectarBd.CreateCommand();

        protected abstract string AddCommand { get; }

        protected abstract string EditCommand { get; }

        protected abstract string DeleteCommand { get; }

        protected abstract string SelectCommand { get; }

        protected abstract string SelectAllCommand { get; }

        public int Id { get { return id; } }

        public void Adicionar(TEntidade registro)
        {
            conectarBd.Open();

            comandoBd.CommandText = AddCommand;

            ConfigurarParametros(registro);

            object id = comandoBd.ExecuteScalar();

            registro.Id = Convert.ToInt32(id);

            conectarBd.Close();
        }

        public void Editar(TEntidade novoRegistro)
        {
            conectarBd.Open();

            comandoBd.CommandText = EditCommand;

            ConfigurarParametros(novoRegistro);

            comandoBd.Parameters.AddWithValue("ID", novoRegistro.Id);

            comandoBd.ExecuteNonQuery();

            conectarBd.Close();
        }

        public void Excluir(TEntidade registroSelecionado)
        {
            conectarBd.Open();

            comandoBd.CommandText = DeleteCommand;

            comandoBd.Parameters.Clear();

            comandoBd.Parameters.AddWithValue("ID", registroSelecionado.Id);

            comandoBd.ExecuteNonQuery();

            conectarBd.Close();
        }

        public List<TEntidade> ObterListaRegistros()
        {
            conectarBd.Open();

            List<TEntidade> lista = new();

            comandoBd.CommandText = SelectAllCommand;

            SqlDataReader reader = comandoBd.ExecuteReader();

            while (reader.Read())
            {
                TEntidade entidade = new();

                ObterPropriedadesEntidade(entidade, reader);

                lista.Add(entidade);
            }

            conectarBd.Close();

            return lista;
        }

        public TEntidade? SelecionarPorId(int idSelecionado)
        {
            conectarBd.Open();

            TEntidade entidade = new();

            comandoBd.CommandText = SelectCommand;

            comandoBd.Parameters.AddWithValue("ID", idSelecionado);

            SqlDataReader reader = comandoBd.ExecuteReader();

            if (reader.Read())
            {
                ObterPropriedadesEntidade(entidade, reader);
            }

            conectarBd.Close();

            return entidade;
        }

        protected abstract void ObterPropriedadesEntidade(TEntidade entidade, SqlDataReader reader);

        protected abstract void ConfigurarParametros(TEntidade registro);
    }
}