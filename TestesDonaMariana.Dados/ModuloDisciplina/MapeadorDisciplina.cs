using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.Compartilhado;
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
            Disciplina disciplina = new Disciplina();

            int idDisciplina = (int)leitorRegistros["ID"];
            string nomeDisciplina = Convert.ToString(leitorRegistros["NOME"])!;

            disciplina.Id = idDisciplina;
            disciplina.Nome = nomeDisciplina;

            return disciplina;
        }
    }
}
