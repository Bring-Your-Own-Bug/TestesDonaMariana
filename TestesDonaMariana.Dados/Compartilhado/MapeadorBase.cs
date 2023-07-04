using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Dados.Compartilhado
{
    public class MapeadorBase<T> where T : Entidade<T>
    {
        public virtual void ConfigurarParametros(SqlCommand comando, T registro) { }

        public virtual T ConverterRegistro(SqlDataReader leitorRegistros) { T teste = default(T); return teste; }
    }
}
