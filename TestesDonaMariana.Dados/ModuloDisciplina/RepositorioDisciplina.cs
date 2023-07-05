using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.Dados.ModuloDisciplina
{
    public class RepositorioDisciplina : RepositorioBaseSql<Disciplina>
    {
        protected override string AddCommand => @"INSERT INTO [dbo].[TBDISCIPLINA]
                                                        (
                                                             [NOME]
                                                        )
                                                   VALUES
                                                        (
                                                             @NOME
                                                        )
                                                        SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => @"UPDATE [dbo].[TBDISCIPLINA]
                                                       SET [NOME] =                     @NOME
                                                     WHERE
                                                            [ID] =                      @ID";

        protected override string DeleteCommand => @"DELETE FROM [dbo].[TBDISCIPLINA]
													WHERE [ID] =                        @ID";

        protected override string SelectCommand => @"SELECT    D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBDISCIPLINA] AS D

													      WHERE [ID] =                  @ID";

        protected override string SelectAllCommand => @"SELECT D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBDISCIPLINA] AS D";

        protected override MapeadorBase<Disciplina> Mapear => new MapeadorDisciplina();
    }
}
