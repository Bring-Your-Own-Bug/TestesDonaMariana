using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloTeste
{
    public class RepositorioTeste : RepositorioBaseSql<Teste>
    {
        public RepositorioTeste()
        {
            onComandoDeRelacaoAdd += AdicionarQuestoes;
            onComandoDeRelacaoEdit += EditarQuestoes;
        }
        protected override string AddCommand => @"INSERT INTO [dbo].[TBTESTE]
                                                           (
                                                                [TITULO]
                                                               ,[NUMERODEQUESTOES]
                                                               ,[DISCIPLINA_ID]
                                                               ,[MATERIA_ID]
                                                               ,[DATAGERACAO]
                                                           )
                                                     VALUES
                                                           (
                                                                 @TITULO
                                                                ,@NUMERODEQUESTOES
                                                                ,@DISCIPLINA_ID
                                                                ,@MATERIA_ID
                                                                ,@DATAGERACAO
                                                           )
                                                           SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => @"UPDATE [dbo].[TBTESTE]

                                                  SET [TITULO] =             @TITULO
                                                     ,[NUMERODEQUESTOES] =   @NUMERODEQUESTOES                                                  
                                                     ,[DISCIPLINA_ID] =      @DISCIPLINA_ID
                                                     ,[MATERIA_ID] =         @MATERIA_ID
                                                     ,[DATAGERACAO] =        @DATAGERACAO

                                                WHERE[ID] = @ID";

        protected override string DeleteCommand => @"DELETE FROM [dbo].[TBTESTE_TBQUESTAO]
                                                    WHERE [TESTE_ID] =                         @ID
                                                    DELETE FROM [dbo].[TBTESTE]
													WHERE [ID] =                               @ID";

        protected override string SelectCommand => @"SELECT    T.[ID]                   TESTE_ID
                                                              ,T.[TITULO]               TESTE_TITULO
                                                              ,T.[DISCIPLINA_ID]        TESTE_DISCIPLINA_ID
                                                              ,T.[MATERIA_ID]           TESTE_MATERIA_ID
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
                                                                     ,T.[NUMERODEQUESTOES]     TESTE_NUMEROQUESTOES 
                                                                     ,T.[DISCIPLINA_ID]        TESTE_DISCIPLINA_ID
                                                                     ,T.[MATERIA_ID]           TESTE_MATERIA_ID
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
            
                                                                     LEFT JOIN [dbo].[TBMATERIA] AS M
                                                                 ON T.MATERIA_ID =          M.ID";

        protected string AddQuestoes => @"INSERT INTO [dbo].[TBTESTE_TBQUESTAO]
                                                   (
                                                        [TESTE_ID]
                                                       ,[QUESTAO_ID]
                                                   )
                                             VALUES
                                                   (
                                                        @TESTE_ID
                                                       ,@QUESTAO_ID
                                                   )";

        protected string EditQuestoes => @"UPDATE [dbo].[TBTESTE_TBQUESTAO]

                                                   SET [TESTE_ID] =         @TESTE_ID
                                                      ,[QUESTAO_ID] =       @QUESTAO_ID

                                                 WHERE
                                                        TESTE_ID =          @ID";

        protected string DeleteQuestoes => @"DELETE FROM [dbo].[TBTESTE_TBQUESTAO]
                                                    WHERE TESTE_ID =        @ID";

        protected string SelectQuestoes => @"SELECT        
                                                     TQ.[TESTE_ID]
                                                    ,TQ.[QUESTAO_ID]

                                                    ,Q.[ID]                     QUESTAO_ID
                                                    ,Q.[MATERIA_ID]             QUESTAO_MATERIA_ID
                                                    ,Q.[ENUNCIADO]              QUESTAO_ENUNCIADO
                                                    ,Q.[ALTERNATIVACORRETA]     QUESTAO_ALTERNATIVACORRETA

                                                    ,M.[ID]                     MATERIA_ID
                                                    ,M.[NOME]                   MATERIA_NOME
                                                    ,M.[DISCIPLINA_ID]          MATERIA_DISCIPLINA_ID
                                                    ,M.[SERIE]                  MATERIA_SERIE

                                                    ,D.[ID]                     DISCIPLINA_ID
                                                    ,D.[NOME]                   DISCIPLINA_NOME

                                            FROM [dbo].[TBTESTE_TBQUESTAO] AS TQ

                                            INNER JOIN [dbo].[TBQUESTAO] AS Q
                                            ON TQ.[QUESTAO_ID] =                Q.[ID]

                                            INNER JOIN [dbo].[TBMATERIA] AS M
                                            ON Q.[MATERIA_ID] =                 M.[ID]

                                            INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                            ON M.[DISCIPLINA_ID] =              D.[ID]

                                            WHERE [TESTE_ID] =                  @ID";

        private void AdicionarQuestoes(Teste teste)
        {
            comandoBd.CommandText = AddQuestoes;

            for (int i = 0; i < teste.ListaQuestoes.Count; i++)
            {
                comandoBd.Parameters.Clear();
                comandoBd.Parameters.AddWithValue("TESTE_ID", teste.Id);
                comandoBd.Parameters.AddWithValue("QUESTAO_ID", teste.ListaQuestoes[i].Id);

                comandoBd.ExecuteNonQuery();
            }
        }

        private void EditarQuestoes(Teste teste)
        {
            comandoBd.CommandText = DeleteQuestoes;

            comandoBd.Parameters.Clear();

            comandoBd.Parameters.AddWithValue("ID", teste.Id);

            comandoBd.ExecuteNonQuery();

            comandoBd.CommandText = AddQuestoes;

            for (int i = 0; i < teste.ListaQuestoes.Count; i++)
            {
                comandoBd.Parameters.Clear();
                comandoBd.Parameters.AddWithValue("TESTE_ID", teste.Id);
                comandoBd.Parameters.AddWithValue("QUESTAO_ID", teste.ListaQuestoes[i].Id);

                comandoBd.ExecuteNonQuery();
            }
        }

        public List<Questao> ObterQuestoes(Teste teste)
        {
            conectarBd.Open();

            comandoBd.Parameters.Clear();

            comandoBd.CommandText = SelectQuestoes;

            comandoBd.Parameters.AddWithValue("ID", teste.Id);

            SqlDataReader reader = comandoBd.ExecuteReader();

            List<Questao> questoes = new();

            while (reader.Read())
            {
                Questao questao = new MapeadorQuestao().ConverterRegistro(reader);
                questoes.Add(questao);
            }

            conectarBd.Close();

            return questoes;
        }

        protected override MapeadorBase<Teste> Mapear => new MapeadorTeste();
    }
}
