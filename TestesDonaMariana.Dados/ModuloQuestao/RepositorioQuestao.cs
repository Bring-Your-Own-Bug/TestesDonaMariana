using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Data;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Dados.ModuloQuestao
{
    public class RepositorioQuestao : RepositorioBaseSql<Questao>
    {
        public RepositorioQuestao()
        {
            onComandoDeRelacaoAdd += AdicionarAlternativas;
            onComandoDeRelacaoEdit += EditarAlternativas;
            //onComandoDeRelacaoDelete += ExcluirAlternativas;
            onComandoDeRelacaoSelect += ObterAlternativas;
        }

        protected override string AddCommand => @"INSERT INTO [dbo].[TBQUESTAO]
                                                           (
                                                                [MATERIA_ID]
                                                               ,[ENUNCIADO]
                                                               ,[ALTERNATIVACORRETA]
                                                           )
                                                     VALUES
                                                           (
                                                                 @MATERIA_ID
                                                                ,@ENUNCIADO
                                                                ,@ALTERNATIVACORRETA
                                                           )
                                                           SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => @"UPDATE [dbo].[TBQUESTAO]
                                                         SET 
                                                               [MATERIA_ID] =           @MATERIA_ID
                                                              ,[ENUNCIADO] =            @ENUNCIADO
                                                              ,[ALTERNATIVACORRETA] =   @ALTERNATIVACORRETA
                                                         WHERE 
                                                               [ID] =                   @ID";

        protected override string DeleteCommand => @"DELETE FROM [dbo].[TBALTERNATIVAS]
                                                    WHERE QUESTAO_ID =                  @ID
                                                    DELETE FROM [dbo].[TBQUESTAO]
													WHERE [ID] =		                @ID";

        protected override string SelectCommand => @"SELECT   Q.[ID]                    QUESTAO_ID
                                                                ,Q.[MATERIA_ID]         QUESTAO_MATERIA_ID
                                                                ,Q.[ENUNCIADO]          QUESTAO_ENUNCIADO
                                                                ,Q.[ALTERNATIVACORRETA] QUESTAO_ALTERNATIVACORRETA

                                                                ,M.[ID]                 MATERIA_ID
                                                                ,M.[NOME]               MATERIA_NOME
                                                                ,M.[DISCIPLINA_ID]      MATERIA_DISCIPLINA_ID
                                                                ,M.[SERIE]              MATERIA_SERIE

                                                                ,D.[ID]                 DISCIPLINA_ID
                                                                ,D.[NOME]               DISCIPLINA_NOME

                                                            FROM [dbo].[TBQUESTAO] AS Q

                                                            INNER JOIN [dbo].[TBMATERIA] AS M
                                                            ON Q.MATERIA_ID = M.ID

                                                            INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                            ON M.DISCIPLINA_ID = D.ID

                                                            WHERE [ID] =                @ID";

        protected override string SelectAllCommand => @"SELECT   Q.[ID]                 QUESTAO_ID
                                                                ,Q.[MATERIA_ID]         QUESTAO_MATERIA_ID
                                                                ,Q.[ENUNCIADO]          QUESTAO_ENUNCIADO
                                                                ,Q.[ALTERNATIVACORRETA] QUESTAO_ALTERNATIVACORRETA

                                                                ,A.[ALTERNATIVA]        ALTERNATIVA_ALTERNATIVA

                                                                ,M.[ID]                 MATERIA_ID
                                                                ,M.[NOME]               MATERIA_NOME
                                                                ,M.[DISCIPLINA_ID]      MATERIA_DISCIPLINA_ID
                                                                ,M.[SERIE]              MATERIA_SERIE

                                                                ,D.[ID]                 DISCIPLINA_ID
                                                                ,D.[NOME]               DISCIPLINA_NOME

                                                            FROM [dbo].[TBQUESTAO] AS Q

                                                            INNER JOIN [dbo].[TBALTERNATIVAS] AS A
                                                            ON Q.ID = A.QUESTAO_ID

                                                            INNER JOIN [dbo].[TBMATERIA] AS M
                                                            ON Q.MATERIA_ID = M.ID

                                                            INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                            ON M.DISCIPLINA_ID = D.ID";

        protected string AddAlternativas => @"INSERT INTO [dbo].[TBALTERNATIVAS]
                                                        (
                                                             [QUESTAO_ID]
                                                            ,[ALTERNATIVA]
                                                        )
                                                    VALUES
                                                        (
                                                              @QUESTAO_ID
                                                             ,@ALTERNATIVA
                                                        )";

        protected string EditAlternativas => @"UPDATE [dbo].[TBALTERNATIVAS]

                                                   SET
                                                        [ALTERNATIVA] =      @ALTERNATIVA

                                                 WHERE
                                                        QUESTAO_ID =         @QUESTAO_ID";

        protected string DeleteAlternativas => @"DELETE FROM [dbo].[TBALTERNATIVAS]
                                                    WHERE QUESTAO_ID =       @ID";

        public void AdicionarAlternativas(Questao questao)
        {
            comandoBd.CommandText = AddAlternativas;

            for (int i = 0; i < questao.Alternativas.Count; i++)
            {
                comandoBd.Parameters.Clear();
                comandoBd.Parameters.AddWithValue("QUESTAO_ID", questao.Id);
                comandoBd.Parameters.AddWithValue("ALTERNATIVA", questao.Alternativas[i]);

                comandoBd.ExecuteNonQuery();
            }
        }

        public void EditarAlternativas(Questao questao)
        {
            comandoBd.CommandText = DeleteAlternativas;

            comandoBd.Parameters.Clear();
            comandoBd.Parameters.AddWithValue("ID", questao.Id);
            comandoBd.ExecuteNonQuery();

            comandoBd.CommandText = AddAlternativas;

            for (int i = 0; i < questao.Alternativas.Count; i++)
            {
                comandoBd.Parameters.Clear();
                comandoBd.Parameters.AddWithValue("QUESTAO_ID", questao.Id);
                comandoBd.Parameters.AddWithValue("ALTERNATIVA", questao.Alternativas[i]);

                comandoBd.ExecuteNonQuery();
            }
        }

        public void ObterAlternativas(Questao questao, SqlDataReader reader)
        {
            List<string> alternativas = new();

            string alternativa = Convert.ToString(reader["ALTERNATIVA_ALTERNATIVA"])!;
            alternativas.Add(alternativa);

            while (reader.Read())
            {
                alternativa = Convert.ToString(reader["ALTERNATIVA_ALTERNATIVA"])!;
                alternativas.Add(alternativa);
            }

            questao.Alternativas = alternativas;
        }

        protected override MapeadorBase<Questao> Mapear => new MapeadorQuestao();
    }
}
