using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Dados.Compartilhado
{
    public abstract class RepositorioBaseSql<TEntidade, TMapeador> 
        where TEntidade : Entidade<TEntidade>, new()
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        private const string ENDERECO_BD = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=TestesDonaMarianaDb;Integrated Security=True";

        private static SqlConnection conectarBd = new(ENDERECO_BD);

        protected SqlCommand comandoBd = conectarBd.CreateCommand();

        protected abstract string AddCommand { get; }

        protected abstract string EditCommand { get; }

        protected abstract string DeleteCommand { get; }

        protected abstract string SelectCommand { get; }

        protected abstract string SelectAllCommand { get; }

        public int Id { get; private set; }

        public virtual void Adicionar(TEntidade registro)
        {
            conectarBd.Open();

            comandoBd.CommandText = AddCommand;

            TMapeador mapeador = new();

            mapeador.ConfigurarParametros(comandoBd, registro);

            object id = comandoBd.ExecuteScalar();

            Id = Convert.ToInt32(id) + 1;

            registro.Id = Convert.ToInt32(id);

            conectarBd.Close();
        }

        public virtual void Editar(TEntidade novoRegistro)
        {
            conectarBd.Open();

            comandoBd.CommandText = EditCommand;

            TMapeador mapeador = new();

            mapeador.ConfigurarParametros(comandoBd, novoRegistro);

            comandoBd.Parameters.AddWithValue("ID", novoRegistro.Id);

            comandoBd.ExecuteNonQuery();

            conectarBd.Close();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            conectarBd.Open();

            comandoBd.CommandText = DeleteCommand;

            comandoBd.Parameters.Clear();

            comandoBd.Parameters.AddWithValue("ID", registroSelecionado.Id);

            comandoBd.ExecuteNonQuery();

            conectarBd.Close();
        }

        public virtual List<TEntidade> ObterListaRegistros()
        {
            conectarBd.Open();

            comandoBd.CommandText = SelectAllCommand;

            SqlDataReader reader = comandoBd.ExecuteReader();

            List<TEntidade> registros = new();

            TMapeador mapeador = new();

            while (reader.Read())
            {
                TEntidade registro = mapeador.ConverterRegistro(reader);

                registros.Add(registro);
            }

            conectarBd.Close();

            return registros;
        }

        public virtual TEntidade? SelecionarPorId(int idSelecionado)
        {
            conectarBd.Open();

            comandoBd.CommandText = SelectCommand;

            comandoBd.Parameters.AddWithValue("ID", idSelecionado);

            SqlDataReader reader = comandoBd.ExecuteReader();

            TEntidade registro = null;

            TMapeador mapeador = new();

            if (reader.Read())
                registro = mapeador.ConverterRegistro(reader);

            conectarBd.Close();

            return registro;
        }
    }
}