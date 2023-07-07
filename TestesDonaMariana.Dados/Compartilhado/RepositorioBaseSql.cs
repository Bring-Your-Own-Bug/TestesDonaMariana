using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Data;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Dados.Compartilhado
{
    public abstract class RepositorioBaseSql<TEntidade>
        where TEntidade : Entidade<TEntidade>, new()
    {
        private const string ENDERECO_BD = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=TestesDonaMarianaDb;Integrated Security=True;";

        protected static SqlConnection conectarBd = new(ENDERECO_BD);

        protected SqlCommand comandoBd = conectarBd.CreateCommand();

        protected event Action<TEntidade> onComandoDeRelacaoAdd;

        protected event Action<TEntidade> onComandoDeRelacaoEdit;

        protected event Action onComandoDeRelacaoDelete;

        protected event Action<List<TEntidade>, SqlDataReader> onComandoDeRelacaoSelect;

        public RepositorioBaseSql()
        {

        }

        protected abstract string AddCommand { get; }

        protected abstract string EditCommand { get; }

        protected abstract string DeleteCommand { get; }

        protected abstract string SelectCommand { get; }

        protected abstract string SelectAllCommand { get; }

        protected abstract MapeadorBase<TEntidade> Mapear { get; }

        public virtual void Adicionar(TEntidade registro)
        {
            conectarBd.Open();

            comandoBd.CommandText = AddCommand;

            Mapear.ConfigurarParametros(comandoBd, registro);

            object id = comandoBd.ExecuteScalar();

            registro.Id = Convert.ToInt32(id);

            onComandoDeRelacaoAdd?.Invoke(registro);

            conectarBd.Close();
        }

        public virtual void Editar(TEntidade novoRegistro)
        {
            conectarBd.Open();

            comandoBd.CommandText = EditCommand;

            Mapear.ConfigurarParametros(comandoBd, novoRegistro);

            comandoBd.Parameters.AddWithValue("ID", novoRegistro.Id);

            comandoBd.ExecuteNonQuery();

            onComandoDeRelacaoEdit?.Invoke(novoRegistro);

            conectarBd.Close();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            conectarBd.Open();

            comandoBd.Parameters.Clear();

            comandoBd.Parameters.AddWithValue("ID", registroSelecionado.Id);

            onComandoDeRelacaoDelete?.Invoke();

            comandoBd.CommandText = DeleteCommand;

            comandoBd.ExecuteNonQuery();

            conectarBd.Close();
        }

        public virtual List<TEntidade> ObterListaRegistros()
        {
            conectarBd.Open();

            comandoBd.CommandText = SelectAllCommand;

            SqlDataReader reader = comandoBd.ExecuteReader();

            List<TEntidade> registros = new();

            while (reader.Read())
            {
                TEntidade registro = Mapear.ConverterRegistro(reader);

                registros.Add(registro);
            }

            reader.Close();

            onComandoDeRelacaoSelect?.Invoke(registros, reader);

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

            if (reader.Read())
                registro = Mapear.ConverterRegistro(reader);

            conectarBd.Close();

            return registro;
        }
    }
}