using Microsoft.Data.SqlClient;
using System.Data;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloSerie;

namespace TestesDonaMariana.Dados.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("DISCIPLINA_ID", registro.Disciplina.Id);
            comando.Parameters.AddWithValue("SERIE", SqlDbType.Bit).Value = registro.Serie;
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {
            Materia materia = new();

            int id = Convert.ToInt32(leitorRegistros["MATERIA_ID"]);
            string nome = Convert.ToString(leitorRegistros["MATERIA_NOME"])!;
            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);
            Serie serie = (Serie)Convert.ToInt32(leitorRegistros["MATERIA_SERIE"]);

            materia.Id = id;
            materia.Nome = nome;
            materia.Disciplina = disciplina;
            materia.Serie = serie;

            return materia;
        }
    }
}
