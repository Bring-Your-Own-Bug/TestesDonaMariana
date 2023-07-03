using Microsoft.Data.SqlClient;
using System.Data;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloSerie;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloMateria
{
    public class RepositorioMateria : RepositorioBaseSql<Materia>
    {
        protected override string AddCommand => @"INSERT INTO [dbo].[TBMATERIA]
                                                           (
                                                                [NOME]
                                                               ,[DISCIPLINA_ID]
                                                               ,[SERIE]
                                                           )
                                                     VALUES
                                                           (
                                                                @NOME
                                                               ,@DISCIPLINA_ID
                                                               ,@SERIE
                                                           )
                                                           SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => @"UPDATE [dbo].[TBMATERIA]
                                                       SET [NOME] =                 @NOME
                                                          ,[DISCIPLINA_ID] =        @DISCIPLINA_ID
                                                          ,[SERIE] =                @SERIE

                                                     WHERE [ID] =                   @ID";

        protected override string DeleteCommand => @"DELETE FROM [dbo].[TBMATERIA]
													WHERE [ID] =                    @ID";

        protected override string SelectCommand => @"SELECT    M.[ID]                   MATERIA_ID
                                                              ,M.[NOME]                 MATERIA_NOME
                                                              ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                              ,M.[SERIE]                MATERIA_SERIE

                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID

                                                          WHERE [ID] =                   @ID";

        protected override string SelectAllCommand => @"SELECT    M.[ID]                   MATERIA_ID
                                                              ,M.[NOME]                 MATERIA_NOME
                                                              ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                              ,M.[SERIE]                MATERIA_SERIE

                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID";

        protected override void ConfigurarParametros(Materia registro)
        {
            comandoBd.Parameters.Clear();
            comandoBd.Parameters.AddWithValue("NOME", registro.Nome);
            comandoBd.Parameters.AddWithValue("DISCIPLINA_ID", registro.Disciplina.Id);
            comandoBd.Parameters.AddWithValue("SERIE", SqlDbType.Bit).Value = registro.Serie;
        }

        protected override void ObterPropriedadesEntidade(Materia entidade, SqlDataReader reader)
        {
            Disciplina disciplina = new();

            int idDisciplina = (int)reader["DISCIPLINA_ID"];
            string nomeDisciplina = Convert.ToString(reader["NOME"])!;

            disciplina.Id = idDisciplina;
            disciplina.Nome = nomeDisciplina;


            int id = (int)reader["ID"];
            string nome = Convert.ToString(reader["NOME"])!;
            Serie serie = (Serie)(int)reader["SERIE"];

            entidade.Id = id;
            entidade.Nome = nome;
            entidade.Disciplina = disciplina;
            entidade.Serie = serie;
        }
    }
}
