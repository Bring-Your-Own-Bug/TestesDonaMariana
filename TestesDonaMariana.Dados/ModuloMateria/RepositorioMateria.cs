using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloSerie;

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

        protected override string SelectAllCommand => @"SELECT     M.[ID]                   MATERIA_ID
                                                                  ,M.[NOME]                 MATERIA_NOME
                                                                  ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                                  ,M.[SERIE]                MATERIA_SERIE

                                                                  ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID";

        protected override MapeadorBase<Materia> Mapear => new MapeadorMateria();
    }
}
