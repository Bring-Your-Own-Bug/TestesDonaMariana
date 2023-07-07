using Microsoft.Data.SqlClient;
using System.Data;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
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
            Materia materia = new Materia();

            int id = (int)leitorRegistros["MATERIA_ID"];
            string nome = Convert.ToString(leitorRegistros["MATERIA_NOME"])!;
            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);
            Serie serie = (Serie)(int)leitorRegistros["MATERIA_SERIE"];

            materia.Id = id;
            materia.Nome = nome;
            materia.Disciplina = disciplina;
            materia.Serie = serie;

            return materia;
        }
    }
}
