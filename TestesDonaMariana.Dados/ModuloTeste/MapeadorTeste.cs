using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            throw new NotImplementedException();
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {
            throw new NotImplementedException();
        }
    }
}
