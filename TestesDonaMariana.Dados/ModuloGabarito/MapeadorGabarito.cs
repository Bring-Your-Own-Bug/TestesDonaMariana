using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloGabarito;

namespace TestesDonaMariana.Dados.ModuloGabarito
{
    public class MapeadorGabarito : MapeadorBase<Gabarito>
    {
        public override void ConfigurarParametros(SqlCommand comando, Gabarito registro)
        {
            throw new NotImplementedException();
        }

        public override Gabarito ConverterRegistro(SqlDataReader leitorRegistros)
        {
            throw new NotImplementedException();
        }
    }
}
