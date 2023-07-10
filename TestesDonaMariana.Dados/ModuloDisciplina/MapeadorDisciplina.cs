using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.Dados.ModuloDisciplina
{
    public class MapeadorDisciplina : MapeadorBase<Disciplina>
    {
        public override void ConfigurarParametros(SqlCommand comando, Disciplina registro)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("NOME", registro.Nome);
        }

        public override Disciplina ConverterRegistro(SqlDataReader leitorRegistros)
        {
            Disciplina disciplina = new();

            int idDisciplina = Convert.ToInt32(leitorRegistros["DISCIPLINA_ID"]);
            string nomeDisciplina = Convert.ToString(leitorRegistros["DISCIPLINA_NOME"])!;

            disciplina.Id = idDisciplina;
            disciplina.Nome = nomeDisciplina;

            return disciplina;
        }
    }
}
