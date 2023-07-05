using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloTeste
{
    public class RepositorioTeste : RepositorioBaseSql<Teste>
    {
        protected override string AddCommand => @"INSERT INTO [dbo].[TBTESTE]
                                                           (
                                                                [TITULO]
                                                               ,[NUMERODEQUESTOES]
                                                               ,[DISCIPLINA_ID]
                                                               ,[MATERIA_ID]
                                                               ,[LISTA_QUESTAO_ID]
                                                               ,[DATAGERACAO_ID]
                                                           )
                                                     VALUES
                                                           (
                                                                 @TITULO
                                                                ,@NUMERODEQUESTOES
                                                                ,@DISCIPLINA_ID
                                                                ,@MATERIA_ID
                                                                --,@LISTA_QUESTAO_ID
                                                                ,@DATAGERACAO_ID
                                                           )
                                                           SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => @"UPDATE [dbo].[TBTESTE]

                                                  SET [TITULO] =             @TITULO
                                                     ,[NUMERODEQUESTOES] =   @NUMERODEQUESTOES                                                  
                                                     ,[DISCIPLINA_ID] =      @DISCIPLINA_ID
                                                     ,[MATERIA_ID] =         @MATERIA_ID
                                                     --,[LISTA_QUESTAO_ID] =   @LISTA_QUESTAO_ID
                                                     ,[DATAGERACAO] =        @DATAGERACAO

                                                WHERE[ID] = @ID";

        protected override string DeleteCommand => @"DELETE FROM [dbo].[TBTESTE]
													WHERE [ID] =                    @ID";

        protected override string SelectCommand => @"SELECT    T.[ID]                   TESTE_ID
                                                              ,T.[TITULO]               TESTE_TITULO
                                                              ,T.[DISCIPLINA_ID]        TESTE_DISCIPLINA_ID
                                                              ,T.[MATERIA_ID]           TESTE_MATERIA_ID
                                                              --,T.[LISTA_QUESTAO_ID]     TESTE_LISTA_QUESTAO_ID
                                                              ,T.[DATAGERACAO]          TESTE_DATAGERACAO

                                                              ,D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                              ,M.[ID]                   MATERIA_ID
                                                              ,M.[NOME]                 MATERIA_NOME
                                                              ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                              ,M.[SERIE]                MATERIA_SERIE

                                                          FROM [dbo].[TBTESTE] AS T

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON T.DISCIPLINA_ID =          D.ID

                                                          INNER JOIN [dbo].[TBMATERIA] AS M
                                                          ON T.MATERIA_ID =          M.ID

                                                          WHERE [ID] =                   @ID";

        protected override string SelectAllCommand => @"SELECT        T.[ID]                   TESTE_ID
                                                                     ,T.[TITULO]               TESTE_TITULO
                                                                     ,T.[DISCIPLINA_ID]        TESTE_DISCIPLINA_ID
                                                                     ,T.[MATERIA_ID]           TESTE_MATERIA_ID
                                                                     --,T.[LISTA_QUESTAO_ID]     TESTE_LISTA_QUESTAO_ID
                                                                     ,T.[DATAGERACAO]          TESTE_DATAGERACAO

                                                                     ,D.[ID]                   DISCIPLINA_ID
                                                                     ,D.[NOME]                 DISCIPLINA_NOME

                                                                     ,M.[ID]                   MATERIA_ID
                                                                     ,M.[NOME]                 MATERIA_NOME
                                                                     ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                                     ,M.[SERIE]                MATERIA_SERIE
                                                                     
                                                                     FROM [dbo].[TBTESTE] AS T

                                                                     INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                                     ON T.DISCIPLINA_ID =          D.ID
            
                                                                     INNER JOIN [dbo].[TBMATERIA] AS M
                                                                     ON T.DISCIPLINA_ID =          M.ID";

        protected override MapeadorBase<Teste> Mapear => new MapeadorTeste();
    }
}
