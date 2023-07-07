using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

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

                                                              ,D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID

                                                          WHERE [ID] =                   @ID";

        protected override string SelectAllCommand => @"SELECT     M.[ID]                   MATERIA_ID
                                                                  ,M.[NOME]                 MATERIA_NOME
                                                                  ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                                  ,M.[SERIE]                MATERIA_SERIE

                                                                  ,D.[ID]                   DISCIPLINA_ID
                                                                  ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID";

        //protected string SelectQuestoes => @"SELECT        
        //                                             M.[ID]                     MATERIA_ID
        //                                            ,M.[NOME]                   MATERIA_NOME
        //                                            ,M.[DISCIPLINA_ID]          MATERIA_DISCIPLINA_ID
        //                                            ,M.[SERIE]                  MATERIA_SERIE

        //                                            ,Q.[ID]                     QUESTAO_ID
        //                                            ,Q.[MATERIA_ID]             QUESTAO_MATERIA_ID
        //                                            ,Q.[ENUNCIADO]              QUESTAO_ENUNCIADO
        //                                            ,Q.[ALTERNATIVACORRETA]     QUESTAO_ALTERNATIVACORRETA

        //                                            ,D.[ID]                     DISCIPLINA_ID
        //                                            ,D.[NOME]                   DISCIPLINA_NOME

        //                                    FROM [dbo].[TBMATERIA] AS M

        //                                    INNER JOIN [dbo].[TBQUESTAO] AS Q
        //                                    ON Q.[MATERIA_ID] =                M.[ID]

        //                                    INNER JOIN [dbo].[TBDISCIPLINA] AS D
        //                                    ON M.[DISCIPLINA_ID] =              D.[ID]";

        protected override MapeadorBase<Materia> Mapear => new MapeadorMateria();

        //public List<Questao> ObterQuestoes(Materia materia)
        //{
        //    conectarBd.Open();

        //    comandoBd.Parameters.Clear();

        //    comandoBd.CommandText = SelectQuestoes;

        //    comandoBd.Parameters.AddWithValue("ID", materia.Id);

        //    SqlDataReader reader = comandoBd.ExecuteReader();

        //    List<Questao> questoes = new();

        //    while (reader.Read())
        //    {
        //        Questao questao = new MapeadorQuestao().ConverterRegistro(reader);
        //        questoes.Add(questao);
        //    }

        //    conectarBd.Close();

        //    return questoes;
        //}
    }
}
