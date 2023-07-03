using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dados.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            throw new NotImplementedException();
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {
            throw new NotImplementedException();
        }
    }
}
